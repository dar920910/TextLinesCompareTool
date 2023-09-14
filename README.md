# TextLinesCompareTool

## About the Project

This project implements a tool for comparing content of several text files:

- Finding common text content for several text files
- Finding unique text content from evet text file
- Smart parsing text files: trimming whitespaces, excluding string comments and etc.

## About the Repository Structure

This repository contains the following projects:

- "TextLinesComparing.Library"
- "TextLinesComparing.Testing"
- "TextLinesComparing.App.CLI"
- "TextLinesComparing.App.Web"

The repository also contains example files to testing the app:

- Examples/agile-spam
- Examples/comments
- Examples/lorem-ipsum
- Examples/my-tests

## Prerequisites

Use **.NET 6 SDK** to build the project from source code.

## Deployment

1. Build app's Docker image via **Execute-DockerBuild.ps1** script.
2. Run the app from a new container via **Execute-DockerRun.ps1** script.
