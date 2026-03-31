Feature: Language

  This feature file outlines various scenarios related to adding, removing, and managing languages on 
  the user's profile, covering both positive and negative test cases.

  Scenario: Adding Languages - Happy Path Test
    Given PreConditions: Navigate to profile page
    When User goes to Languages tab and clicks on Add New button
    And Adds Language as 'English' and choose Language Level from the dropdown as 'Fluent'
    And Clicks on Add button
    Then Language should be successfully added to profile

  Scenario: Adding Languages - Extended Positive Test
    Given PreConditions: Navigate to profile page
    When User goes to Languages tab and clicks on Add New button
    And Adds upto 4 languages with Language Levels
      | Language | Language Level      |
      | Tamil    | Native/Bilingual    |
      | German   | Conversational      |
      | English  | Fluent              |
      | French   | Basic               |
    And Clicks on Add button for each added Language
    Then All 4 languages should be successfully added to profile

  Scenario: Adding Languages - Destructive Test
    Given PreConditions: Navigate to profile page
    When User goes to Languages tab and clicks on Add New button
    And Adds 5 languages with Language Levels
      | Language | Language Level      |
      | Tamil    | Native/Bilingual    |
      | German   | Conversational      |
      | English  | Fluent              |
      | French   | Basic               |
      | Telugu   | Basic               |
    Then User should only be able to add 4 languages successfully

  Scenario: Adding Languages - Negative Test
    Given PreConditions: Navigate to profile page
    When User goes to Languages tab
    And Clicks on Add New button
    And Clicks on Add button without entering anything
    Then User should receive an error message as "Please enter language and level"

  Scenario: Removing Languages - Happy Path Test
    Given PreConditions: Navigate to profile page
    When User goes to Languages tab
    And Checks whether up to 4 languages have been added
    And Removes Language 'Tamil' and the Language Level 'Native/Bilingual' from the profile
    Then User should receive a message as "Tamil has been deleted from your languages"