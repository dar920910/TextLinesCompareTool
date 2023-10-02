# :mag_right: Text Lines Compare Tool

:pushpin: Currently, the project is included to my summary repository of demo projects:

:link: [Demo Projects Workshop 2023+](https://github.com/dar920910/Demo-Projects-Workshop)

---

## :sound: About the Project History

This project implements a tool for comparing content of several text files:

- Finding common text content for several text files
- Finding unique text content from every text file
- Smart parsing text files: trimming whitespaces, excluding string comments and etc.

I created this software in 2021 as the first project when my internship in the [D-Series](https://imaginecommunications.com/product/d-series/) commercial project as C++ software engineer intern.

The tool was intended to parse content of source files of the build system for large legacy C/C++ code base for D-Series automation server to planned migration from Makefiles to CMake.

Currently I fully **ported** this tool from C++/CMake/GoogleTest tech stack to to C#/MSBuild/NUnit tech stack.

## :question: About the Repository Structure

This repository contains the following projects:

- **TextLinesComparing.Library** - implements the .NET class library for the project
- **TextLinesComparing.Testing** - implements NUnit-based unit tests for the project
- **TextLinesComparing.App.CLI** - implements the console application for the project
- **TextLinesComparing.App.Web** - implements the ASP.NET Core Razor Pages web application for the project

The repository also contains example files to testing the app:

- Examples/agile-spam
- Examples/comments
- Examples/lorem-ipsum
- Examples/my-tests

---

## :beginner: Quick Start

### :globe_with_meridians: Using Project's Web Application

1. Run the web application via Docker (see the "Run via Docker" section below).
2. Open either <https://localhost:5002> or <http://localhost:5001> URL in your web browser.
3. Upload several text files (minimal count is 2, maximum count is 9) and execute analysis these files.
4. Investigate results of comparing content of uploaded files on app's web page.

### :computer: Using Project's Console Application

1. Run the program from the command-line to create the configuration default template when the first launching.
2. Open the generated **config.xml** file from the appeared the **storage** folder in your favorite text editor.
3. Create your own description to generate custom file objects. See the "Reference" section below to get help.
4. Run the program after configuration creating is finished. Your generated files are in the **storage/out** directory.

You should pass command-line arguments to successfully run the program.

Use the following format of the command:

    <EXECUTABLE> [OPTIONAL_PARAMETERS] <SOURCE_FILES...>

**Possible Parameters:**

**--output-file**
This parameter adds output of results to a text file.

**--output-web**
This parameter adds output of results to a web page.

**Command Examples:**

**Example 1:** Parse two text files (only console output of results):

    dotnet run ./source_1.txt ./source_2.txt

**Example 2:** Parse three text files and output of results to console and a text file:

    dotnet run --output-file ./source_1.txt ./source_2.txt ./source_3.txt

**Example 3:** Parse three text files and output of results to console and a HTML document:

    dotnet run --output-web ./source_1.txt ./source_2.txt ./source_3.txt

**Example 4:** Parse five text files and output of results to console, a text file, and a HTML document (this example use executable file name instead of **dotnet run** command):

    TextLinesComparing.App.CLI --output-file --output-web./source_1.txt ./source_2.txt ./source_3.txt ./source_4.txt ./source_5.txt

---

## :whale: Run via Docker

1. Run the **Create-DevCert-HTTPS.ps1** to generate a certificate for this application.
2. Build app's Docker image via **Execute-DockerBuild.ps1** script.
3. Run the app from a new container:
   - Use **Execute-DockerRun-AppWeb.ps1** script to launch the web application.
   - Use **Execute-DockerRun.ps1** script to investigate app's Docker container.

---

## :wrench: Build Source Code

Use **.NET 6 SDK** to build this project from source code.

---

## :email: Contribute the Project

[You can contact me using any contacts from my profile page](https://github.com/dar920910#speech_balloon-how-can-you-contact-with-me-)
