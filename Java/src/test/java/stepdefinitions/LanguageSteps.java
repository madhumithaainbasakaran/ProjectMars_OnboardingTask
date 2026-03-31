package stepdefinitions;

import io.cucumber.java.en.Given;
import io.cucumber.java.en.Then;
import io.cucumber.java.en.When;
import pages.LanguagePage;

/*
 * ============================================================
 *  LanguageSteps.java
 * ============================================================
 *  This file contains all the step definitions for the
 *  Language feature (Language.feature).
 *
 *  Each method below matches a line from the .feature file:
 *
 *  @Given  → steps that SET UP the test (pre-conditions)
 *  @When   → steps that DO something (actions)
 *  @Then   → steps that CHECK something (assertions/verifications)
 *
 *  The text inside @Given("...") must EXACTLY match the text
 *  in the .feature file (Cucumber links them automatically).
 *
 *  The {string} part means "any text inside double quotes" —
 *  Cucumber passes that text as the method parameter.
 *  Example: When I enter the language name "English"
 *           → languageName = "English"
 * ============================================================
 */
public class LanguageSteps {

    // LanguagePage has all the actions for the Languages section
    private LanguagePage languagePage;

    // Constructor — Cucumber gives us SharedDriver automatically
    // We use it here to get the browser driver, but we don't need to store it
    // because everything we need is already in languagePage
    public LanguageSteps(SharedDriver sharedDriver) {
        // Create LanguagePage using the shared browser driver
        this.languagePage = new LanguagePage(sharedDriver.driver);
    }

    // ===========================================================
    // GIVEN STEPS — these set up pre-conditions before the test
    // ===========================================================

    /*
     * This step is used before Edit and Delete tests.
     * It checks if the language already exists. If it doesn't,
     * it adds it first so the test has something to work with.
     *
     * Example usage in feature file:
     *   Given the language "English" with level "Fluent" already exists
     */
    @Given("the language {string} with level {string} already exists on my profile")
    public void theLanguageAlreadyExistsOnMyProfile(String languageName, String level) {

        // Check if the language is already in the list
        boolean alreadyExists = languagePage.isLanguageVisible(languageName);

        if (!alreadyExists) {
            // Language is not there yet, so add it first
            System.out.println(languageName + " not found — adding it now...");
            languagePage.clickAddNewButton();
            languagePage.enterLanguageName(languageName);
            languagePage.selectLanguageLevel(level);
            languagePage.clickAddButton();

            // Short pause to let the page update
            try { Thread.sleep(500); } catch (InterruptedException e) { Thread.currentThread().interrupt(); }
        } else {
            System.out.println(languageName + " already exists — continuing with test");
        }
    }

    // ===========================================================
    // WHEN STEPS — these perform actions on the page
    // ===========================================================

    // Clicks the "+" button to open the Add Language form
    @When("I click the Add New Language button")
    public void iClickTheAddNewLanguageButton() {
        languagePage.clickAddNewButton();
    }

    // Types a language name into the form field
    // {string} = the language name from the feature file e.g. "English"
    @When("I enter the language name {string}")
    public void iEnterTheLanguageName(String languageName) {
        languagePage.enterLanguageName(languageName);
    }

    // Picks a level from the dropdown e.g. "Fluent", "Basic"
    @When("I select the language level {string}")
    public void iSelectTheLanguageLevel(String level) {
        languagePage.selectLanguageLevel(level);
    }

    // Clicks the Add button to save the language
    @When("I click the Add button")
    public void iClickTheAddButton() {
        languagePage.clickAddButton();
    }

    // Clicks the Cancel button to close the form without saving
    @When("I click the Cancel button")
    public void iClickTheCancelButton() {
        languagePage.clickCancelButton();
    }

    // Clicks the Edit (pencil) icon next to the given language
    @When("I click the Edit button for the language {string}")
    public void iClickTheEditButtonForTheLanguage(String languageName) {
        languagePage.clickEditButton(languageName);
    }

    // Types a new name into the language name field (when editing)
    @When("I update the language name to {string}")
    public void iUpdateTheLanguageNameTo(String newName) {
        languagePage.updateLanguageName(newName);
    }

    // Clicks the Update button to save the edited language
    @When("I click the Update button")
    public void iClickTheUpdateButton() {
        languagePage.clickUpdateButton();
    }

    // Clicks the Delete icon next to the given language
    @When("I click the Delete button for the language {string}")
    public void iClickTheDeleteButtonForTheLanguage(String languageName) {
        languagePage.clickDeleteButton(languageName);
    }

    // ===========================================================
    // THEN STEPS — these check / verify the result
    // ===========================================================

    /*
     * After adding a language, we expect a success message to appear.
     * We check that the message is not blank (not empty).
     *
     * NOTE: We use a simple if/else check here instead of a library
     * assertion so it is easy to understand what is happening.
     */
    @Then("I should see a success message confirming the language was added")
    public void iShouldSeeASuccessMessageForLanguageAdded() {
        String message = languagePage.getToastMessageText();

        // Check the message is not empty
        if (message != null && !message.trim().isEmpty()) {
            System.out.println("PASS: Success message appeared — " + message);
        } else {
            // If empty, the test should fail
            throw new AssertionError("FAIL: Expected a success message but none appeared!");
        }
    }

    // Checks that a success message appeared after editing a language
    @Then("I should see a success message confirming the language was updated")
    public void iShouldSeeASuccessMessageForLanguageUpdated() {
        String message = languagePage.getToastMessageText();

        if (message != null && !message.trim().isEmpty()) {
            System.out.println("PASS: Update success message appeared — " + message);
        } else {
            throw new AssertionError("FAIL: Expected a success message after update but none appeared!");
        }
    }

    // Checks that a success message appeared after deleting a language
    @Then("I should see a success message confirming the language was deleted")
    public void iShouldSeeASuccessMessageForLanguageDeleted() {
        String message = languagePage.getToastMessageText();

        if (message != null && !message.trim().isEmpty()) {
            System.out.println("PASS: Delete success message appeared — " + message);
        } else {
            throw new AssertionError("FAIL: Expected a success message after delete but none appeared!");
        }
    }

    // Checks that the given language IS visible in the list
    @Then("the language {string} should be visible in the languages list")
    public void theLanguageShouldBeVisibleInTheLanguagesList(String languageName) {

        // Short pause to let the page update after saving
        try { Thread.sleep(500); } catch (InterruptedException e) { Thread.currentThread().interrupt(); }

        boolean isVisible = languagePage.isLanguageVisible(languageName);

        if (isVisible) {
            System.out.println("PASS: Language '" + languageName + "' is in the list");
        } else {
            throw new AssertionError("FAIL: Expected '" + languageName + "' to be in the list but it was not found!");
        }
    }

    // Checks that the given language is NOT visible in the list
    @Then("the language {string} should no longer be visible in the languages list")
    public void theLanguageShouldNoLongerBeVisibleInTheLanguagesList(String languageName) {

        try { Thread.sleep(500); } catch (InterruptedException e) { Thread.currentThread().interrupt(); }

        boolean isVisible = languagePage.isLanguageVisible(languageName);

        if (!isVisible) {
            System.out.println("PASS: Language '" + languageName + "' has been removed from the list");
        } else {
            throw new AssertionError("FAIL: Expected '" + languageName + "' to be removed but it is still in the list!");
        }
    }

    // Same check used after cancelling — language should not be in the list
    @Then("the language {string} should not appear in the languages list")
    public void theLanguageShouldNotAppearInTheLanguagesList(String languageName) {
        // Reuse the same check as above
        theLanguageShouldNoLongerBeVisibleInTheLanguagesList(languageName);
    }

    // Checks that an error or validation message appeared (e.g. when form is empty)
    @Then("I should see an error or validation message")
    public void iShouldSeeAnErrorOrValidationMessage() {
        String message = languagePage.getToastMessageText();

        if (message != null && !message.trim().isEmpty()) {
            System.out.println("PASS: Validation/error message appeared — " + message);
        } else {
            throw new AssertionError("FAIL: Expected an error message but none appeared!");
        }
    }

}
