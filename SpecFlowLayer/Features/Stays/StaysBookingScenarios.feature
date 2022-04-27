Feature: StaysBookingScenarios

@browser
Scenario: Correct navigation to final steps
	Given I go to stays page
	And I get default page context
	And I set given context
	And Click on Search button
	And I navigate to result
	And I navigate to room booking
	When I get booking context
	And I set booking context
	And I click confirm button
	Then Page is Final Booking page

@browser
Scenario: Appearing of notification
	Given I go to stays page
	And I get default page context
	And I set given context
	And Click on Search button
	And I navigate to result
	And I navigate to room booking
	When I go to main page
	And Check for unfinished booking notification
	Then Notification has appeared