# EPAM Test Task

## About
This repository contains the EPAM Systems challenge, divided into three parts:
1. Creation of manual test scenarios
2. Creation of database queries with MS SQL
3. Creation of automated tests

The SQL code and manual tests are available in the "Test Task - SQL and High Level Tests.pdf" file. 
The automated tests were developed using the Playwright framework with the C# stack, covering both API and UI testing.

## How to Install

1. Clone the project:

   ```bash
   git clone https://github.com/vitorc/TestTask.git
   ```

2. Navigate to the "TestTask" directory:

   ```bash
   cd TestTask
   ```

3. Open Visual Studio and select the "StudGroups.sln" file.

4. Install the following packages:
   - Microsoft.Playwright
   - Microsoft.Playwright.NUnit
   - Microsoft.Playwright.TestAdapter

5. Build the project.

## Project Structure
The project is organized into one main folder and two subfolders.

- The "Test" folder serves as the main directory for running tests. Within this folder:
  - The "API" subfolder contains all API automation tests.
  - The "UI" subfolder contains all UI automation tests.

## Contact
- Linkedin: [Vitor Cardoso](https://www.linkedin.com/in/vitor-cardoso-)
- E-mail: `scardosovitor@gmail.com`
