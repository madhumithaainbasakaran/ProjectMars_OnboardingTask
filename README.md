# 🌐 Language & Skills Automation — Beginner Friendly Guide

![Java](https://img.shields.io/badge/Java-11-ED8B00?logo=java)
![Maven](https://img.shields.io/badge/Maven-3.9-C71A36?logo=apachemaven)
![Cucumber](https://img.shields.io/badge/Cucumber-7.15-23D96C?logo=cucumber)
![Selenium](https://img.shields.io/badge/Selenium-4.20-43B02A?logo=selenium)
![TestNG](https://img.shields.io/badge/TestNG-7.9-orange)

> A beginner-friendly BDD test automation project for the Language and Skills features of the **Project Mars** recruiter application. Built with Java, Cucumber, Selenium, and TestNG — with comments throughout every file to explain what each line does.

---

## 📖 What Does This Project Do?

This project **automatically tests** the Language and Skills sections of a user's profile on the Project Mars app.

Instead of a human manually clicking buttons and checking results, our Java code does it automatically inside a real Chrome browser.

We use **BDD (Behaviour-Driven Development)** which means we write our tests in plain English first (in `.feature` files), then write Java code that tells the browser what to do for each step.

---

## 🗂 How the Project Is Organised

```
LanguageSkillsAutomation-Java-Beginner/
│
├── src/test/java/
│   │
│   ├── pages/                  ← Page Objects: one file per page of the app
│   │   ├── LoginPage.java      ← handles the login form
│   │   ├── ProfilePage.java    ← handles navigating to profile & tabs
│   │   ├── LanguagePage.java   ← handles the Languages section (add/edit/delete)
│   │   └── SkillPage.java      ← handles the Skills section (add/edit/delete)
│   │
│   ├── stepdefinitions/        ← connects the .feature file English to Java code
│   │   ├── SharedDriver.java   ← holds the Chrome browser so all files can share it
│   │   ├── TestData.java       ← stores the app URL, email and password
│   │   ├── CommonSteps.java    ← shared steps (login, navigate) used by both features
│   │   ├── LanguageSteps.java  ← all steps for Language.feature
│   │   └── SkillSteps.java     ← all steps for Skills.feature
│   │
│   ├── hooks/
│   │   └── Hooks.java          ← opens browser before test, closes it after
│   │
│   └── runners/
│       └── TestRunner.java     ← the "start button" that runs everything
│
├── src/test/resources/
│   └── features/
│       ├── Language.feature    ← test scenarios written in plain English
│       └── Skills.feature      ← test scenarios written in plain English
│
├── pom.xml                     ← Maven config — lists all the libraries we need
└── testng.xml                  ← tells TestNG to run our TestRunner
```

---

## 🔄 How a Test Works — Step by Step

Here is what happens when one scenario runs:

```
1. Hooks.java @Before runs
   → Opens a Chrome browser window

2. CommonSteps.java "Given I am logged in..."
   → Goes to the app URL
   → Clicks Sign In
   → Types email and password
   → Clicks Login

3. CommonSteps.java "And I navigate to my profile page"
   → Clicks the Profile link

4. CommonSteps.java "And I click on the Languages tab"
   → Clicks the Languages tab

5. LanguageSteps.java "When I click the Add New Language button"
   → Calls LanguagePage.clickAddNewButton()
   → Which finds the + button and clicks it

6. LanguageSteps.java "And I enter the language name 'English'"
   → Calls LanguagePage.enterLanguageName("English")
   → Which types "English" into the input field

... and so on until...

7. LanguageSteps.java "Then the language 'English' should be visible"
   → Calls LanguagePage.isLanguageVisible("English")
   → Returns true = TEST PASSES ✅
   → Returns false = TEST FAILS ❌

8. Hooks.java @After runs
   → Closes the Chrome browser
```

---

## 🛠 What You Need to Install

Before running this project, install the following:

| Tool | Download Link | Why we need it |
|------|--------------|----------------|
| Java JDK 11+ | https://adoptium.net/ | The language our code is written in |
| Maven 3.9+ | https://maven.apache.org/ | Downloads libraries and runs tests |
| Google Chrome | https://www.google.com/chrome/ | The browser Selenium controls |
| IntelliJ IDEA | https://www.jetbrains.com/idea/ | The editor to open and run the project |

> **Note:** You do NOT need to download ChromeDriver manually. The `WebDriverManager` library does it automatically!

---

## ⚙️ Setup — Change Your Credentials First!

> ⚠️ **This is required before the tests will work.**

Open this file:
```
src/test/java/stepdefinitions/TestData.java
```

Change these three lines to your own details:

```java
public static final String APP_URL  = "http://localhost:3000";   // ← your app URL
public static final String EMAIL    = "your.email@example.com"; // ← your email
public static final String PASSWORD = "YourPassword123!";       // ← your password
```

---

## ▶️ How to Run the Tests

### Option 1 — Using IntelliJ IDEA (easiest)
1. Open the project in IntelliJ
2. Find `TestRunner.java` in the `runners` package
3. Right-click it → click **Run 'TestRunner'**

### Option 2 — Using the terminal
```bash
# Navigate to the project folder
cd LanguageSkillsAutomation-Java-Beginner

# Download all libraries (first time only)
mvn clean install -DskipTests

# Run all tests
mvn test
```

### Run only certain tests using tags
```bash
# Run only the smoke tests
mvn test -Dcucumber.filter.tags="@Smoke"

# Run only Language tests
mvn test -Dcucumber.filter.tags="@Language"

# Run only Skills tests
mvn test -Dcucumber.filter.tags="@Skills"
```

---

## 📊 Test Reports

After running, open this file in your browser to see the results:
```
target/cucumber-reports/cucumber-report.html
```

---

## 📝 Test Scenarios Covered

### Languages (6 scenarios)
1. ✅ Add a new language
2. ✅ Add multiple languages (runs 3 times with different data)
3. ✅ Edit an existing language
4. ✅ Delete a language
5. ✅ Try to add with no name (validation)
6. ✅ Cancel without saving

### Skills (6 scenarios)
1. ✅ Add a new skill
2. ✅ Add multiple skills (runs 3 times with different data)
3. ✅ Edit an existing skill
4. ✅ Delete a skill
5. ✅ Try to add with no name (validation)
6. ✅ Cancel without saving

---

## 💡 Key Concepts Explained Simply

| Term | Simple Explanation |
|------|-------------------|
| **Selenium** | A library that lets Java control a real browser (click, type, read) |
| **Cucumber** | Lets you write tests in plain English using Given/When/Then |
| **Gherkin** | The plain English language used in `.feature` files |
| **Page Object** | A Java class that represents one page — keeps things organised |
| **Step Definition** | Java method that runs when Cucumber reads a Gherkin step |
| **Hooks** | Special methods that run before/after every test automatically |
| **TestNG** | The test runner that actually executes everything |
| **Maven** | Downloads libraries and runs the tests from the terminal |
| **WebDriverManager** | Automatically gets the right ChromeDriver — no manual setup |

---

## 📄 License

This project is for learning and portfolio purposes.
