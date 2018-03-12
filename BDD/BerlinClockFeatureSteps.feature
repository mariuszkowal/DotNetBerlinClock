
Feature: The Berlin Clock
	As a clock enthusiast
    I want to tell the time using the Berlin Clock
    So that I can increase the number of ways that I can read the time


Scenario: Midnight 00:00
When the time is "00:00:00"
Then the clock should look like
"""
Y
OOOO
OOOO
OOOOOOOOOOO
OOOO
"""


Scenario: Middle of the afternoon
When the time is "13:17:01"
Then the clock should look like
"""
O
RROO
RRRO
YYROOOOOOOO
YYOO
"""

Scenario: Just before midnight
When the time is "23:59:59"
Then the clock should look like
"""
O
RRRR
RRRO
YYRYYRYYRYY
YYYY
"""

Scenario: Midnight 24:00
When the time is "24:00:00"
Then the clock should look like
"""
Y
RRRR
RRRR
OOOOOOOOOOO
OOOO
"""

Scenario: With leading zero
When the time is "01:00:00"
Then the clock should look like
"""
Y
OOOO
ROOO
OOOOOOOOOOO
OOOO
"""

Scenario: Without leading zero
When the time is "1:00:00"
Then the clock should look like
"""
Y
OOOO
ROOO
OOOOOOOOOOO
OOOO
"""

Scenario: After midnight
When the time is "24:00:01"
Then the clock should show error message "Not valid time format"

Scenario: Wrong hour
When the time is "27:00:00"
Then the clock should show error message "Not valid time format"

Scenario: Wrong minute
When the time is "13:60:00"
Then the clock should show error message "Not valid time format"

Scenario: Wrong second
When the time is "13:00:60"
Then the clock should show error message "Not valid time format"

Scenario: Not Time
When the time is "13:00:ab"
Then the clock should show error message "Not valid time format"

Scenario: Time not passsed
When the time is not passed
Then the clock should show error message "Time not passed"
