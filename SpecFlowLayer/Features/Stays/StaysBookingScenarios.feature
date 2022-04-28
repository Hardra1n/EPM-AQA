Feature: StaysBookingScenarios

@browser
Scenario: Correct navigation to final steps
	Given Stays page is opened
	And Default page context has been gotten
	And Given context is set
	And Search button is clicked
	And Result page is opened
	And Room booking page is opened
	When User gets booking context
	And User sets booking context
	And User clicks confirm button
	Then Page is Final Booking page

@browser
Scenario: Appearing of notification
	Given Stays page is opened
	And Default page context has been gotten
	And Given context is set
	And Search button is clicked
	And Result page is opened
	And Room booking page is opened
	When User goes to main page
	And User checks for unfinished booking notification
	Then Notification has appeared