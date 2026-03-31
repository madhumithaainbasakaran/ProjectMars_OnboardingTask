package runners;

import io.cucumber.testng.AbstractTestNGCucumberTests;
import io.cucumber.testng.CucumberOptions;

/*
 * ============================================================
 *  TestRunner.java
 * ============================================================
 *  This is the entry point for running all our tests.
 *
 *  Think of it like a remote control — it points Cucumber
 *  to where our feature files and step definitions are.
 *
 *  HOW TO RUN THE TESTS:
 *  Option 1: Right-click this file in IntelliJ → Run
 *  Option 2: In terminal, type: mvn test
 *
 *  @CucumberOptions settings explained:
 *  ─────────────────────────────────────────────────────────
 *  features  = where to find the .feature files (our Gherkin tests)
 *  glue      = where to find the step definitions and hooks
 *  plugin    = how to report results (pretty = readable console output)
 *  monochrome = removes special characters from console output
 * ============================================================
 */
@CucumberOptions(
    // Where our Gherkin .feature test files are located
    features = "src/test/resources/features",

    // Where our step definition Java files and hooks are located
    glue = {"stepdefinitions", "hooks"},

    // How to display results
    plugin = {
        "pretty",                                               // readable output in console
        "html:target/cucumber-reports/cucumber-report.html"    // save an HTML report
    },

    // Makes console output cleaner (no weird symbols)
    monochrome = true
)
public class TestRunner extends AbstractTestNGCucumberTests {
    /*
     * No code needed inside here!
     * AbstractTestNGCucumberTests does all the work.
     * The @CucumberOptions above configure everything.
     */
}
