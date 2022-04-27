Feature: StaysAdScenarios

@browser
Scenario: Correct navigation to booking page
	Given Stays page is opened
	And Default page context has been gotten
	And Given context is set
	And Search button is clicked
	And Result page is opened
	When User gets hotel name
	And User navigates to room booking
	And User gets booked hotel name
	Then Booked name is subset of hotel name
