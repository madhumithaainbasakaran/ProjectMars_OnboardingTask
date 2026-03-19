# Language and Skills Automation — Project Mars

## Description

Automate the test cases for language and skills using the Cucumber BDD framework with Given, When, Then step definitions and Page Object Model pages.

Note: Please change the credentials in TestData.java according to your own details.

---

## Use Case

As a user I would be able to show what languages and skills I know.
So that the people seeking for skills and languages can look at what details I hold.

---

## Acceptance Criteria

- Write automation tests from the test cases that were written for language and skills.
- Make sure all tests pass.

---

## Test Cases Automated

**Languages**
- Add a new language with a valid name and level
- Add multiple languages with different proficiency levels
- Edit an existing language
- Delete a language
- Attempt to add a language without a name
- Cancel adding a language

**Skills**
- Add a new skill with a valid name and level
- Add multiple skills with different skill levels
- Edit an existing skill
- Delete a skill
- Attempt to add a skill without a name
- Cancel adding a skill

---

## Tech Stack

- Java
- Selenium WebDriver
- Cucumber (BDD)
- TestNG
- Maven
- Page Object Model (POM)

---

## Project Structure

```
src/test/java/
├── pages/
│   ├── LoginPage.java
│   ├── ProfilePage.java
│   ├── LanguagePage.java
│   └── SkillPage.java
├── stepdefinitions/
│   ├── SharedDriver.java
│   ├── TestData.java
│   ├── CommonSteps.java
│   ├── LanguageSteps.java
│   └── SkillSteps.java
├── hooks/
│   └── Hooks.java
└── runners/
    └── TestRunner.java

src/test/resources/features/
├── Language.feature
└── Skills.feature
```

---

## Setup

1. Clone this repository
2. Open in Eclipse as a Maven project
3. Update credentials in `src/test/java/stepdefinitions/TestData.java`:

```java
public static final String APP_URL  = "http://localhost:5000/";
public static final String EMAIL    = "your@email.com";
public static final String PASSWORD = "yourPassword";
```

4. Make sure Project Mars is running on `http://localhost:5000/`
5. Right-click `TestRunner.java` → Run As → TestNG Test

---

## How to Run

```
mvn test
```

Or in Eclipse:

Right-click `TestRunner.java` → Run As → TestNG Test

---

## Notes

- This project follows BDD using Cucumber with Given/When/Then syntax
- Page Object Model pattern is used to keep locators separate from test logic
- Tests are organised using feature files written in plain English
- Credentials in TestData.java are placeholders — update before running
