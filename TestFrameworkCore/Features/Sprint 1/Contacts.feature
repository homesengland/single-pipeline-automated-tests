Feature: Manage Contact functionality
        Feature to test the functionality of contacts

    Background:
    Given I navigate to the url
    Then  the login page should be displayed
	When  I login as 'Admin' user to the application
    Then  I should land on the AppLanding page
    When  I click on the CRM project
    Then  I should land on the Home page

    @Regression @Contact @Test2.1
    Scenario Outline: Test 2.1 Create a new contact  from the contacts screen
    When  I click on the contacts link
    Then  I should land on the contacts page
    When  I click on the Add Contact link
    Then  I should land on the New Contact form page
    When  I fill the mandatory fields for contact and Save
    Then  I should land on the contacts page
    When  I filter contacts using the first name
    Then  I should see the recently created contract
    


     @Regression @Contact @Test2.2
    Scenario Outline: Test 2.2 Associate a existing contact with a partner
    When  I click on the partners link
    Then  I should land on the partners page
    When  I click on the partner name link for '<Partner>'
    Then  I should land on the partner details page
    When  I navigate to the managed contacts page
    And   When I click on the Add existing contact button
    Then  the contact associated view should be dispalyed
    When  I add existing contact to partner
    Then  I should see the contact under the contact associated view

    Examples: 
    | Partner        |
    | Test Partner   |


         @Regression @Contact @Test2.3
    Scenario Outline: Test 2.3 Add a new contact to an existing partner
    When  I click on the partners link
    Then  I should land on the partners page
    When  I click on the partner name link for '<Partner>'
    Then  I should land on the partner details page
    When  I navigate to the managed contacts page
    When  I click on the Add Contact link in Managed contacts
    Then  the Quick create contact section should be displayed
    When  I fill the mandatory fields for contact and Save and Close
    Then  I should see the contact under the contact associated view

    Examples: 
    | Partner           |
    | New Test Partner  |


             @Regression @Contact @Test2.4
    Scenario Outline: Test 2.4 Validate mandatory fields for contacts
    When  I click on the contacts link
    Then  I should land on the contacts page
    When  I click on the Add Contact link
    Then  I should land on the New Contact form page
    When  I fill the mandatory fields for contact
    Then  Validate that the First Name field is mandatory and error message is correct
    Then  Validate that the Last Name field is mandatory and error message is correct
    Then  Validate that the Job Title field is mandatory and error message is correct
    Then  Validate that the Partner field is mandatory and error message is correct
    Then  Validate that the Email field is mandatory and error message is correct

