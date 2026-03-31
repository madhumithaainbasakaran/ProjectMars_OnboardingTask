Feature: Skills

This feature file outlines the scenarios for adding, removing, and editing skills in a user profile 
along with various test cases.

Scenario: Adding Skills - Happy Path Test
    Given PreConditions: Navigate to profile page
    When User goes to Skills tab and clicks on Add New button
    And Add Skill as 'C' and choose Level from the dropdown as 'Intermediate'
    And Click on Add button
    Then New Skill Added

Scenario: Adding Skills - Extended Positive Test
    Given PreConditions: Navigate to profile page
    When User goes to Skills tab and clicks on Add New button
    And Click on Add New button and add multiple Skills and Levels
      | Skills          | Level        |
      | Selenium        | Expert       |
      | Manual Testing  | Expert       |
      | C#              | Intermediate |
      | Java            | Beginner     |
      | C               | Expert       |
    And Click on Add button for each added skills
    Then Multiple Skills Added

Scenario: Adding Skills - Negative Test (Invalid Input)
    Given PreConditions: Navigate to profile page
    When User goes to Skills tab
    And Click on Add New button
    And Click on Add button without entering anything
    Then Verify that the user receives an error message as "Please enter skill and experience level"

Scenario: Adding Skills - Destructive Test
    Given PreConditions: Navigate to profile page
    When User goes to Skills tab and clicks on Add New button
    And Click on Add New button and add multiple Skills and Levels
      | Skills          | Level        |
      | Selenium        | Expert       |
      | Manual Testing  | Expert       |
      | C#              | Intermediate |
      | Java            | Beginner     |
      | C               | Expert       |
    And Add Skills and Levels again
      | Skills | Level  |
      | C      | Expert |
    And Click on Add button for each added skills
    Then Verify that the user receives an error message as "Duplicated data"

Scenario: Removing Skills - Happy Path Test
    Given PreConditions: Navigate to profile page
    When User goes to Skills tab
    And Check whether the mentioned Skills are added
      | Skills          | Level        |
      | Selenium        | Expert       |
      | Manual Testing  | Expert       |
      | C#              | Intermediate |
      | Java            | Beginner     |
      | C               | Expert       |
    And Remove Skill 'Java' and the Level 'Beginner' from the profile
    Then Verify that the user receives a message as "Java has been deleted"

Scenario: Editing Skills - Happy Path Test
    Given PreConditions: Navigate to profile page
    When User goes to Skills tab
    And Check whether the mentioned Skills are added
      | Skills          | Level        |
      | Selenium        | Expert       |
      | Manual Testing  | Expert       |
      | C#              | Intermediate |
      | Java            | Beginner     |
      | C               | Expert       |
    And Edit the Skill 'C' and Level 'Expert' to 'C++' and Level 'Expert'
    Then Verify that the user receives a message as "C++ has been updated to your skills"