Feature: StaysSearchResultsPageScenarios

@browser
Scenario: Hotel name is equal to card name
	Given Stays page is opened
	And Default page context has been gotten
	And Given context is set
	And Search button is clicked
	When User gets card`s title
	And User navigates to result
	And User gets hotel name
	Then Hotel name should contain card`s title

@browser
Scenario: Search results change after filtering
	Given Stays page is opened
	And Default page context has been gotten
	And Given context is set
	And Search button is clicked
	And <first request> results count has been gotten
	When User filters results
	And User gets <second request> results count
	Then Actual count is different from previous

	Examples: 
	| first request | second request |
	| first			| second		 |

@browser
Scenario: Place is shown on map
	Given Stays page is opened
	And Default page context has been gotten
	And Given context is set
	And Search button is clicked
	When User searches hotel on a map
	Then Map is displayed

@browser
Scenario: Hotel cards have correct price after filtering
	Given Stays page is opened
	And Default page context has been gotten
	And Given context is set
	And Search button is clicked
	When User sets price limits as <first limit> and <second limit>
	And User filters by price
	Then All cards should contain expected price

	Examples: 
	| first limit | second limit |
	|	 500	  |		600		 |