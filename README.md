### About
- This project is built for simulate the basic functions of Product, Order and Campaign domains on a e-commerce platform.


### Tech Stack

- C#, .Net 5.0, Entity Framework Core, Code First, MSSQL,  NUnit, Swagger

### Requirements

- .Net 5.0 and Sql Server must be installed on your machine.

### For starter

-   Before you get started please change the connection string in the following directory;
ProductManagement.DataAccess -> Context -> ApplicationDbContext

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           //change here.
		   optionsBuilder.UseSqlServer(@"Server=MSI\MSSQLSERVER14;Database=ProductManagementDb;Trusted_Connection=True;");  
        }

- The database and the tables would be created on application start.
- The time parameter would be seeded to the database on application start.
- In order to simulate the scenarios, you have to set  multiple start project on solution explorer properties. The projects are ProductManagement.Api and ProductManagement.Scenario



