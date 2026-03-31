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
 *  SkillPage.java
 * ============================================================
 *  This Page Object handles everything in the Skills section
 *  of the user's profile.
 *
 *  It works exactly the same way as LanguagePage.java but
 *  for Skills instead of Languages.
 *
 *  It can:
 *  - Click Add to open the add skill form
 *  - Type a skill name
 *  - Choose a skill level from the dropdown
 *  - Save or cancel the form
 *  - Edit an existing skill
 *  - Delete a skill
 *  - Check if a skill is in the list
 *  - Read the success/error toast message
 * ============================================================
 */
public class SkillPage {

    // The browser this page will use
    private WebDriver driver;

    // Waits up to 10 seconds for elements to appear
    private WebDriverWait wait;

    // Constructor
    public SkillPage(WebDriver driver) {
        this.driver = driver;
        this.wait = new WebDriverWait(driver, Duration.ofSeconds(10));
    }

    // -------------------------------------------------------
    // LOCATORS — where to find things in the Skills section
    // -------------------------------------------------------

    // The "+" (add new) button at the top of the skills table
    private By addNewButton = By.xpath("//i[@class='plus icon']");

    // The text box where you type the skill name
    private By skillNameInput = By.xpath("//input[@placeholder='Add Skill']");

    // The dropdown to pick the skill level (Beginner, Intermediate, Expert)
    private By skillLevelDropdown = By.xpath("//div[contains(@class,'skill')]//select");

    // The "Add" button that saves the new skill
    private By addButton = By.xpath("//input[@value='Add']");

    // The "Update" button that saves an edited skill
    private By updateButton = By.xpath("//input[@value='Update']");

    // The "Cancel" button that closes the form without saving
    private By cancelButton = By.xpath("//input[@value='Cancel']");

    // The success or error message that pops up after an action
    private By toastMessage = By.xpath("//div[contains(@class,'ns-box-inner')]");

    // -------------------------------------------------------
    // METHODS — actions we can do on the Skills section
    // -------------------------------------------------------

    // Clicks the "+" button to open the Add Skill form
    public void clickAddNewButton() {
        WebElement addBtn = wait.until(ExpectedConditions.elementToBeClickable(addNewButton));
        addBtn.click();
        System.out.println("Clicked the Add New (+) button");
    }

    // Types the skill name into the text field
    public void enterSkillName(String skillName) {
        WebElement nameField = wait.until(ExpectedConditions.visibilityOfElementLocated(skillNameInput));
        nameField.clear();
        nameField.sendKeys(skillName);
        System.out.println("Typed skill name: " + skillName);
    }

    // Picks a level from the dropdown (e.g. "Expert", "Intermediate", "Beginner")
    public void selectSkillLevel(String level) {
        WebElement dropdown = wait.until(ExpectedConditions.visibilityOfElementLocated(skillLevelDropdown));
        Select select = new Select(dropdown);
        select.selectByVisibleText(level);
        System.out.println("Selected skill level: " + level);
    }

    // Clicks the "Add" button to save the new skill
    public void clickAddButton() {
        WebElement add = wait.until(ExpectedConditions.elementToBeClickable(addButton));
        add.click();
        System.out.println("Clicked Add button");
    }

    // Clicks the "Update" button to save an edited skill
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

    // Clicks the Edit (pencil) icon next to a specific skill
    public void clickEditButton(String skillName) {
        String xpath = "//td[normalize-space()='" + skillName + "']/following-sibling::td//i[contains(@class,'edit')]";
        By editIcon = By.xpath(xpath);
        WebElement editBtn = wait.until(ExpectedConditions.elementToBeClickable(editIcon));
        editBtn.click();
        System.out.println("Clicked Edit button for: " + skillName);
    }

    // Clears the skill name field and types a new name (used when editing)
    public void updateSkillName(String newName) {
        WebElement nameField = wait.until(ExpectedConditions.visibilityOfElementLocated(skillNameInput));
        nameField.clear();
        nameField.sendKeys(newName);
        System.out.println("Updated skill name to: " + newName);
    }

    // Clicks the Delete icon next to a specific skill
    public void clickDeleteButton(String skillName) {
        String xpath = "//td[normalize-space()='" + skillName + "']/following-sibling::td//i[contains(@class,'delete') or contains(@class,'trash')]";
        By deleteIcon = By.xpath(xpath);
        WebElement deleteBtn = wait.until(ExpectedConditions.elementToBeClickable(deleteIcon));
        deleteBtn.click();
        System.out.println("Clicked Delete button for: " + skillName);
    }

    // -------------------------------------------------------
    // HELPER / VERIFICATION METHODS
    // -------------------------------------------------------

    // Returns the text of the toast message shown after an action
    public String getToastMessageText() {
        WebElement toast = wait.until(ExpectedConditions.visibilityOfElementLocated(toastMessage));
        String message = toast.getText();
        System.out.println("Toast message: " + message);
        return message;
    }

    // Checks if a skill appears in the skills table
    // Returns true if found, false if not found
    public boolean isSkillVisible(String skillName) {
        try {
            By skillRow = By.xpath("//td[normalize-space()='" + skillName + "']");
            WebElement row = driver.findElement(skillRow);
            boolean visible = row.isDisplayed();
            System.out.println("Skill '" + skillName + "' visible: " + visible);
            return visible;
        } catch (NoSuchElementException e) {
            System.out.println("Skill '" + skillName + "' not found in list");
            return false;
        }
    }

}
