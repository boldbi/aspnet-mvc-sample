# Bold BI Embedded Sample in .NET MVC

This project was created using ASP.NET MVC 4.8.1. The purpose of this application is to demonstrate how to render the dashboard available on your Bold BI server.

## Dashboard view

![Dashboard View](https://github.com/boldbi/aspnet-core-sample/assets/91586758/4af68f49-ffc0-400a-a323-55a3f3600a1d)

 ## Requirements/Prerequisites

 * [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/)
 * [.NET Framework 4.8.1](https://dotnet.microsoft.com/en-us/download/dotnet-framework)

 #### Help link

 * https://help.boldbi.com/embedded-bi/faq/where-can-i-find-the-product-version/

 #### Supported browsers
  
  * Google Chrome, Microsoft Edge, Mozilla Firefox.

 ## Configuration

 * Please ensure that you have enabled embed authentication on the `embed settings` page. If it is not currently enabled, please refer to the following image or detailed [instructions](https://help.boldbi.com/site-administration/embed-settings/#get-embed-secret-code) to enable it.

    ![Embed Settings](https://github.com/boldbi/aspnet-core-sample/assets/91586758/b3a81978-9eb4-42b2-92bb-d1e2735ab007)

 * To download the `embedConfig.json` file, please follow this [link](https://help.boldbi.com/site-administration/embed-settings/#get-embed-configuration-file) for reference. Additionally, you can refer to the following image for visual guidance.

    ![Embed Settings Download](https://github.com/boldbi/aspnet-core-sample/assets/91586758/d27d4cfc-6a3e-4c34-975e-f5f22dea6172)
    ![EmbedConfig Properties](https://github.com/boldbi/aspnet-core-sample/assets/91586758/d6ce925a-0d4c-45d2-817e-24d6d59e0d63)

 * Copy the downloaded `embedConfig.json` file and paste it into the designated [location](https://github.com/boldbi/aspnet-mvc-sample/tree/master/BoldBI.Embed.Sample) within the application. Please ensure that you have placed it in the application as shown in the following image.

   ![EmbedConfig image](https://github.com/boldbi/aspnet-mvc-sample/assets/91586758/f3283ddb-f74d-4275-8f1b-41223b0d034a)

 ## Developer IDE

  * Visual studio 2022(https://visualstudio.microsoft.com/downloads/)

 ### Run a Sample Using Visual Studio 2022
 
  * Open the solution file `BoldBI.Embed.Sample.sln` in Visual Studio.

  * Run your ASP.NET MVC sample. After running a sample, the application will automatically launch in the default browser. You can access it at the specified port number (e.g., https://localhost:5001/).

    ![dashboard image](https://github.com/boldbi/aspnet-core-sample/assets/91586758/4af68f49-ffc0-400a-a323-55a3f3600a1d)

Please refer to the [help documentation](https://help.boldbi.com/embedding-options/embedding-sdk/samples/asp-net-mvc/#how-to-run-the-sample) to know how to run the sample.

## Important notes

It is recommended to not store passwords and sensitive information in configuration files for security reasons, in a real-world application. Instead, you should consider using a secure application, such as Key Vault, to safeguard your credentials.

## Online demos

Look at the Bold BI Embedding sample to live demo [here](https://samples.boldbi.com/embed).

## Documentation

A complete Bold BI Embedding documentation can be found on [Bold BI Embedding Help](https://help.boldbi.com/embedded-bi/javascript-based/).