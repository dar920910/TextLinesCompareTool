# SendCodeLinesExplorer

This is a project for experiments with parsing data from files.

## Prerequisites:

This project was built via CMake and tested on the following platforms:

* **Linux**: CentOS 8 Stream x64 (GNU GCC 8.5.0, Unix Makefiles as CMake build generator)
* **Windows**: Windows 10/11 Pro x64 (TDM GCC 10.3.0, MinGW Makefiles as CMake build generator)

Currently, building the project via other build tools is not guaranteed.

You should install CMake 3.15 and later version to build this project with success.

## Build, Run and Test the Application:

* *Linux (GNU GCC)*:

1. Build the project via **unix-app-build.bash** script.
2. Run the application via **unix-app-run.bash** script.
3. Launch unit tests via **unix-app-test.bash** script.

* *Windows (MinGW)*:

1. Build the project via **windows-mingw-app-build.bash** script.
2. Run the application via **windows-mingw-app-run.bash** script.
3. Launch unit tests via **windows-mingw-app-test.bash** script.

## Deploy the Project into Linux container via Docker:

Before deployment, you should install PowerShell and Docker on your Windows host.

1. Build the application with all its dependencies via **windows-docker-app-build.ps1** script.
2. Run the application into Docker container via **windows-docker-app-run.ps1** script.

## Explore Demo Examples:

Launch any **appdemo**-script from available scripts to learn how this app works.
Use Git Bash to execute these scripts if you plan to run examples on Windows.