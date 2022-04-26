Feature: CarRentals


Background: 
	Given user opened Car Rentals Page

@browser
Scenario: Search with existing results
	When user chooses same location to return car
	And user enters 'Berlin' pick-up location
	And user selects first pick-up suggestion with name 'Berlin'
	And user selects own driver age '21'
	And user clicks search button
	Then 'true' that car rentals results on the page

@browser
Scenario: Search without existing ruslts
	When user chooses different location to return car
	And user enters 'Pruzhany' pick-up location
	And user selects first pick-up suggestion with name 'Pruzhany'
	And user enters 'Los Angeles' drop-off location
	And user selects first drop-off suggestion with name 'Los Angeles'
	And user clicks search button
	Then 'false' that car rentals results on the page
	
@browser
Scenario: Invalid search request
	When user chooses same location to return car
	And user enters 'ase232' pick-up location
	And user clicks search button
	Then user can't go to new page
	But user can see the error message

@browser
Scenario: User can book car with options
	Given user chose same location to return car
	And user entered 'Berlin' pick-up location
	And user selected first pick-up suggestion with name 'Berlin'
	And user selected own driver age '21'
	And user clicked search button
	When user clicks first location to rent
	And user clicks first car to book
	And user choose all car's additional options
	And user clicks go to book button
	Then user on the booking page