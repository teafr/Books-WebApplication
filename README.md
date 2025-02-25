# Books API

### NuGet packages 
- Microsoft.EntityFrameworkCore
- MySql.EntityFrameworkCore.

### Technical Information
This is ASP.NET Core Web API project. In this project I used Code-First approach with help of Entity Framework. For manipulating with database, I have a [LibraryContext](./we-api-for-books-app/Contexts/LibraryContext.cs) class in order to connect to my database. 
For [models](./web-api-for-books-app/Models/) was created Repositories to access data in tables. All repositories inherit from generic [IRepository](./web-api-for-books-app/Repositories
/IRepository.cs) interface.
In Propram.cs I used Dependency Injection with BookContext and BookRepository.
