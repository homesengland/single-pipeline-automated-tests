Feature: 4519 Sprint 5_Customise Entities
	4519 -Validate that the Accounts entity has been customised to use as LA and Partner

Background: 
	Given I navigate to the url
	Then I should land on the page 'Global Dashboard'

	@US4519 @Sprint5 @Partners
Scenario Outline: Test 1 Validate LSH menu tab for Contacts
	Then I validate that 'Contacts' tab is present in the LHS menu
	When i click on the tab 'Contacts'
	Then the page 'Contacts' is displayed

	
