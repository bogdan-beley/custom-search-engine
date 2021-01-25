# CustomSearchEngine
[https://customsearchengine.azurewebsites.net](https://customsearchengine.azurewebsites.net/)

CustomSearchEngine is an application that searches for user-specified words on Google and Bing search engines using their APIs. 
Top 10 search values of the result that comes first are written to the database and displayed on the page. Reply from another service is ignored.
Users have the ability to search for already saved results in the database.

## Technologies used
This pet project was designed to improve development skills using **ASP.NET Core** platform. The application architecture is based on **MVC pattern**.

External search API clients were designed using **HttpClientFactory** and **Typed Client** approaches. They were registered using **Dependency Injection** by registering multiple implementations of an interface.

...
