# FileDownloader_AppClient

FileDownloader_AppClient is a .Net standalone program that downloads files that contains a web page. This program runs just in windows OS.

## Introduction
This a challenge that tries to download all files of any extension provided by an url resource. 

The solution is divided in 3 business layers: 

1. Common Actions: Methods that occasionally are recurring actions.
2. WPF UI componentes: Interacts with the user.
3. Service Download API: Is in charge for downloads matters.


## Tecnology
It's based in Dotnet 6 WPF forms. Uses 2 library class projects and Json files for config entries.
Use a SOLID design pattern.

## Installation

Open the MainFormWPF.exe located in "bin\Release\net6.0-windows\publish".

## For Debugging purpose

Open the main solution FileDownloader_AppClient.sln. Make sure that MainFormWPF project is marked as initial project for solution.

## User Guide

At the main frame click on Settings Button. Then appears a second frame with a text box. To set a desktop local path change the text box value and click on Save Button, That value is where the downloaded files will appears.

Finally return to the main frame and fill the blanc spot for url y press Transmit Button.

Wait until the progress bar is completed.

Navigate to the download's destination path, you will notice the files and an info file called "DownloadDetailInfo". This file contains a detailed information of each file in that directory.

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.
