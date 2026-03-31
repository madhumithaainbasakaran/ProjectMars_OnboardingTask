package pages;

import org.openqa.selenium.By;
import org.openqa.selenium.NoSuchElementException;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.Select;
import org.openqa.selenium.support.ui.WebDriverWait;
import java.time.Duration;

/*
 * ============================================================
 *  LanguagePage.java
 * ============================================================
 *  This Page Object handles everything in the Languages section
 *  of the user's profile.
 *
 *  It can:
 *  - Click the Add (+) button to open the add form
 *  - Type a language name into the input field
 *  - Choose a level from the dropdown (e.g. Fluent, Basic)
 *  - Click Add to save, or Cancel to discard
 *  - Click Edit on an existing language to update it
 *  - Click Delete to remove a language
 *  - Check if a language is visible in the list
 *  - Read the success/error message that appears after an action
 * ============================================================
 */
public class LanguagePage {

    // The browser this page will use
    private WebDriver driver;

    // We use this to wait for elements to appear before clicking them
    private WebDriverWait wait;

    // Constructor — receives the browser driver and sets up the wait
    public LanguagePage(WebDriver driver) {
        this.driver = driver;
        // Wait up to 10 seconds for elements to appear
        this.wait = new WebDriverWait(driver, Duration.ofSeconds(10));
    }

    // -------------------------------------------------------
    // LOCATORS — where to find things on the Languages section
    // -------------------------------------------------------

    // The "+" (add new) button at the top of the languages table
    private By addNewButton = By.xpath("//i[@class='plus icon']");

    // The text box where you type the language name
    private By languageNameInput = By.xpath("//input[@placeholder='Add Language']");

    // The dropdown to pick the language level (Basic, Fluent, etc.)
    private By languageLevelDropdown = By.xpath("//div[contains(@class,'language')]//select");

    // The "Add" button that saves the new language
    private By addButton = By.xpath("//input[@value='Add']");

    // The "Update" button that saves an edited language
    private By updateButton = By.xpath("//input[@value='Update']");

    // The "Cancel" button that closes the form without saving
    private By cancelButton = By.xpath("//input[@value='Cancel']");

    // The success or error toast message that appears after an action
    private By toastMessage = By.xpath("//div[contains(@class,'ns-box-inner')]");

    // -------------------------------------------------------
    // METHODS — actions we can do on the Languages section
    // -------------------------------------------------------

    // Clicks the "+" button to open the Add Language form
    public void clickAddNewButton() {
        WebElement addBtn = wait.until(ExpectedConditions.elementToBeClickable(addNewButton));
        addBtn.click();
        System.out.println("Clicked the Add New (+) button");
    }

    // Types the language name into the text field
    public void enterLanguageName(String languageName) {
        WebElement nameField = wait.until(ExpectedConditions.visibilityOfElementLocated(languageNameInput));
        nameField.clear();                  // clear any existing text first
        nameField.sendKeys(languageName);   // type the new language name
        System.out.println("Typed language name: " + languageName);
    }

    // Picks a level from the dropdown (e.g. "Fluent", "Basic")
    public void selectLanguageLevel(String level) {
        WebElement dropdown = wait.until(ExpectedConditions.visibilityOfElementLocated(languageLevelDropdown));
        // Select is a Selenium helper class for working with <select> dropdowns
        Select select = new Select(dropdown);
        select.selectByVisibleText(level);
        System.out.println("Selected language level: " + level);
    }

    // Clicks the "Add" button to save the new language
    public void clickAddButton() {
        WebElement add = wait.until(ExpectedConditions.elementToBeClickable(addButton));
        add.click();
        System.out.println("Clicked Add button");
    }

    // Clicks the "Update" button to save an edited language
    public void clickUpdateButton() {
        WebElement update = wait.until(ExpectedConditions.elementToBeClickable(updateButton));
        update.click();
        System.out.println("Clicked Update button");
    }

    // Clicks the "Cancel" button to close the form without saving
    public void clickCancelButton() {
        WebElement cancel = wait.until(ExpectedConditions.elementToBeClickable(cancelButton));
        cancel.click();
        System.out.println("Clicked Cancel button");
    }

    // Clicks the Edit (pencil) icon next to a specific language
    // We use the language name to find the right row in the table
    public void clickEditButton(String languageName) {
        // Build an XPath that finds the edit icon in the same row as the language name
        String xpath = "//td[normalize-space()='" + languageName + "']/following-sibling::td//i[contains(@class,'edit')]";
        By editIcon = By.xpath(xpath);
        WebElement editBtn = wait.until(ExpectedConditions.elementToBeClickable(editIcon));
        editBtn.click();
        System.out.println("Clicked Edit button for: " + languageName);
    }

    // Clears the language name field and types a new name (used when editing)
    public void updateLanguageName(String newName) {
        WebElement nameField = wait.until(ExpectedConditions.visibilityOfElementLocated(languageNameInput));
        nameField.clear();
        nameField.sendKeys(newName);
        System.out.println("Updated language name to: " + newName);
    }

    // Clicks the Delete (bin) icon next to a specific language
    public void clickDeleteButton(String languageName) {
        String xpath = "//td[normalize-space()='" + languageName + "']/following-sibling::td//i[contains(@class,'delete') or contains(@class,'trash')]";
        By deleteIcon = By.xpath(xpath);
        WebElement deleteBtn = wait.until(ExpectedConditions.elementToBeClickable(deleteIcon));
        deleteBtn.click();
        System.out.println("Clicked Delete button for: " + languageName);
    }

    // -------------------------------------------------------
    // HELPER / VERIFICATION METHODS
    // -------------------------------------------------------

    // Returns the text of the toast message (success or error)
    // e.g. "English has been added to your languages"
    public String getToastMessageText() {
        WebElement toast = wait.until(ExpectedConditions.visibilityOfElementLocated(toastMessage));
        String message = toast.getText();
        System.out.println("Toast message: " + message);
        return message;
    }

    // Checks if a language name appears anywhere in the languages table
    // Returns true if found, false if not found
    public boolean isLanguageVisible(String languageName) {
        try {
            // Look for a table cell that exactly matches the language name
            By languageRow = By.xpath("//td[normalize-space()='" + languageName + "']");
            WebElement row = driver.findElement(languageRow);
            boolean visible = row.isDisplayed();
            System.out.println("Language '" + languageName + "' visible: " + visible);
            return visible;
        } catch (NoSuchElementException e) {
            // If the element is not found at all, it is definitely not visible
            System.out.println("Language '" + languageName + "' not found in list");
            return false;
        }
    }

}
