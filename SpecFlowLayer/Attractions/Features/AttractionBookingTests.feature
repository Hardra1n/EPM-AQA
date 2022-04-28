@UITest
Feature: AttractionBookingTests

Scenario: Change DateTime
	Given booking page is opened
	When attractions page is opened
	And enter <search> search string
	And choose cruise result
	And get date time values
	And choose date time
	And get date time values
	Then datetime should be not equivalent

	Examples:
		| search |
		| New    |

Scenario: Choose ticket
	Given booking page is opened
	When attractions page is opened
	And enter <search> search string
	And choose cruise result
	And ticket booking page is opened
	Then ticket booking page url should contain <urlPart>

	Examples:
		| search | urlPart |
		| New    | /book   |

Scenario: ChooseTicket_WhenTicketIsNotAdded
	Given booking page is opened
	When attractions page is opened
	And enter <search> search string
	And choose cruise result
	And choose adult ticket
	And click submit button
	Then attraction single page url shouldn't contain book

	Examples:
		| search |
		| New    |

Scenario: SubmitData_WhenDataArePut_ShouldGoToPayPage
	Given booking page is opened
	When attractions page is opened
	And enter <search> search string
	And choose cruise result
	And ticket booking page is opened
	And enter personal data '<firstName>' '<lastName>' '<email>' '<phone>'
	And submit data <submit>
	Then ticket booking page url should contain <urlPart>

	Examples:
		| search | firstName | lastName | email             | phone     | urlPart | submit |
		| New    | Igor      | Valeriy  | testMail@mail.com | 441234567 | /pay    | /pay   |

Scenario:SubmitData_WhenDataIsNotPut_ShouldStayOnPage
	Given booking page is opened
	When attractions page is opened
	And enter <search> search string
	And choose cruise result
	And ticket booking page is opened
	And submit data <submit>
	Then ticket booking page url shouldn't contain <urlPart>

	Examples:
		| search | submit | urlpart |
		| New    | /book  | /pay    |

