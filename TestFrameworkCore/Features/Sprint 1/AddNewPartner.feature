Feature: AddNewPartner

This feature file will contain all flows for creating a new partner

Background: 
    Given I navigate to the url
    Then  the login page should be displayed
	When  I login as 'Admin' user to the application
    Then  I should land on the AppLanding page
    When  I click on the CRM project
    Then  I should land on the Home page
    And I click on the Partners link
    And I should land on the Partners page

@Regression @Partners @Test1.1
Scenario Outline: Add New Partner Via Partner Screen With Mandatory Details
    Given I click on the Add Partner link
    And I should land on the New Partner form page
    And I enter a Partner Name <PartnerName>
    And I select a Sector <Sector>
    And I select a Partner Type
    And I enter a Street 1 <Street1>
    And I enter a Postcode <PostCode>
    When I click Save
    Then the Partner ID is populated
    When I click back
    And I search for the new Partner
    Then I should see the newly created partner
    When I select the new partner
    And I click the delete button
    Then the new partner should be deleted
    Examples:
    | PartnerName                         | Sector    | Street1      | PostCode |
    | Automated Partner Mandatory Details | Financial | 9 Manor Road | CV1 2LF  |

@Regression @Partners @Test1.2
Scenario Outline: Add New Partner Via Partner Screen With All Details
    Given I click on the Add Partner link
    And I should land on the New Partner form page
    And I enter a Partner Name <PartnerName>
    And I select a Sector <Sector>
    And I select a Partner Type
    And I select a SME Indicator
    And I enter a Companies House Number
    And I enter a Homes England Central Government Organisation Code
    And I enter a Homes England Combined Authority Code
    And I enter a Local Authority Code
    And I enter a Social Housing Provider Registration Number
    And I select a Primary Operating Region
    And I enter a Parent Partner
    And I enter a Ultimate Parent
    And I enter an Email
    And I enter a Website
    And I enter a Phone Number
    And I enter a Street 1 <Street1>
    And I enter a Address 1: Street 2
    And I enter a Address 1: Street 3
    And I enter a City
    And I enter a County
    And I enter a Postcode <PostCode>
    And I enter a Country
    When I click Save
    Then the Partner ID is populated
    When I click back
    And I search for the new Partner
    Then I should see the newly created partner
    When I select the new partner
    And I click the delete button
    Then the new partner should be deleted
    Examples:
    | PartnerName                   | Sector    | Street1           | PostCode |
    | Automated Partner All Details | Financial | Coffee#1 Coventry | CV1 5RR  |

@Regression @Partners @Test1.3
Scenario: Add a new parter via the quick add option
	Given I click on the Quick Add Partner button
    And I populate the Add Partner fields
    When I click Save and Close
    And I search for the new Partner
    And I click on View Record
    Then the Partner ID is populated
    When I click back
    And I search for the new Partner
    Then I should see the newly created partner
    When I select the new partner
    And I click the delete button
    Then the new partner should be deleted

@Regression @Partners @Test1.4
Scenario Outline: Add a new parter via the quick add company house search
	Given I click on the Quick Add Partner button
    And I click Use Automatic Search
    And I search for the company <CompanyName>
    When I save the company
    Then I should see a confirmation popup
    And I close the Companies Search popup
    And I search for the new Partner
    Then I should see the newly created partner by name
    When I select the new partner
    And I click the delete button
    Then the new partner should be deleted
    Examples:
    | CompanyName         |
    | CREATIVE TOMATO LTD |

@Regression @Partners @Test1.5
Scenario Outline: Add a new parter via company house search
	Given I click on the Company House button
    And I search for the company <CompanyName>
    When I save the company
    Then I should see a confirmation popup
    And I close the Companies Search popup
    And I search for the new Partner
    Then I should see the newly created partner by name
    When I select the new partner
    And I click the delete button
    Then the new partner should be deleted
    Examples:
    | CompanyName         |
    | CREATIVE TOMATO LTD |


@Regression @Partners @Test1.6
Scenario: Deactivate a partner
	Given I click on the Add Partner link
    And I should land on the New Partner form page
    And I enter the mandatory partner details
    When I click Save
    Then the Partner ID is populated
    When I click the Deactivate button
    Then the partner should be inactive and readonly
    When I click the Activate button
    Then the parter should be active and editable
    When I click back
    And I search for the new Partner
    Then I should see the newly created partner
    When I select the new partner
    And I click the delete button
    Then the new partner should be deleted


    @Regression @Partners @Test1.7
Scenario Outline: Validate the Mandatory fields for partner form
    Given I click on the Add Partner link
    And I should land on the New Partner form page
    When I click Save
    Then I validate all mandatory fields and error message is correct

