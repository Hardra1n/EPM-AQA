Feature: SearchingPageScenarios

@browser
Scenario: Successful search result
	Given Stays page is opened
	And Default page context has been gotten
	When User sets given context
	And User clicks on Search button
	Then Results page should be opened

@browser
Scenario: Error when search without destination
	Given Stays page is opened
	And Default page context has been gotten
	When User removes destination
	And User sets given context
	And User clicks on Search button
	Then User should get panel error text
	And Error text should contain '<Error part>'

	Examples: 
	|			Error part                    |
	| enter a destination to start searching. |

@browser
Scenario: Error when search without selecting age
	Given Stays page is opened
	And Default page context has been gotten
	When User removes children age
	And User sets given context
	And User clicks on Search button
	Then User should get '<Error text>' error

	Examples: 
	|		  Error text		 |
	| Timed out after 10 seconds |

@browser
Scenario: Check if footer contains all elements
	Given Stays page is opened
	Then All footer links should contain neccessary parts