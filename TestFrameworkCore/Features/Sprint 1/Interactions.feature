Feature: Manage Interactions functionality
        Feature to test the functionality of interactions

    Background:
    Given I navigate to the url
    Then  the login page should be displayed
	When  I login as 'Admin' to the application
    Then  I should land on the AppLanding page
    When  I click on the CRM project
    Then  I should land on the Home page

    @Regression @Interaction @Test3.1
    Scenario Outline: Test 3.1 Create a new interaction from the interactions screen
    When  I click on the interactions link
    Then  I should land on the interactions page
    When  I click on the Add Interaction link
    Then  I should land on the New Interaction form page
    When  I fill the mandatory fields for interaction and Save
    Then  I should land on the interactions page
    When  I filter interactions using the title of interaction
    Then  I should see the recently created interaction
    


    @Regression @Interaction @Test3.2
    Scenario Outline: Test 3.2 Add a new interaction to an existing partner
    When  I click on the partners link
    Then  I should land on the partners page
    When  I click on the partner name link for '<Partner>'
    Then  I should land on the partner details page
    When  I navigate to the managed interactions page
    When  I click on the Add Interaction link in Managed interactions
    Then  I should land on the New Interaction form page
    When  I fill the mandatory fields and save to create interaction
    Then  I should land on the partner details page
    When  I filter interactions using the title of interaction on association view
    Then  I should see the recently created interaction in associated view

    Examples: 
    | Partner          |
    | New Test Partner |


    @Regression @Interaction @Test3.3
    Scenario Outline: Test 3.3 Create a new interaction and mark as sensetive
    When  I click on the interactions link
    Then  I should land on the interactions page
    When  I click on the Add Interaction link
    Then  I should land on the New Interaction form page
    When  I fill the mandatory fields for interaction and mark as sensetive and Save
    Then  I should land on the interactions page
    When  I filter interactions using the title of interaction
    Then  I should see the recently created interaction


    @Regression @Interaction @Test3.4
    Scenario Outline: Test 3.4 Validate mandatory fields for interactions
    When  I click on the interactions link
    Then  I should land on the interactions page
    When  I click on the Add Interaction link
    Then  I should land on the New Interaction form page
    Then  Validate that the Interaction Type field is mandatory and error message is correct
    Then  Validate that the RelateTo field is mandatory and error message is correct
    When  I fill the mandatory fields for interaction
    Then  Validate that the Interaction Title field is mandatory and error message is correct
    Then  Validate that the Partner associated field is mandatory and error message is correct
    Then  Validate that the Notes field is mandatory and error message is correct
    Then  Validate that the Contact field is mandatory and error message is correct

