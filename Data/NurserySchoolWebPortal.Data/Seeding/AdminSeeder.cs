namespace NurserySchoolWebPortal.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using NurserySchoolWebPortal.Data.Models;

    using static NurserySchoolWebPortal.Common.GlobalConstants;

    public class AdminSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
            var isAdminExists = await userManager.FindByNameAsync(AdminFirstName);

            if (isAdminExists != null)
            {
                return;
            }

            var admin = new ApplicationUser
            {
                UserName = AdminEmail,
                FirstName = AdminFirstName,
                LastName = AdminLastName,
                Email = AdminEmail,
                DateOfBirth = new DateTime(1997, 3, 17),
                Gender = Gender.Male,
            };

            var result = await userManager.CreateAsync(admin, AdminPassword);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, AdministratorRoleName);
            }
        }
    }
}
