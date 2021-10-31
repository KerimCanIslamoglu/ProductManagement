### Tech Stack

- C#, .Net Core 5.0, Entity Framework Core, Code First, MSSQL,  NUnit, Swagger

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


