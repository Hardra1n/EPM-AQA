Feature: HelpCenterScenario

@browser
Scenario: Navigating buttons displayable and enabled
	Given Help center page is opened
	When User gets question topics
	Then All buttons in topics are enabled and displayed
