using Microsoft.AspNetCore.Identity;
using PPChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PPChat.Utils;
using Microsoft.EntityFrameworkCore;

namespace PPChat.Data.DataSeeds
{
    public static class AdminAndRolesSeeder
    {
        public static void SeedData(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ImageRepository imageRepository)
        {
            SeedImages(imageRepository);
            SeedRoles(roleManager);
            SeedUsers(userManager, imageRepository);

        }

        private static void SeedImages(ImageRepository imageRepository)
        {
            if (imageRepository.GetImageByName("AdminAvatar") == null)
            {
                Image image = new Image();
                image.ImageName = "AdminAvatar";
                image.Content = ImageUtils.ReadFile("wwwroot/Images/admin-avatar.png");
                imageRepository.CreateImage(image);
            }

            if (imageRepository.GetImageByName("FemaleAvatar") == null)
            {
                Image image = new Image();
                image.ImageName = "FemaleAvatar";
                image.Content = ImageUtils.ReadFile("wwwroot/Images/female-avatar.png");
                imageRepository.CreateImage(image);
            }

            if (imageRepository.GetImageByName("MaleAvatar") == null)
            {
                Image image = new Image();
                image.ImageName = "MaleAvatar";
                image.Content = ImageUtils.ReadFile("wwwroot/Images/male-avatar.png");
                imageRepository.CreateImage(image);
            }
        }

        private static void SeedUsers(UserManager<ApplicationUser> userManager, ImageRepository imageRepository)
        {
            if (userManager.FindByEmailAsync("admin@gmail").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "admin";
                user.Email = "admin@gmail.com";
                user.FirstName = "Admin";
                user.LastName = "Admin";
                user.Gender = false;
                user.Position = "Admin";
                user.PhoneNumber = "0748673115";
                user.ProfileImage = imageRepository.GetImageByName("AdminAvatar");
                IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd1!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }

            if (userManager.FindByEmailAsync("user@gmail").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "user";
                user.Email = "user@gmail.com";
                user.FirstName = "User";
                user.LastName = "User";
                user.Gender = false;
                user.Position = "User";
                user.PhoneNumber = "0748673115";
                user.ProfileImage = imageRepository.GetImageByName("MaleAvatar");
                IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd1!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "User").Wait();
                }
            }
        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
        }

    }
}
