Feature: HelpCenterScenario

@browser
Scenario: Navigating buttons displayable and enabled
	Given I go to help center
	When I get question topics
	Then All buttons in topics are enabled and displayed
