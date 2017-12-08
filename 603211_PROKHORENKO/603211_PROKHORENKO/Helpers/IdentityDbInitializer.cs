﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using _603211_PROKHORENKO.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using System.Data.Entity;



namespace _603211_PROKHORENKO.Helpers
{
    //public class IdentityDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext> //либо это с Seed
    public class IdentityDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>  //либо это
    //public class IdentityDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            // Создаем менеджеры ролей и пользователей
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            IdentityRole roleAdmin, roleUser = null;
            ApplicationUser userAdmin = null;

            // поиск роли admin
            roleAdmin = roleManager.FindByName("admin");
            if (roleAdmin == null)
            {
                // создаем, если на нашли
                roleAdmin = new IdentityRole { Name = "admin" };
                var result = roleManager.Create(roleAdmin);
            }

            // поиск роли user
            roleUser = roleManager.FindByName("user");
            if (roleUser == null)
            {
                // создаем, если на нашли
                roleUser = new IdentityRole { Name = "user" };
                var result = roleManager.Create(roleUser);
            }

            // поиск пользователя admin@mail.ru
            userAdmin = userManager.FindByEmail("admin@mail.ru");
            if (userAdmin == null)
            {
                // создаем, если на нашли
                userAdmin = new ApplicationUser
                {
                    NickName = "admin",
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };
                userManager.Create(userAdmin, "111111");
                // добавляем к роли admin
                userManager.AddToRole(userAdmin.Id, "admin");
            }
        }
    }
}