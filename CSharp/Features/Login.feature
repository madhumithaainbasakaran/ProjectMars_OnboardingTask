Feature: Login

Scenario: Positive Test - Authenticated users can access the profile page
    Given the user attempts to access the profile page
    When the user launches the URL "http://localhost:5000/"
    Then the user should be able to access the URL

    When the user clicks the Sign In button on the Home Page
    Then the user should be able to navigate to the Home page and click on the Sign In button successfully

    When the user signs in with valid credentials:
      | Username            | Password    |
      | madhusakar@gmail.com | MadhuQA@1995 |
    Then the user should be able to enter the Username and Password correctly

    When the user clicks on the login button
    Then the user should be successfully logged in and redirected to the Profile page

Scenario: Negative Test - Unauthenticated users are redirected to the login page when trying to access the profile page
    Given the user attempts to access the profile page
    When the user launches the URL "http://localhost:5000/"
    Then the user should be able to access the URL and be redirected to the login page

    When the user clicks the Sign In button on the Home Page
    Then the user should be able to navigate to the Home page and click on the Sign In button successfully

    When the user signs in with invalid credentials:
      | Username            | Password    |
      | madhumithaa@gmail.com | Mithaa@1234 |
    Then the user should be able to enter the Username and Password correctly

    When the user clicks on the login button
    Then the user should be redirected to the login page
