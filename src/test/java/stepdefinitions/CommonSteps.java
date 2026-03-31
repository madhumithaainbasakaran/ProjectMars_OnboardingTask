package stepdefinitions;

import io.cucumber.java.en.Given;
import pages.LoginPage;
import pages.ProfilePage;

/*
 * ============================================================
 *  CommonSteps.java
 * ============================================================
 *  This file contains step definitions that are SHARED between
 *  the Language tests AND the Skills tests.
 *
 *  Both features start with:
 *    Given I am logged in to the application
 *    And I navigate to my profile page
 *
 *  Instead of writing these steps twice, we put them here once
 *  and Cucumber will find and use them for both features.
 *
 *  HOW DOES IT WORK?
 *  Each method here is linked to a line in a .feature file
 *  using the @Given annotation.
 *  When Cucumber reads "Given I am logged in...", it runs the
 *  method below that has that same text in its @Given annotation.
 * ============================================================
 */
public class CommonSteps {

    // SharedDriver gives us the browser — Cucumber passes it in automatically
    private SharedDriver sharedDriver;

    // Constructor — Cucumber automatically gives us the SharedDriver
    public CommonSteps(SharedDriver sharedDriver) {
        this.sharedDriver = sharedDriver;
    }

    // -------------------------------------------------------
    // STEP: "Given I am logged in to the application"
    // -------------------------------------------------------
    // This step:
    // 1. Opens the app in the browser
    // 2. Clicks Sign In
    // 3. Types the email and password
    // 4. Clicks the Login button
    @Given("I am logged in to the application")
    public void iAmLoggedInToTheApplication() {

        // Create a LoginPage object so we can use its methods
        LoginPage loginPage = new LoginPage(sharedDriver.driver);

        // Step 1: Open the app (goes to the URL in TestData)
        loginPage.goToHomePage(TestData.APP_URL);

        // Step 2: Click the Sign In link
        loginPage.clickSignIn();

        // Step 3 & 4: Enter credentials and click Login
        loginPage.enterEmail(TestData.EMAIL);
        loginPage.enterPassword(TestData.PASSWORD);
        loginPage.clickLoginButton();

        System.out.println("Successfully logged in");
    }

    // -------------------------------------------------------
    // STEP: "And I navigate to my profile page"
    // -------------------------------------------------------
    @Given("I navigate to my profile page")
    public void iNavigateToMyProfilePage() {

        // Create a ProfilePage object to navigate the profile
        ProfilePage profilePage = new ProfilePage(sharedDriver.driver);

        // Click the Profile link in the navigation bar
        profilePage.goToProfilePage();

        System.out.println("Navigated to profile page");
    }

    // -------------------------------------------------------
    // STEP: "And I click on the Languages tab"
    // -------------------------------------------------------
    @Given("I click on the Languages tab")
    public void iClickOnTheLanguagesTab() {

        ProfilePage profilePage = new ProfilePage(sharedDriver.driver);
        profilePage.clickLanguagesTab();

        System.out.println("Clicked on Languages tab");
    }

    // -------------------------------------------------------
    // STEP: "And I click on the Skills tab"
    // -------------------------------------------------------
    @Given("I click on the Skills tab")
    public void iClickOnTheSkillsTab() {

        ProfilePage profilePage = new ProfilePage(sharedDriver.driver);
        profilePage.clickSkillsTab();

        System.out.println("Clicked on Skills tab");
    }

}
