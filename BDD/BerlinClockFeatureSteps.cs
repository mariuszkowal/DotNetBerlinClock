using System;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BerlinClock
{
	[Binding]
	public class TheBerlinClockSteps
	{
		private ITimeConverter berlinClock = new TimeConverter();
		private String theTime;


		[When(@"the time is ""(.*)""")]
		public void WhenTheTimeIs(string time)
		{
			theTime = time;
		}

		[When(@"the time is not passed")]
		public void WhenTheTimeIsNotPassed()
		{
			theTime = null;
		}

		[Then(@"the clock should look like")]
		public void ThenTheClockShouldLookLike(string theExpectedBerlinClockOutput)
		{
			Assert.AreEqual(berlinClock.convertTime(theTime), theExpectedBerlinClockOutput);
		}

		[Then(@"the clock should show error message ""(.*)""")]
		public void ThenTheClockShouldShowErrorMessage(string theExpectedErrorMessage)
		{
			string exceptionMessage = null;
			try
			{
				berlinClock.convertTime(theTime);
			}
			catch (Exception exception)
			{
				exceptionMessage = exception.Message;
			}
			Assert.AreEqual(theExpectedErrorMessage, exceptionMessage);
		}

	}
}
