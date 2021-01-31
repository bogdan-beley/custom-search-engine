# CustomSearchEngine
[https://customsearchengine.azurewebsites.net](https://customsearchengine.azurewebsites.net/)

CustomSearchEngine is an application that searches for user-specified words on Google and Bing search engines using their APIs. 
Top 10 search values of the result that comes first are written to the database and displayed on the page. Reply from another service is ignored.
Users have the ability to search for already saved results in the database.

## Technologies used
This pet project was designed to improve development skills using **ASP.NET Core** platform. The application architecture is based on **MVC design pattern**.

External search API clients were designed using **HttpClientFactory** and **Typed Client** approaches. They were registered using **Dependency Injection** by registering multiple implementations of an interface.

**Entity Framework Core Code-First** approach was used to connect to **MS SQL Server** database. To send and deserialize JSON data via HttpClient we used **GetFromJsonAsync**  extension method added by System.Net.Http.Json library. After receiving search results from one of the API clients, all other tasks are canceled with the help of **CancellationToken** implementation.

To add strongly typed settings to the project, **Options pattern** was implemented. This, in turn, ensures compliance with the **Separations of concerns** and **Interface segregation** principles. For security reasons, all sensitive data and secrets are stored using **User Secrets** (for the development environment) and **Azure Key Vault** (for the Production) Configuration Providers.

Finally, the project was deployed to **Azure App Service** by using GitHub **CI/CD workflow**.

## Instructions
1. `git clone https://github.com/bogdan-beley/custom-search-engine`
2. Open `CustomSearchEngine.sln` from project location.
2. Type the following commands at the commands prompt: `dotnet user-secrets init --project "<PATH>"`, replacing ***<PATH>*** by project path.
3. Use the `dotnet user-secrets set "<key>" "<value>" --project "<PATH>"` command to set user-secrets received from the author of the project, replacing ***<key>***, ***<value>***, and <PATH>. 
4. Build and run the application.

***Importantly. In order to run the project in developer mode, you must set user-secrets.***
