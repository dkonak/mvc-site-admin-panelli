using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace OrnekSite.Identity
{
    public class Identitylnitializer:CreateDatabaseIfNotExists<IdentityDataContext>    //veritabanı yoksa yeni bir veritabanı oluştur
    {
        protected override void Seed(IdentityDataContext context) //admin veya user belirleme
        {
            if (!context.Roles.Any(i=>i.Name=="admin")) // admin rolü oluşturuldu
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "admin", Description = "admin rolü" };
                manager.Create(role);

            }
            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "user", Description = "user rolü" };
                manager.Create(role);

            }
            if (!context.Users.Any(i => i.Name == "devrimkonak"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() {Name="devrim" ,Surname="konak" ,UserName="devrimkonak" ,Email="dkonak@gmail.com"};
                manager.Create(user, "123456"); //şifre
                manager.AddToRole(user.Id, "admin"); // rolü admin mi kullanıcı mı onu belirtiyor
                manager.AddToRole(user.Id, "user");

            }
            if (!context.Users.Any(i => i.Name == "bilalkonak"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "bilal", Surname = "konak", UserName = "bilalkonak", Email = "bilalkonak@gmail.com" };
                manager.Create(user, "123456"); 
                manager.AddToRole(user.Id, "user");

            }
            base.Seed(context);
        }

    }
}