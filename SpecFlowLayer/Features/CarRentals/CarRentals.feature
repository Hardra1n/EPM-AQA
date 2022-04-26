Feature: CarRentals


Background: 
	Given user opened Car Rentals Page

@browser
Scenario: Search with existing results
	When user chooses same location to return car
	And user enters '<location>' pick-up location
	And user selects first pick-up suggestion with name '<location>'
	And user selects own driver age '<age>'
	And user clicks search button
	Then 'true' that car rentals results on the page

	Examples:
	| location | age |
	| Berlin   | 21  |

@browser
Scenario: Search without existing ruslts
	When user chooses different location to return car
	And user enters '<pick-up location>' pick-up location
	And user selects first pick-up suggestion with name '<pick-up location>'
	And user enters '<drop-off location>' drop-off location
	And user selects first drop-off suggestion with name '<drop-off location>'
	And user clicks search button
	Then 'false' that car rentals results on the page
	
	Examples: 
	| pick-up location | drop-off location |
	| Pruzhany         | Los Angeles       |

@browser
Scenario: Invalid search request
	When user chooses same location to return car
	And user enters '<wrong location name>' pick-up location
	And user clicks search button
	Then user can't go to new page
	But user can see the error message

	Examples: 
	| wrong location name |
	| ase232              |

@browser
Scenario: User can book car with options
	Given user chose same location to return car
	And user entered '<location>' pick-up location
	And user selected first pick-up suggestion with name '<location>'
	And user selected own driver age '<age>'
	And user clicked search button
	When user clicks first location to rent
	And user clicks first car to book
	And user choose all car's additional options
	And user clicks go to book button
	Then user on the booking page

	Examples: 
	| location | age |
	| Berlin   | 21  |