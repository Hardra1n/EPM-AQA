Feature: LanguageVariation

A short summary of the feature

@browser
@DataSource:../../../TestLayer/TestData/Translations.csv
Scenario: Language changes after selecting required language
	When user opens language changing tab
	And user chooses '<Language>' language
	Then car rentals changed name should be '<CarRentalsTranslation>'