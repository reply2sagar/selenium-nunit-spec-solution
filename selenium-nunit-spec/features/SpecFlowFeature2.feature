Feature: SpecFlowFeature2
	travel scenario



	@Test
	Scenario: travel scenario - usa
	Given I entered the following data into the new travel form:
	| Field         | Value |
	| destinations  | usa                |
	| departureDate |  30 august 2022     |
	| returnDate    |  30 august 2022     |
    | ages          |  30                 |
	Then plan page should show correct details

		@Test
	Scenario: travel scenario - uk
	Given I entered the following data into the new travel form:
	| Field         | Value |
	| destinations  | uk                |
	| departureDate |  30 august 2022     |
	| returnDate    |  30 august 2022     |
    | ages          |  30                 |
	And I call this
	Then plan page should show correct details
	And error should be displayed


	
