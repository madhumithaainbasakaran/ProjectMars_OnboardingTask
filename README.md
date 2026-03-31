# Language and Skills Automation — Project Mars

## Description
Automate the test cases for language and skills using BDD frameworks with Page Object Model.

## Use Case
As a user I would be able to show what languages and skills I know. So that the people seeking for skills and languages can look at what details I hold.

## Acceptance Criteria
- Write automation tests from the test cases that were written for language and skills.
- Make sure all tests pass.

---

## Java Project (Cucumber BDD)

### Tech Stack
- Java, Selenium WebDriver, Cucumber (BDD), TestNG, Maven, Page Object Model (POM)

### Project Structure
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

### Setup
1. Clone this repository
2. Open in Eclipse as a Maven project
3. Update credentials in `src/test/java/stepdefinitions/TestData.java`:
```java
public static final String APP_URL  = "http://localhost:5000/";
public static final String EMAIL    = "your@email.com";
public static final String PASSWORD = "yourPassword";
```
4. Make sure Project Mars is running on `http://localhost:5000/`

### How to Run
```
mvn test
```
Or in Eclipse: Right-click `TestRunner.java` → Run As → TestNG Test

---

## C# Project (SpecFlow BDD)

### Tech Stack
- C#, .NET 6.0, Selenium WebDriver, SpecFlow, NUnit, FluentAssertions, Page Object Model (POM)

### Project Structure
```
ProjectMars_OnboardingTask/
├── Features/
│   ├── Login.feature
│   ├── Language.feature
│   └── Skills.feature
├── Pages/
│   ├── HomePage.cs
│   ├── Login.cs
│   └── Profile.cs
├── StepDefinitions/
│   ├── LoginStepDefinitions.cs
│   ├── LanguageStepDefinitions.cs
│   └── SkillsStepDefinitions.cs
├── Utilities/
│   └── CommonDriver.cs
└── ProjectMars_OnboardingTask1.sln
```

### Setup
1. Install .NET 6.0 SDK and Google Chrome
2. Make sure Project Mars is running on `http://localhost:5000/`
3. Open `ProjectMars_OnboardingTask1.sln` in Visual Studio

### How to Run
Open Test Explorer in Visual Studio and click Run All Tests, or run:
```
dotnet test
```

---

## Test Cases Covered (Both Projects)

### Authentication
- Authenticated users can access the profile page
- Unauthenticated users are redirected to the login page

### Languages
- Add a new language with a valid name and level
- Add multiple languages with different proficiency levels
- Edit an existing language
- Delete a language
- Attempt to add a language without a name

### Skills
- Add a new skill with a valid name and level
- Add multiple skills with different skill levels
- Edit an existing skill
- Delete a skill
- Attempt to add a skill without a name

---

> Note: Please update credentials in `TestData.java` (Java) before running the Java project.
