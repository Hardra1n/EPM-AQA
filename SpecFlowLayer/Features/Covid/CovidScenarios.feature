Feature: CovidScenarios

@browser
Scenario: Check correction of links in country restrictions
	Given Covid page is opened
	When User gets country restrictions links
	Then Each link should contain '<first part>' or '<second part>' href part

	Examples: 
	| first part | second part |
	| http://    | https://    |

@browser
Scenario: Check correction of serpa widget
	Given Covid page is opened
	When User gets serpa widget
	And User gets source attribute
	Then Source should start with '<correct source>' part

	Examples: 
	| correct source |
	| https://t-cf.bstatic.com/static/tag_container/sherpa_tag_container |