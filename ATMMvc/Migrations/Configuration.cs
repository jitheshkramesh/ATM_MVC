namespace ATMMvc.Migrations
{
    using ATMMvc.Models;
    using ATMMvc.Services;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ATMMvc.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "ATMMvc.Models.ApplicationDbContext";
        }

        protected override void Seed(ATMMvc.Models.ApplicationDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (!context.Users.Any(t => t.UserName == "admin@dharasoft.com")) {
                var user = new ApplicationUser { UserName = "admin@dharasoft.com", Email = "admin@dharasoft.com" };
                userManager.Create(user, "pAssw0rd!");
                var service = new CheckingAccountService(context);
                service.CreateCheckingAccount("admin", "user", user.Id, 1000);

                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "Admin" });
                context.SaveChanges();
                userManager.AddToRole(user.Id, "Admin");
            }

            //context.Transactions.Add(new Transaction { Amount = -300, CheckingAccountId = 1 });
            //context.Transactions.Add(new Transaction { Amount = 300, CheckingAccountId = 1 });
            //context.Transactions.Add(new Transaction { Amount = -1300.45m, CheckingAccountId = 1 });
            //context.Transactions.Add(new Transaction { Amount = 2500, CheckingAccountId = 1 });
            //context.Transactions.Add(new Transaction { Amount = -3500, CheckingAccountId = 1 });
            //context.Transactions.Add(new Transaction { Amount = 75000, CheckingAccountId = 1 });
            //context.Transactions.Add(new Transaction { Amount = 9800.50m, CheckingAccountId = 1 });
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
