Feature: StaysSearchResultsPageScenarios

@browser
Scenario: Hotel name is equal to card name
	Given I go to stays page
	And I get default page context
	And I set given context
	And Click on Search button
	When I get card`s title
	And I navigate to result
	And Get hotel name
	Then Hotel name should contain card`s title

@browser
Scenario: Search results change after filtering
	Given I go to stays page
	And I get default page context
	And I set given context
	And Click on Search button
	And I get first results count
	When I filter results
	And I get second results count
	Then Actual count is different from previous

@browser
Scenario: Place is shown on map
	Given I go to stays page
	And I get default page context
	And I set given context
	And Click on Search button
	When I search hotel on a map
	Then Map is displayed

@browser
Scenario: Hotel cards have correct price after filtering
	Given I go to stays page
	And I get default page context
	And I set given context
	And Click on Search button
	When I set price limits as 500 and 600
	And I filter by price
	Then All cards should contain expected price