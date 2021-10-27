using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBlogFinal.Data;
using TheBlogFinal.Enums;
using TheBlogFinal.Models;

namespace TheBlogFinal.Services
{
    public class DataService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<BlogUser> _userManager;

        public DataService(ApplicationDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<BlogUser> userManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }


        public async Task ManageDataAsync()
        {
            //Task: Create the DB from the Migrations 
            await _dbContext.Database.MigrateAsync();

            // Task 1: Seed a few Roles into the system
            await SeedRolesAsync();

            // Task 2: Seed a few Users into the system
            await SeedUsersAsync();

        }

        private async Task SeedRolesAsync()
        {
            //If there are already Roles in the system, do nothing.
            if (_dbContext.Roles.Any())
            {
                return;
            }

            //Otherwise we want to create a few Roles
            foreach(var role in Enum.GetNames(typeof(BlogRole)))
            {
                //I need to use the Role Manager to create roles
                await _roleManager.CreateAsync(new IdentityRole(role)); // creates roles 
            }

        }

        private async Task SeedUsersAsync()
        {

            

            //If there are already Users in the system, do nothing.
            if (_dbContext.Users.Any())
            {
                return;
            }

            //Step 1: Creates a new instance of BlogUser
            var adminUser = new BlogUser()
            {
                
                Email = "umut.tuerk@gmx.at",
                UserName = "umut.tuerk@gmx.at",
                FirstName = "Umut",
                LastName = "Türk",
                DisplayName = "The Admin",
                PhoneNumber = "0660 / 2900070",
                EmailConfirmed = true
            };

            //Step 2: Use the UserManager to create a new user that is defined by the adminUser variable.
            await _userManager.CreateAsync(adminUser, "Test711010!");

            //Step 3: Add this new user to the Administrator role
            await _userManager.AddToRoleAsync(adminUser, BlogRole.Administrator.ToString());


            //Step 1 repeat: Create the moderator user
            var modUser = new BlogUser()
            {
                
                Email = "umut1tr@hotmail.com",
                UserName = "umut1tr@hotmail.com",
                FirstName = "UmutMod",
                LastName = "TürkMod",
                DisplayName = "The Mod",
                PhoneNumber = "0660 / 2900070",
                EmailConfirmed = true
            };

            await _userManager.CreateAsync(modUser, "Test711010!");

            await _userManager.AddToRoleAsync(modUser, BlogRole.Moderator.ToString());

        }
        
    }
}
