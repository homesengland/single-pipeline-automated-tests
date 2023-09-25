Feature: AccessibilityTest
        Feature to test the accessibility of page or elements on page


    Scenario: Test-1 for Accessability of page
    Given I navigate to the url
    When I check accessability of page
    Then there should be no issues found

    Scenario: Test-2 for Accessability of element
    Given I navigate to the url
    When I check accessability of element
    Then there should be no issues found

    Scenario: Test-3 for Accessability of list of element
    Given I navigate to the url
    When I check accessability of list of element
    Then there should be no issues found

    Scenario: Test-4 for Accessability of elements excluding rules
    Given I navigate to the url
    When I check accessability of elements excluding rules
    Then there should be no issues found
        
    Scenario: Test-5 for Accessability of page excluding rules
    Given I navigate to the url
    When I check accessability of page excluding rules
    Then there should be no issues found

    Scenario: Test-6 for Accessability of page excluding elements
    Given I navigate to the url
    When I check accessability of page excluding elements
    Then there should be no issues found
