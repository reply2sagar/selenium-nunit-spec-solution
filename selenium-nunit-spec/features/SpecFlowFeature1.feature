Feature: SpecFlowFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers



	@Test
	Scenario: travel scenario
	Given I entered the following data into the new travel form:
	| Field         | Value |
	| destinations  | bali                |
	| departureDate |  30 august 2022     |
	| returnDate    |  30 august 2022     |
    | ages          |  30                 |
	Then plan page should show correct details


	
