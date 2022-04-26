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
