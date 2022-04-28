@UITest
Feature: AttractionsSearchResultsTests

Scenario: FilterResult_ShouldShowFilteredResults
	Given booking page is opened
	When attractions page is opened
	And go to search result <text>,<buttonText>
	And user filter by element except price <filter1>
	And user filter by price
	And user filter by element except price <filter2>
	And user filter by element except price <filter3>
	And return to search results page
	And get first result title
	Then search results title should contain <titleText>

	Examples:
		| text | buttonText | titleText                     | filter1    | filter2           | filter3  |
		| New  | Search     | Graffiti Workshop in Brooklyn | Activities | Free cancellation | Brooklyn |

Scenario:		SearchForSimilarActivities_ShouldShowSimilarResults
	Given booking page is opened
	When attractions page is opened
	And go to search result <text>,<buttonText>
	And user search for similar activities <filter1>
	And choose filter button <filter2>
	And get first result title
	Then search results title should contain <titleText>

	Examples:
		| text | buttonText | titleText                       | filter1 | filter2      |
		| New  | Search     | Edge Sky Deck Admission Tickets | Edge    | Lowest price |

Scenario: ChooseEdgeResult_ShouldOpenBusPage
	Given booking page is opened
	When attractions page is opened
	And go to search result <text>,<buttonText>
	And choose edge result
	Then attraction single page url should contain <urlPart>
	Examples:
		| text | buttonText | titleText                       | urlPart        |
		| New  | Search     | Edge Sky Deck Admission Tickets | night-bus-tour |