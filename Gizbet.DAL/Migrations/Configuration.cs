using System.Collections.Generic;
using System.Configuration;
using Gizbet.DAL.EF;
using Gizbet.DAL.Entities;
using Gizbet.DAL.Entities.Identity;
using Gizbet.DAL.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Gizbet.DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Gizbet.DAL.EF.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var categories = new List<Category>
            {
                new Category {Name = "Электроника"},
                new Category {Name = "Авто"},
                new Category {Name = "Спорт"},
                new Category {Name = "Дом"},
                new Category {Name = "Мебель"},
                new Category {Name = "Книги"},
                new Category {Name = "Разное"}
            };

            var roles = new List<ApplicationRole>
            {
                new ApplicationRole {Name= "Administrator"},
                new ApplicationRole {Name= "User"}
            };

            ApplicationUserManager aum = new ApplicationUserManager(
                 new UserStore<ApplicationUser,
                     ApplicationRole,
                     int, ApplicationUserLogin,
                     ApplicationUserRole,
                     ApplicationUserClaim>(context));

            ApplicationRoleManager arm = new ApplicationRoleManager(
                    new RoleStore<ApplicationRole, int, ApplicationUserRole>(context));

            string adminLogin = ConfigurationManager.AppSettings["adminLogin"];
            string adminPassword = ConfigurationManager.AppSettings["adminPassword"];

            ApplicationUser admin = new ApplicationUser
            {
                UserName = adminLogin
            };

            if (context.Users.FirstOrDefault(u => u.UserName == adminLogin) == null)
            {
                aum.Create(admin, adminPassword);
                aum.AddToRole(admin.Id, "Administrator");
            }
            
            context.Categories.AddOrUpdate(c => c.Name, categories.ToArray());
            context.Roles.AddOrUpdate(r => r.Name, roles.ToArray());
           
        }
    }
}
