# Books API

### NuGet packages 
- Microsoft.EntityFrameworkCore
- MySql.EntityFrameworkCore.

### Technical Information
This is ASP.NET Core Web API project. In this project I used Code-First approach with help of Entity Framework. For manipulating with database, I have a [LibraryContext](./BooksApp/Contexts/LibraryContext.cs) class which inherit from DbContext in order to connect to my database. 
For [models](./BooksApp/Models/DatabaseModels) was created Repositories to access data in tables. All repositories are implementing generic [IRepository](./BooksApp/Repositories/IRepository.cs) interface.
In Propram.cs I used Dependency Injection with BookContext and BookRepository.
