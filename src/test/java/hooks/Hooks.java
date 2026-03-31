package hooks;

import io.cucumber.java.After;
import io.cucumber.java.Before;
import io.cucumber.java.Scenario;
import stepdefinitions.SharedDriver;

/*
 * ============================================================
 *  Hooks.java
 * ============================================================
 *  Hooks are special methods that run automatically BEFORE
 *  and AFTER each test scenario.
 *
 *  Think of them like:
 *  - @Before = "Set the table before dinner"
 *  - @After  = "Clean up after dinner"
 *
 *  BEFORE each scenario:
 *    → We open a Chrome browser window
 *
 *  AFTER each scenario:
 *    → We close the Chrome browser window
 *
 *  This means every test starts with a fresh, clean browser.
 * ============================================================
 */
public class Hooks {

    // SharedDriver holds our Chrome browser object
    // Cucumber automatically passes it in (via PicoContainer)
    private SharedDriver sharedDriver;

    // Constructor — Cucumber gives us the SharedDriver automatically
    public Hooks(SharedDriver sharedDriver) {
        this.sharedDriver = sharedDriver;
    }

    // -------------------------------------------------------
    // @Before — runs BEFORE every single test scenario
    // -------------------------------------------------------
    @Before
    public void openBrowserBeforeTest(Scenario scenario) {
        System.out.println("------------------------------------------");
        System.out.println("STARTING TEST: " + scenario.getName());
        System.out.println("------------------------------------------");

        // Open a new Chrome browser window
        sharedDriver.openBrowser();
    }

    // -------------------------------------------------------
    // @After — runs AFTER every single test scenario
    // -------------------------------------------------------
    @After
    public void closeBrowserAfterTest(Scenario scenario) {

        // Tell us whether the test passed or failed
        if (scenario.isFailed()) {
            System.out.println("TEST FAILED: " + scenario.getName());
        } else {
            System.out.println("TEST PASSED: " + scenario.getName());
        }

        System.out.println("------------------------------------------");

        // Close the Chrome browser window
        sharedDriver.closeBrowser();
    }

}
