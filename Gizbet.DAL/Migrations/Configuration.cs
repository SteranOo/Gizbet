using System.Collections.Generic;
using System.Configuration;
using Gizbet.DAL.EF;
using Gizbet.DAL.Entities;
using Gizbet.DAL.Entities.Identity;
using Gizbet.DAL.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Gizbet.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Gizbet.DAL.EF.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Gizbet.DAL.EF.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
           //var categories = new List<Category>
           // {
           //     new Category {Name = "�����������"},
           //     new Category {Name = "����"},
           //     new Category {Name = "�����"},
           //     new Category {Name = "���"},
           //     new Category {Name = "������"},
           //     new Category {Name = "�����"},
           //     new Category {Name = "������"}
           // };

           // var roles = new List<ApplicationRole>
           // {
           //     new ApplicationRole {Name= "Administrator"},
           //     new ApplicationRole {Name= "User"}
           // };

           // ApplicationUserManager aum = new ApplicationUserManager(
           //      new UserStore<ApplicationUser,
           //          ApplicationRole,
           //          int, ApplicationUserLogin,
           //          ApplicationUserRole,
           //          ApplicationUserClaim>(context));

           // ApplicationRoleManager arm = new ApplicationRoleManager(
           //         new RoleStore<ApplicationRole, int, ApplicationUserRole>(context));

           // string adminLogin = ConfigurationManager.AppSettings["adminLogin"];
           // string adminPassword = ConfigurationManager.AppSettings["adminPassword"];

           // ApplicationUser admin = new ApplicationUser
           // {
           //     UserName = adminLogin
           // };

           // if (context.Users.FirstOrDefault(u => u.UserName == adminLogin) == null)
           // {
           //     aum.Create(admin, adminPassword);
           //     aum.AddToRole(admin.Id, "Administrator");
           // }

           // ApplicationUser user = new ApplicationUser
           // {
           //     FirstName = "�����",
           //     LastName = "������",
           //     Patronymic = "���������",
           //     Email = "denisknyazev96@gmail.com",
           //     UserName = "denis",
           //     PhoneNumber = "+380660214808",
           //     DateOfBirth = DateTime.Parse("07.06.1996")
           // };

           // ApplicationUser user2 = new ApplicationUser
           // {
           //     FirstName = "�����",
           //     LastName = "��������",
           //     Patronymic = "����������",
           //     Email = "denis_knyazev_96@mail.ru",
           //     UserName = "mary",
           //     PhoneNumber = "+380887679681",
           //     DateOfBirth = DateTime.Parse("09.12.1995")
           // };

           // if (context.Users.FirstOrDefault(u => u.UserName == "denis") == null)
           // {
           //     aum.Create(user, "123456");
           //     aum.AddToRole(user.Id, "User");
           // }

           // if (context.Users.FirstOrDefault(u => u.UserName == "mary") == null)
           // {
           //     aum.Create(user2, "123456");
           //     aum.AddToRole(user2.Id, "User");
           // }

           // var lots = new List<Lot>
           // {
           //   new Lot
           //   {
           //       Category = context.Categories.First(c => c.Name == "�����������"),
           //       Name = "��������� ������� Lenovo A319",
           //       Description = "������������ � ��������� �������� Lenovo A319 White ����� �������������� �������������� ��� ������������� ������, ��������� ������� ��� ����������� ���. ���������� Dolby Digital Plus ������ ���� ����� ����������, �������� � ������������, � �������� ��������� �����, ��� � ����������� ����������� ���������, ������������ ������ � ���������.",
           //       InitialPrice = 2000,
           //       Step = 50,
           //       Owner = context.Users.First(u => u.UserName == "denis"),
           //       IsSold = false,
           //       IsSelling = true,
           //       SellingPrice = 3000,
           //       HoursDuration = 48,
           //       TimeOfPosting = DateTime.Now,
           //       ImagePath = "Lenovo-A319.jpg"
           //   },
           //   new Lot
           //   {
           //       Category = context.Categories.First(c => c.Name == "�����������"),
           //       Name = "������� Lenovo IdeaTab A3300 7 3G 8GB Black",
           //       Description = "������� �������� ���������� ���� � ���������� ������� Lenovo IdeaTab A3300 7 3G 8GB Black (59426392). �� �������� �� ����������� ���������� ���, ������� ����� ������ �������������� ����. ��� ������� ������� 1300 ��� ����� ����� ��� ���������� �� ������ ��� ������� ������ �������� � ��������������� ����� �������� ��������.",
           //       InitialPrice = 3300,
           //       Step = 75,
           //       Owner = context.Users.First(u => u.UserName == "mary"),
           //       IsSold = false,
           //       IsSelling = true,
           //       SellingPrice = 4700,
           //       HoursDuration = 36,
           //       TimeOfPosting = DateTime.Now,
           //       ImagePath = "lenovo_a3300.jpg"
           //   }
           // };

           // var bids = new List<Bid>
           // {
           //     new Bid
           //     {
           //        ApplicationUser = context.Users.First(u => u.UserName == "denis"),
           //        Lot = context.Lots.First(l => l.Name == "������� Lenovo IdeaTab A3300 7 3G 8GB Black"),
           //        TimeOfBid = DateTime.Now,
           //        Amount = 3375
           //     },
           //     new Bid
           //     {
           //        ApplicationUser = context.Users.First(u => u.UserName == "mary"),
           //        Lot = context.Lots.First(l => l.Name == "��������� ������� Lenovo A319"),
           //        TimeOfBid = DateTime.Now,
           //        Amount = 2050
           //     }
           // };

           // context.Categories.AddOrUpdate(c => c.Name, categories.ToArray());
           // context.Roles.AddOrUpdate(r => r.Name, roles.ToArray());
           // context.Lots.AddOrUpdate(l => l.Name, lots.ToArray());
           // context.Bids.AddOrUpdate(bids.ToArray());
        }
    }
}
