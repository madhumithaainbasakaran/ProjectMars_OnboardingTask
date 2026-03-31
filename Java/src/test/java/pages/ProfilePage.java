package pages;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;
import java.time.Duration;

/*
 * ============================================================
 *  ProfilePage.java
 * ============================================================
 *  This Page Object represents the Profile page.
 *
 *  After logging in, the user needs to go to their Profile page
 *  to see the Languages and Skills sections.
 *
 *  This page handles:
 *  - Clicking the Profile link in the navigation
 *  - Clicking the Languages tab
 *  - Clicking the Skills tab
 * ============================================================
 */
public class ProfilePage {

    // The browser this page will use
    private WebDriver driver;

    // Constructor — receives the browser driver
    public ProfilePage(WebDriver driver) {
        this.driver = driver;
    }

    // -------------------------------------------------------
    // LOCATORS
    // -------------------------------------------------------

    // The Profile link in the top navigation menu
    private By profileLink = By.xpath("//a[contains(text(),'Profile')]");

    // The Languages tab inside the profile page
    private By languagesTab = By.xpath("//a[normalize-space()='Languages']");

    // The Skills tab inside the profile page
    private By skillsTab = By.xpath("//a[normalize-space()='Skills']");

    // -------------------------------------------------------
    // METHODS
    // -------------------------------------------------------

    // Clicks the Profile link to navigate to the profile page
    public void goToProfilePage() {
        WebDriverWait wait = new WebDriverWait(driver, Duration.ofSeconds(10));
        WebElement profile = wait.until(ExpectedConditions.elementToBeClickable(profileLink));
        profile.click();
        System.out.println("Navigated to Profile page");
    }

    // Clicks the Languages tab so we can see the languages section
    public void clickLanguagesTab() {
        WebDriverWait wait = new WebDriverWait(driver, Duration.ofSeconds(10));
        WebElement languages = wait.until(ExpectedConditions.elementToBeClickable(languagesTab));
        languages.click();
        System.out.println("Clicked Languages tab");
    }

    // Clicks the Skills tab so we can see the skills section
    public void clickSkillsTab() {
        WebDriverWait wait = new WebDriverWait(driver, Duration.ofSeconds(10));
        WebElement skills = wait.until(ExpectedConditions.elementToBeClickable(skillsTab));
        skills.click();
        System.out.println("Clicked Skills tab");
    }

}
