﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopApp.Infrastructure.Data.Infrastructure
{
    public static class ApplicationBuilderExtension
    {
        public static async Task<ApplicationBuilder> PrepareDataBase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;
            await RoleSeeder(services);
            await SeedAdministrator(services);

            var dataCategory = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedCategories(dataCategory);

            var dataBrand = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedBrands(dataBrand);


            return (ApplicationBuilder)app;
        }

        private static void SeedBrands(ApplicationDbContext dataBrand)
        {
            
        }

        private static void SeedCategories(ApplicationDbContext dataCategory)
        {
            if (dataCategory.Categories.Any()) 
            { 
                return;
            }
            dataCategory.Categories.AddRange(new[]
            {
                new Category
            }
        }

        private static async Task RoleSeeder(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "Administrator", "Client" };
            IdentityResult roleResult;

            foreach (var role in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);

                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        private static async Task SeedAdministrator(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (await userManager.FindByNameAsync("admin") == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.FirstName = "admin";
                user.LastName = "admin";
                user.UserName = "admin";
                user.Email = "admin@admin.com";
                user.Address = "admin address";
                user.PhoneNumber = "0888888888";
                var result = await userManager.CreateAsync
                (user, "Admin123456");

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }
    }
}
