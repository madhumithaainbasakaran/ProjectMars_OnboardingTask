# Skills.feature
#
# This feature file tests the Skills section of the user profile.
# It follows the same pattern as Language.feature.

Feature: Skills Management
  As a user of the Project Mars application
  I want to manage the skills listed on my profile
  So that recruiters and people seeking specific skills can see what I have to offer

  # Runs before every scenario — logs in and opens the Skills tab
  Background:
    Given I am logged in to the application
    And I navigate to my profile page
    And I click on the Skills tab

  # ── Test 1: Add a new skill ──────────────────────────────────────────
  @Skills @Smoke
  Scenario: Add a new skill with a valid skill name and level
    When I click the Add New Skill button
    And I enter the skill name "Selenium"
    And I select the skill level "Expert"
    And I click the Add button
    Then I should see a success message confirming the skill was added
    And the skill "Selenium" should be visible in the skills list

  # ── Test 2: Add multiple skills via Scenario Outline ────────────────
  @Skills
  Scenario Outline: Add multiple skills with different skill levels
    When I click the Add New Skill button
    And I enter the skill name "<Skill>"
    And I select the skill level "<Level>"
    And I click the Add button
    Then I should see a success message confirming the skill was added
    And the skill "<Skill>" should be visible in the skills list

    Examples:
      | Skill    | Level        |
      | Java     | Expert       |
      | Cucumber | Intermediate |
      | SQL      | Beginner     |

  # ── Test 3: Edit an existing skill ───────────────────────────────────
  @Skills
  Scenario: Edit an existing skill name and level
    Given the skill "Selenium" with level "Expert" already exists on my profile
    When I click the Edit button for the skill "Selenium"
    And I update the skill name to "Selenium WebDriver"
    And I select the skill level "Expert"
    And I click the Update button
    Then I should see a success message confirming the skill was updated
    And the skill "Selenium WebDriver" should be visible in the skills list
    And the skill "Selenium" should no longer be visible in the skills list

  # ── Test 4: Delete a skill ────────────────────────────────────────────
  @Skills
  Scenario: Delete an existing skill from the profile
    Given the skill "SQL" with level "Beginner" already exists on my profile
    When I click the Delete button for the skill "SQL"
    Then I should see a success message confirming the skill was deleted
    And the skill "SQL" should no longer be visible in the skills list

  # ── Test 5: Validation — submit empty skill name ─────────────────────
  @Skills @Negative
  Scenario: Attempt to add a skill without entering a skill name
    When I click the Add New Skill button
    And I select the skill level "Intermediate"
    And I click the Add button
    Then I should see an error or validation message

  # ── Test 6: Cancel without saving ────────────────────────────────────
  @Skills @Negative
  Scenario: Cancel adding a new skill
    When I click the Add New Skill button
    And I enter the skill name "Docker"
    And I click the Cancel button
    Then the skill "Docker" should not appear in the skills list
