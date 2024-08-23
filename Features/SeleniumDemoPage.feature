Feature: Homepage
Testing selenium demo home page 

  Scenario: Select multiple dropdown options
    Given I open the demo page
    When I fill in the text input
    And I hover over the dropdown and check items count
    And I select multiple options from the dropdown and check the page
    Then I should see the correct text inside the iframe