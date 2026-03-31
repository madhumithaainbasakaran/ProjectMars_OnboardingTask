# Language.feature
#
# This is a Gherkin feature file. It describes our tests in plain English.
# Each scenario is one test case.
#
# Structure:
#   Feature   = the overall thing we are testing
#   Background = steps that run before EVERY scenario in this file
#   Scenario  = one individual test case
#   Given     = the setup / starting condition
#   When      = the action we perform
#   Then      = what we expect to see after the action
#   And       = continues the previous Given / When / Then

Feature: Language Management
  As a user of the Project Mars application
  I want to manage the languages listed on my profile
  So that recruiters and people seeking language skills can see what languages I know

  # Background runs before every scenario below
  # It logs in and navigates to the Languages tab
  Background:
    Given I am logged in to the application
    And I navigate to my profile page
    And I click on the Languages tab

  # ── Test 1: Add a new language ─────────────────────────────────────
  @Language @Smoke
  Scenario: Add a new language with a valid language and level
    When I click the Add New Language button
    And I enter the language name "English"
    And I select the language level "Fluent"
    And I click the Add button
    Then I should see a success message confirming the language was added
    And the language "English" should be visible in the languages list

  # ── Test 2: Add multiple languages (Scenario Outline runs this ──────
  # scenario multiple times — once for each row in the Examples table)
  @Language
  Scenario Outline: Add multiple languages with different proficiency levels
    When I click the Add New Language button
    And I enter the language name "<Language>"
    And I select the language level "<Level>"
    And I click the Add button
    Then I should see a success message confirming the language was added
    And the language "<Language>" should be visible in the languages list

    Examples:
      | Language | Level            |
      | Tamil    | Basic            |
      | French   | Conversational   |
      | German   | Fluent           |

  # ── Test 3: Edit an existing language ──────────────────────────────
  @Language
  Scenario: Edit an existing language name and level
    Given the language "English" with level "Fluent" already exists on my profile
    When I click the Edit button for the language "English"
    And I update the language name to "Spanish"
    And I select the language level "Conversational"
    And I click the Update button
    Then I should see a success message confirming the language was updated
    And the language "Spanish" should be visible in the languages list
    And the language "English" should no longer be visible in the languages list

  # ── Test 4: Delete a language ───────────────────────────────────────
  @Language
  Scenario: Delete an existing language from the profile
    Given the language "French" with level "Basic" already exists on my profile
    When I click the Delete button for the language "French"
    Then I should see a success message confirming the language was deleted
    And the language "French" should no longer be visible in the languages list

  # ── Test 5: Validation — submit empty form ──────────────────────────
  @Language @Negative
  Scenario: Attempt to add a language without entering a name
    When I click the Add New Language button
    And I select the language level "Fluent"
    And I click the Add button
    Then I should see an error or validation message

  # ── Test 6: Cancel without saving ──────────────────────────────────
  @Language @Negative
  Scenario: Cancel adding a new language
    When I click the Add New Language button
    And I enter the language name "Italian"
    And I click the Cancel button
    Then the language "Italian" should not appear in the languages list
