Feature: StaysAdScenarios

@browser
Scenario: Correct navigation to booking page
	Given I go to stays page
	And I get default page context
	And I set given context
	And Click on Search button
	And I navigate to result
	When Get hotel name
	And I navigate to room booking
	And I get booked hotel name
	Then Booked name is subset of hotel name
