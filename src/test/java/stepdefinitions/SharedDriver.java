package stepdefinitions;

import io.github.bonigarcia.wdm.WebDriverManager;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.chrome.ChromeOptions;

import java.time.Duration;

/*
 * ============================================================
 *  SharedDriver.java
 * ============================================================
 *  This class has ONE job: keep track of our Chrome browser.
 *
 *  Why do we need this?
 *  Our tests are split across multiple files (LanguageSteps,
 *  SkillSteps, CommonSteps). They all need to use the SAME
 *  browser window. This class holds the browser so everyone
 *  can share it.
 *
 *  Cucumber's PicoContainer automatically creates ONE instance
 *  of this class and passes it into each step file that needs it.
 * ============================================================
 */
public class SharedDriver {

    // This is our Chrome browser object
    // 'public' means other classes can access it directly
    public WebDriver driver;

    // -------------------------------------------------------
    // openBrowser() — starts Chrome and gets it ready
    // -------------------------------------------------------
    public void openBrowser() {

        // Step 1: WebDriverManager downloads the right ChromeDriver
        // automatically — no manual download needed!
        WebDriverManager.chromedriver().setup();

        // Step 2: Set some Chrome options (settings for the browser)
        ChromeOptions options = new ChromeOptions();
        options.addArguments("--start-maximized");        // open browser full screen
        options.addArguments("--disable-notifications");  // block pop-up notifications

        // Step 3: Create a new Chrome browser window
        driver = new ChromeDriver(options);

        // Step 4: Tell Selenium to wait up to 10 seconds when
        // looking for elements before giving up
        driver.manage().timeouts().implicitlyWait(Duration.ofSeconds(10));
    }

    // -------------------------------------------------------
    // closeBrowser() — shuts Chrome down after the test
    // -------------------------------------------------------
    public void closeBrowser() {
        if (driver != null) {
            driver.quit(); // closes the browser completely
        }
    }

}
