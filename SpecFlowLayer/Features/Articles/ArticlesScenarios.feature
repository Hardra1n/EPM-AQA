Feature: ArticlesScenarios

@browser
Scenario: Articles have correct links
	Given Stay`s main context is opened
	When User get searching page`s articles
	Then All links start with '<correct part>' part

	Examples: 
	|			correct part            |
	| https://www.booking.com/articles/ |

@browser
Scenario: Checking filtering of articles
	Given Stay`s main context is opened
	And Articles` page opened
	When User get topics` names
	And User get first article`s title
	Then Articles` titles are not equal to each other