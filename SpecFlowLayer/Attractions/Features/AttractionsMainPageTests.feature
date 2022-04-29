@UITest
Feature: AttractionMainPageTests

Scenario: ChooseTopDestinations_ShouldRedirectToAttrPage
	Given booking page is opened
	When attractions page is opened
	And user go to top destination city <city>
	And user choose filter button <filter>
	Then search results title should contain <text>

	Examples:
		| city  | filter       | text                 |
		| Dubai | Lowest price | Palm Monorail Ticket |

Scenario: EnterSearchString_WhenAllDataAreValid_ShouldGoToTopThingToDo
	Given booking page is opened
	When attractions page is opened
	And enter <search> search string
	And choose cruise result
	Then attraction single page url should contain <urlPart>

	Examples:
		| search | urlPart                   |
		| New    | guided-sightseeing-cruise |

Scenario: EnterSearchString_WhenSearchStringIsNotValid_ShouldStayOnPage
	Given booking page is opened
	When attractions page is opened
	And enter <search> search string
	And submit search request <request>
	Then attraction  page url should contain <urlPart>

	Examples:
		| search   | urlPart           | request |
		| Абырвалг | attractions/index | Search  |

Scenario: ChooseAsiaTabAndGoToKyotoPage_ShouldGoToKyotoSearchPage
	Given booking page is opened
	When attractions page is opened
	And chose tab <tab>
	And user go to city <city>
	Then search results page url should contain <urlPart>

	Examples:
		| tab  | city  | urlPart                |
		| Asia | Kyoto | searchresults/jp/kyoto |

Scenario: GoToSearchResult_WhenNewEntered_ShouldGoToNewYorkSearchPage
	Given booking page is opened
	When attractions page is opened
	And go to search result <text>,<buttonText>
	Then search results page url should contain <urlPart>

	Examples:
		| text | buttonText | urlPart                   |
		| New  | Search     | searchresults/us/new-york |

Scenario: CheckFooterLinks_ShouldHaveCorrectAttribure
	Given booking page is opened
	When attractions page is opened
	Then footer links should have correct attribure