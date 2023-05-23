# BoldBI Embedded Sample in ASP.NET MVC

 This project was generated using ASP.NET MVC version 6.0 or a later version that is installed on your system before it was compiled. This sample demonstrates the dashboard rendering with the list of dashboards available in your Bold BI server.

## Dashboard view

![Dashboard View](https://github.com/boldbi/aspnet-core-sample/assets/91586758/4af68f49-ffc0-400a-a323-55a3f3600a1d)

 ## Requirements/Prerequisites

 * [.NET Framework 6.0](https://dotnet.microsoft.com/en-us/download/dotnet-framework).

 ### Help link

 * https://help.boldbi.com/embedded-bi/faq/where-can-i-find-the-product-version/

 ### Supported browsers
  
  * Google Chrome, Microsoft Edge, Mozilla Firefox.

 ## Configuration

 * Ensure that you have enabled embed authentication on the embed settings [page](https://help.boldbi.com/embedded-bi/site-administration/embed-settings/#get-embed-configuration-file). If it is not enabled, enable it. Please refer to the below image.

    ![Embed Settings](https://github.com/boldbi/aspnet-core-sample/assets/91586758/b3a81978-9eb4-42b2-92bb-d1e2735ab007)

 * Download the embedConfig.json file by referring to this [link](https://help.boldbi.com/embedded-bi/site-administration/embed-settings/#get-embed-configuration-file). Please refer to the below image.

    ![Embed Settings Download](https://github.com/boldbi/aspnet-core-sample/assets/91586758/d27d4cfc-6a3e-4c34-975e-f5f22dea6172)
    ![EmbedConfig Properties](https://github.com/boldbi/aspnet-core-sample/assets/91586758/d6ce925a-0d4c-45d2-817e-24d6d59e0d63)

 * Copy the downloaded embedConfig.json file and place it into the following [location](https://github.com/boldbi/aspnet-mvc-sample/tree/master/Syncfusion.Server.EmbedBoldBI) of the application. Please refer to the below image.

   ![EmbedConfig image](https://github.com/boldbi/aspnet-core-sample/assets/91586758/4d7e26c7-9a58-42d8-b212-89cafc022fd6)

 ## How to run sample using command prompt 
    
  1. Open command prompt in this file [location](https://github.com/boldbi/aspnet-mvc-sample/tree/master/Syncfusion.Server.EmbedBoldBI).

  2. Execute the command `dotnet restore` to restore the necessary packages. Once the packages have been restored, use the `dotnet build` command to build the project.
  
  3. Run the application using the command `dotnet run`.

 ## Developer IDE

  * Visual studio code(https://code.visualstudio.com/download)

  ### How to run sample using visual studio code
 
  * Open the ASP.NET MVC sample in Visual Studio Code. 
   
  * Open the terminal in Visual Studio Code, You can restore the required dependencies by executing the following command in the terminal: `dotnet restore`.
 
  * You can build your .NET project by executing the `dotnet build` command in the terminal.

  * Run the application using the command `dotnet run`. After executing the command, the application will automatically launch in the default browser, accessible at the specific port number (https://localhost:5001). Please refer to the following image.
    ![dashboard image](https://github.com/boldbi/aspnet-core-sample/assets/91586758/4af68f49-ffc0-400a-a323-55a3f3600a1d)

Please refer to the [help documentation](https://help.boldbi.com/embedded-bi/javascript-based/samples/v3.3.40-or-later/asp-net-mvc/#how-to-run-the-sample) to know how to run the sample.

## Important notes

It is recommended to not store passwords and sensitive information in configuration files for security reasons, in a real-world application. Instead, you should consider using a secure application, such as Key Vault, to safeguard your credentials.

## Online demos

Look at the Bold BI Embedding sample to live demo [here](https://samples.boldbi.com/embed).

## Documentation

A complete Bold BI Embedding documentation can be found on [Bold BI Embedding Help](https://help.boldbi.com/embedded-bi/javascript-based/).