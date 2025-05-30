Issue I faced while creating the Blazor App in the dot-net 9.
We have to write @rendermode InteractiveServer in the component file.

Steps to create the Blazor App with Dotnet 9:
1) Created the BalzorWebApp Project from the visual studio named 'SimpleBookCatelog'.
2) Created the SimpleBookCatelog.Infrastructure class Library for
     a) DbContext : This Folder contains the AppDbContext file.

     b) Repositories : This Folder contains the Repositories in the Project Ex(BookRepository)

3) Created the SimpleBookCatelog.Domain file for
      a) DTO :  contains the BookDTO class to transfer data from Entity Model.
      b) Entities :  contains the Entity Model Ex(Book).
      c) Enums :  contains the Enums of the Whole Project.

4) Created the SimpleBookCatelog.Application file for
    a) Interfaces : contains the Interfaces to achieve Loose coupling in the Project

5) Injected the Dependency in the Prog.cs file.

6) Created the Database schema for the Book with properties (ID,Title,Author,PublicatiDate,Category,Created_at_date,Updated_at_date,removed_at).
7) Applied the scaffold command to Create the Entity Model(Book) :
      command --> dotnet ef dbcontext scaffold "Host=localhost;Port=5432;Database=BookBlazorApp;Username=postgres;Password=root" Npgsql.EntityFrameworkCore.PostgreSQL -o Models --context AppDbContext --context-dir Data --                                  force

8) Created the component in the Project :
       a)AddNew.razor b)GetAll.razor c)UpdateBook.razor d)Bookform.razor e)DeleteConfirm.razor
        
9) Added the database csv file in the branch
