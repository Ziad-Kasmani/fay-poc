# ASP.NET Identity Configuration

This repository demonstrates how to configure ASP.NET Core Identity.

## Setup

1. Install packages:
   ```bash
   dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
   dotnet add package Microsoft.EntityFrameworkCore.SqlServer
   dotnet add package Microsoft.EntityFrameworkCore.Tools
   ```

2. Create ApplicationDbContext:

   ```csharp
   using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
   using Microsoft.EntityFrameworkCore;

   public class ApplicationDbContext : IdentityDbContext
   {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options) {}
   }
   ```

3. Update `Program.cs`:

   ```csharp
   using Microsoft.AspNetCore.Identity;
   using Microsoft.EntityFrameworkCore;

   var builder = WebApplication.CreateBuilder(args);

   builder.Services.AddDbContext<ApplicationDbContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

   builder.Services.AddIdentity<IdentityUser, IdentityRole>()
       .AddEntityFrameworkStores<ApplicationDbContext>()
       .AddDefaultTokenProviders();

   var app = builder.Build();

   app.UseAuthentication();
   app.UseAuthorization();
   ```

4. Configure connection string in `appsettings.json`:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=AspNetCoreIdentity;Trusted_Connection=True;MultipleActiveResultSets=true"
     }
   }
   ```

5. Apply migrations:

   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

These steps add ASP.NET Core Identity to your application.
