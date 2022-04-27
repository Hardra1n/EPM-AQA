Feature: SearchingPageScenarios

@browser
Scenario: Successful search result
	Given I go to stays page
	And I get default page context
	When I set given context
	And Click on Search button
	Then I should be navigated to results page

@browser
Scenario: Error when search without destination
	Given I go to stays page
	And I get default page context
	When I remove destination
	And I set given context
	And Click on Search button
	Then I should get panel error text
	And Error text should contain 'enter a destination to start searching.'

@browser
Scenario: Error when search without selecting age
	Given I go to stays page
	And I get default page context
	When I remove children age
	And I set given context
	And Click on Search button
	Then I should get 'Timed out after 10 seconds' error

@browser
Scenario: Check if footer contains all elements
	Given I go to stays page
	Then All footer links contain neccessary parts