using Aga.DataAccess;
using Aga.DataAccess.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aga.ApiPlusAngular.Helper
{
    public class SeederDatabase
    {
        public static void SeedData(IServiceProvider services,
        IWebHostEnvironment env,
        IConfiguration config)
        {
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var manager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var managerRole = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var context = scope.ServiceProvider.GetRequiredService<EFContext>();
                SeedUsers(manager, managerRole);
            }
        }
        private static void SeedUsers(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var roleName = "Admin";
            if (roleManager.FindByNameAsync(roleName).Result == null)
            {
                var resultAdminRole = roleManager.CreateAsync(new IdentityRole
                {
                    Name = "Admin"
                }).Result;
            }

             roleName = "Student";
            if (roleManager.FindByNameAsync(roleName).Result == null)
            {
                var resultStudentRole = roleManager.CreateAsync(new IdentityRole
                {
                    Name = "Student"
                }).Result;
            }

            roleName = "Teacher";
            if (roleManager.FindByNameAsync(roleName).Result == null)
            {
                var resultTeacherRole = roleManager.CreateAsync(new IdentityRole
                {
                    Name = "Teacher"
                }).Result;
            }




            string email = "admin@gmail.com";
            var admin = new User
            {
                Email = email,
                UserName = email,
                Adress = "Rivne",
                Age = "30",
                Fullname = "Full name of admin"
            };

            email = "student@gmail.com";
            var student = new User
            {
                Email = email,
                UserName = email,
                Adress = "Rivne",
                Age = "15",
                Fullname = "Aga dobre"
            };

            email = "teacher@gmail.com";
            var teacher = new User
            {
                Email = email,
                UserName = email,
                Adress = "Rivne",
                Age = "20",
                Fullname = "Aga dobre"
            };
            var resultStudent = userManager.CreateAsync(student, "Qwerty-1").Result;
            resultStudent = userManager.AddToRoleAsync(student, "Student").Result;

            var resultTeacher = userManager.CreateAsync(teacher, "Qwerty-1").Result;
            resultTeacher = userManager.AddToRoleAsync(teacher, "Teacher").Result;

            var resultAdmin = userManager.CreateAsync(admin, "Qwerty1-").Result;
            resultAdmin = userManager.AddToRoleAsync(admin, "Admin").Result;
        }
    }
}