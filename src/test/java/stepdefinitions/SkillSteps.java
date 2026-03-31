package stepdefinitions;

import io.cucumber.java.en.Given;
import io.cucumber.java.en.Then;
import io.cucumber.java.en.When;
import pages.SkillPage;

/*
 * ============================================================
 *  SkillSteps.java
 * ============================================================
 *  This file contains all the step definitions for the
 *  Skills feature (Skills.feature).
 *
 *  It works exactly the same way as LanguageSteps.java
 *  but for Skills.
 *
 *  Each @Given / @When / @Then method maps to a line in
 *  the Skills.feature file.
 * ============================================================
 */
public class SkillSteps {

    // SkillPage has all the actions for the Skills section
    private SkillPage skillPage;

    // Constructor — Cucumber passes in SharedDriver automatically
    // We use sharedDriver here to get the driver, but don't need to store it
    public SkillSteps(SharedDriver sharedDriver) {
        // Create SkillPage using the shared browser driver
        this.skillPage = new SkillPage(sharedDriver.driver);
    }

    // ===========================================================
    // GIVEN STEPS — pre-conditions
    // ===========================================================

    /*
     * Makes sure a skill exists before we try to Edit or Delete it.
     * If it is not there, it adds it first.
     */
    @Given("the skill {string} with level {string} already exists on my profile")
    public void theSkillAlreadyExistsOnMyProfile(String skillName, String level) {

        boolean alreadyExists = skillPage.isSkillVisible(skillName);

        if (!alreadyExists) {
            System.out.println(skillName + " not found — adding it now...");
            skillPage.clickAddNewButton();
            skillPage.enterSkillName(skillName);
            skillPage.selectSkillLevel(level);
            skillPage.clickAddButton();

            // Short pause to let the page update
            try { Thread.sleep(500); } catch (InterruptedException e) { Thread.currentThread().interrupt(); }
        } else {
            System.out.println(skillName + " already exists — continuing with test");
        }
    }

    // ===========================================================
    // WHEN STEPS — actions
    // ===========================================================

    // Clicks the "+" button to open the Add Skill form
    @When("I click the Add New Skill button")
    public void iClickTheAddNewSkillButton() {
        skillPage.clickAddNewButton();
    }

    // Types a skill name into the form field
    @When("I enter the skill name {string}")
    public void iEnterTheSkillName(String skillName) {
        skillPage.enterSkillName(skillName);
    }

    // Picks a level from the dropdown e.g. "Expert", "Intermediate"
    @When("I select the skill level {string}")
    public void iSelectTheSkillLevel(String level) {
        skillPage.selectSkillLevel(level);
    }

    // Clicks the Add button to save the new skill
    @When("I click the Add button")
    public void iClickTheAddButton() {
        skillPage.clickAddButton();
    }

    // Clicks the Cancel button to discard the form
    @When("I click the Cancel button")
    public void iClickTheCancelButton() {
        skillPage.clickCancelButton();
    }

    // Clicks the Edit icon next to the given skill
    @When("I click the Edit button for the skill {string}")
    public void iClickTheEditButtonForTheSkill(String skillName) {
        skillPage.clickEditButton(skillName);
    }

    // Types a new name into the skill name field (when editing)
    @When("I update the skill name to {string}")
    public void iUpdateTheSkillNameTo(String newName) {
        skillPage.updateSkillName(newName);
    }

    // Clicks Update to save the edited skill
    @When("I click the Update button")
    public void iClickTheUpdateButton() {
        skillPage.clickUpdateButton();
    }

    // Clicks Delete next to the given skill
    @When("I click the Delete button for the skill {string}")
    public void iClickTheDeleteButtonForTheSkill(String skillName) {
        skillPage.clickDeleteButton(skillName);
    }

    // ===========================================================
    // THEN STEPS — verifications / assertions
    // ===========================================================

    // Checks that a success message appeared after adding a skill
    @Then("I should see a success message confirming the skill was added")
    public void iShouldSeeASuccessMessageForSkillAdded() {
        String message = skillPage.getToastMessageText();

        if (message != null && !message.trim().isEmpty()) {
            System.out.println("PASS: Success message appeared — " + message);
        } else {
            throw new AssertionError("FAIL: Expected a success message after adding skill but none appeared!");
        }
    }

    // Checks that a success message appeared after updating a skill
    @Then("I should see a success message confirming the skill was updated")
    public void iShouldSeeASuccessMessageForSkillUpdated() {
        String message = skillPage.getToastMessageText();

        if (message != null && !message.trim().isEmpty()) {
            System.out.println("PASS: Update success message appeared — " + message);
        } else {
            throw new AssertionError("FAIL: Expected a success message after update but none appeared!");
        }
    }

    // Checks that a success message appeared after deleting a skill
    @Then("I should see a success message confirming the skill was deleted")
    public void iShouldSeeASuccessMessageForSkillDeleted() {
        String message = skillPage.getToastMessageText();

        if (message != null && !message.trim().isEmpty()) {
            System.out.println("PASS: Delete success message appeared — " + message);
        } else {
            throw new AssertionError("FAIL: Expected a success message after delete but none appeared!");
        }
    }

    // Checks that the given skill IS in the list
    @Then("the skill {string} should be visible in the skills list")
    public void theSkillShouldBeVisibleInTheSkillsList(String skillName) {

        // Short pause to let the page update
        try { Thread.sleep(500); } catch (InterruptedException e) { Thread.currentThread().interrupt(); }

        boolean isVisible = skillPage.isSkillVisible(skillName);

        if (isVisible) {
            System.out.println("PASS: Skill '" + skillName + "' is in the list");
        } else {
            throw new AssertionError("FAIL: Expected '" + skillName + "' to be in the list but it was not found!");
        }
    }

    // Checks that the given skill is NOT in the list anymore
    @Then("the skill {string} should no longer be visible in the skills list")
    public void theSkillShouldNoLongerBeVisibleInTheSkillsList(String skillName) {

        try { Thread.sleep(500); } catch (InterruptedException e) { Thread.currentThread().interrupt(); }

        boolean isVisible = skillPage.isSkillVisible(skillName);

        if (!isVisible) {
            System.out.println("PASS: Skill '" + skillName + "' has been removed");
        } else {
            throw new AssertionError("FAIL: Expected '" + skillName + "' to be removed but it is still in the list!");
        }
    }

    // Same check used after cancelling
    @Then("the skill {string} should not appear in the skills list")
    public void theSkillShouldNotAppearInTheSkillsList(String skillName) {
        theSkillShouldNoLongerBeVisibleInTheSkillsList(skillName);
    }

    // Checks that an error or validation message appeared
    @Then("I should see an error or validation message")
    public void iShouldSeeAnErrorOrValidationMessage() {
        String message = skillPage.getToastMessageText();

        if (message != null && !message.trim().isEmpty()) {
            System.out.println("PASS: Validation/error message appeared — " + message);
        } else {
            throw new AssertionError("FAIL: Expected a validation message but none appeared!");
        }
    }

}
