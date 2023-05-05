# BoldBI Embedding ASP.NET MVC Samples

 This sample demonstrates the dashboard rendering with the list of dashboards available in your Bold BI server.

This section guides you in using the Bold BI dashboard in your ASP.NET MVC sample application.

 * [Requirements to run the demo](#requirements-to-run-the-demo)
 * [Using the ASP.NET MVC sample](#using-the-asp.net-mvc-samples)
 * [Online Demos](#online-demos)
 * [Documentation](#documentation)

 ## Requirements to run the demo

The samples require the following requirements to run.

 * [Visual Studio Code](https://code.visualstudio.com/download)
 * [.NET Framework 4.8](https://dotnet.microsoft.com/en-us/download/dotnet-framework)

 ## Using the ASP.NET MVC sample
 
* Open the ASP.NET MVC sample in Visual Studio Code.

 * This [link](https://help.boldbi.com/cloud-bi/site-administration/embed-settings/) using able to download the embedConfig.json file. 
 
 * Copy the downloaded embedConfig.json file and paste it into the sample [application](https://github.com/boldbi/aspnet-core-sample/tree/master/BoldBI.Embed.Sample/BoldBI.Embed.Sample).
 
 * The following properties are used in `embedConfig.json` file:

<meta charset="utf-8"/>
<table>
  <tbody>
    <tr>
        <td align="left">ServerUrl</td>
        <td align="left">Dashboard Server URL (Eg: http://localhost:5000/bi, http://demo.boldbi.com/bi).</td>
    </tr>
    <tr>
        <td align="left">EmbedSecret</td>
        <td align="left">Get your EmbedSecret key from the Embed tab by enabling the `Enable embed authentication` on the Administration page https://help.boldbi.com/embedded-bi/site-administration/embed-settings/.</td>
    </tr>
    <tr>
        <td align="left">SiteIdentifier</td>
        <td align="left">For the Bold BI Enterprise edition, it should be like `site/site1`. For Bold BI Cloud, it should be an empty string.</td>
    </tr>
    <tr>
        <td align="left">Environment</td>
        <td align="left">Your Bold BI application environment. (If Cloud, you should use `cloud,` if Enterprise, you should use `enterprise`).</td>
    </tr>
    <tr>
        <td align="left">UserEmail</td>
        <td align="left">UserEmail of the Admin in your Bold BI, which would be used to get the dashboard list.</td>
    </tr>
    <tr>
        <td align="left">DashboardId</td>
        <td align="left">Item id of the dashboard to be embedded in your application.</td>
    </tr>
    <tr>
        <td align="left">EmbedType</td>
        <td align="left">BoldBI.EmbedType.Component.</td>
    </tr>
    <tr>
        <td align="left">ExpirationTime</td>
        <td align="left">Token expiration time.</td>
    </tr>
  </tbody>
</table>

 * Run the application.


Please refer to the [help documentation](https://help.boldbi.com/embedded-bi/javascript-based/samples/v3.3.40-or-later/asp-net-mvc/#how-to-run-the-sample) to know how to run the sample.

## Online Demos

Look at the Bold BI Embedding sample to live demo [here](https://samples.boldbi.com/embed).

## Documentation

A complete Bold BI Embedding documentation can be found on [Bold BI Embedding Help](https://help.boldbi.com/embedded-bi/javascript-based/).

> NOTE:  To mitigate issues related to NuGet packages, run the following command in package manager console Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r.