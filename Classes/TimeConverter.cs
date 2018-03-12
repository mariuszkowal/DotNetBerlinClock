using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BerlinClock
{
	public class TimeConverter : ITimeConverter
	{
		private const int interval = 5;
		private const char lampTurnedOff = 'O';
		private const string firstHoursRowTurnedOnTemplate = "RRRR";
		private const string firstHoursRowTurnedOffTemplate = "OOOO";
		private const string secondHoursRowTurnedOnTemplate = "RRRR";
		private const string secondHoursRowTurnedOffTemplate = "OOOO";
		private const string firstMinutesRowTurnedOnTemplate = "YYRYYRYYRYY";
		private const string firstMinutesRowTurnedOffTemplate = "OOOOOOOOOOO";
		private const string secondMinutesRowTurnedOnTemplate = "YYYY";
		private const string secondMinutesRowTurnedOffTemplate = "OOOO";
		private readonly Regex timeRegex = new Regex("^((?:0?[0-9]|1[0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9])|(24:00:00)$");
		public string convertTime(string aTime)
		{
			if (aTime == null)
			{
				throw new ArgumentNullException("Time not passed", null as Exception);
			}
			if (!timeRegex.IsMatch(aTime))
			{
				throw new ArgumentException("Not valid time format");
			}
			List<int> timeParts = aTime.Split(':').Select(int.Parse).ToList();
			int hours = timeParts[0];
			int minutes = timeParts[1];
			int seconds = timeParts[2];
			string secondsRow = seconds % 2 == 0 ? "Y" : "O";
			string firstHoursRow = getRowState(firstHoursRowTurnedOnTemplate, firstHoursRowTurnedOffTemplate, numberOfLampsTurnedOn: hours / interval);
			string secondHoursRow = getRowState(secondHoursRowTurnedOnTemplate, secondHoursRowTurnedOffTemplate, numberOfLampsTurnedOn: hours % interval);
			string firstMinutesRow = getRowState(firstMinutesRowTurnedOnTemplate, firstMinutesRowTurnedOffTemplate, numberOfLampsTurnedOn: minutes / interval);
			string secondMinutesRow = getRowState(secondMinutesRowTurnedOnTemplate, secondMinutesRowTurnedOffTemplate, numberOfLampsTurnedOn: minutes % interval);
			StringBuilder result = new StringBuilder();
			result.AppendLine(secondsRow);
			result.AppendLine(firstHoursRow);
			result.AppendLine(secondHoursRow);
			result.AppendLine(firstMinutesRow);
			result.Append(secondMinutesRow);
			return result.ToString();
		}

		private string getRowState(string rowTurnedOnTemplate, string rowTurnedOffTemplate, int numberOfLampsTurnedOn)
		{
			return rowTurnedOnTemplate.Substring(0, numberOfLampsTurnedOn) + rowTurnedOffTemplate.Substring(numberOfLampsTurnedOn);
		}
	}
}
