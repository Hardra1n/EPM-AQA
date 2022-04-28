Feature: CurrencyVariation


@browser
@DataSource:../../../TestLayer/TestData/Currencies.csv
Scenario:  Currency changes after selecting required currency
	When user opens currency changing tab
	And user chooses '<Name>' currency
	And user opens Car Rentals Page
	And user enters 'Berlin' pick-up location
	And user selects first pick-up suggestion with name 'Berlin'
	And user clicks search button
	Then price should contain '<Value>'
