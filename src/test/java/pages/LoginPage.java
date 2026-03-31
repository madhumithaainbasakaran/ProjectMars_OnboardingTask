package pages;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;
import java.time.Duration;

/*
 * ============================================================
 *  LoginPage.java
 * ============================================================
 *  This is a "Page Object" for the Login page.
 *
 *  What is a Page Object?
 *  It is a Java class that represents ONE page in the app.
 *  Instead of writing browser clicks inside our test steps,
 *  we put them here. That way, if the page changes, we only
 *  need to update this one file.
 *
 *  This page handles:
 *  - Clicking the Sign In link
 *  - Typing email and password
 *  - Clicking the Login button
 * ============================================================
 */
public class LoginPage {

    // The browser (WebDriver) that this page will use
    private WebDriver driver;

    // -------------------------------------------------------
    // Constructor — called when we create a new LoginPage
    // We pass in the driver so this page can control the browser
    // -------------------------------------------------------
    public LoginPage(WebDriver driver) {
        this.driver = driver;
    }

    // -------------------------------------------------------
    // LOCATORS — these tell Selenium WHERE to find things
    // on the page. By.xpath finds an element using its HTML path.
    // -------------------------------------------------------

    // Finds the "Sign In" link in the navigation bar
    private By signInLink = By.xpath("//a[contains(text(),'Sign In')]");

    // Finds the email input field on the login form
    private By emailInputField = By.xpath("//input[@name='email']");

    // Finds the password input field on the login form
    private By passwordInputField = By.xpath("//input[@name='password']");

    // Finds the Login button
    private By loginButton = By.xpath("//button[contains(text(),'Login')]");

    // -------------------------------------------------------
    // METHODS — these are the actions we can do on this page
    // -------------------------------------------------------

    // Opens the app in the browser
    public void goToHomePage(String url) {
        driver.get(url);
        System.out.println("Opened the app: " + url);
    }

    // Clicks the Sign In link to open the login form
    public void clickSignIn() {
        // Wait up to 10 seconds for the Sign In link to appear, then click it
        WebDriverWait wait = new WebDriverWait(driver, Duration.ofSeconds(10));
        WebElement signIn = wait.until(ExpectedConditions.elementToBeClickable(signInLink));
        signIn.click();
        System.out.println("Clicked Sign In link");
    }

    // Types the email into the email field
    public void enterEmail(String email) {
        WebDriverWait wait = new WebDriverWait(driver, Duration.ofSeconds(10));
        WebElement emailField = wait.until(ExpectedConditions.visibilityOfElementLocated(emailInputField));
        emailField.clear();           // clear anything already typed
        emailField.sendKeys(email);   // type the email
        System.out.println("Entered email: " + email);
    }

    // Types the password into the password field
    public void enterPassword(String password) {
        WebElement passwordField = driver.findElement(passwordInputField);
        passwordField.clear();
        passwordField.sendKeys(password);
        System.out.println("Entered password");
    }

    // Clicks the Login button to submit the form
    public void clickLoginButton() {
        WebElement loginBtn = driver.findElement(loginButton);
        loginBtn.click();
        System.out.println("Clicked Login button");
    }

}
