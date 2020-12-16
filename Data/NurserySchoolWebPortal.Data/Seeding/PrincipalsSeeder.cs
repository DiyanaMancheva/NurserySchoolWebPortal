namespace NurserySchoolWebPortal.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    using NurserySchoolWebPortal.Data.Models;

    using static NurserySchoolWebPortal.Common.GlobalConstants;

    public class PrincipalsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Principals.Any())
            {
                return;
            }


            var principal1 = new ApplicationUser
            {
                FirstName = "Svetlana",
                LastName = "Dimitrova",
                Gender = Gender.Female,
                DateOfBirth = new DateTime(1972, 1, 12),
                UserType = Models.Enums.UserType.Principal,
                Email = "principal.one@abv.bg",
                UserName = "principal.one@abv.bg",
            };

            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
            var isPrincipalExists = await userManager.FindByNameAsync(principal1.FirstName);

            if (isPrincipalExists != null)
            {
                return;
            }

            var result = await userManager.CreateAsync(principal1, "1111111111");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(principal1, PrincipalRoleName);
            }

            //await dbContext.Users.AddAsync(principal1);







            //var principal2 = new ApplicationUser
            //{
            //    FirstName = "Anna",
            //    LastName = "Kostadinova",
            //    Gender = Gender.Female,
            //    DateOfBirth = new DateTime(1968, 9, 10),
            //    UserType = Models.Enums.UserType.Principal,
            //    Email = "principal.two@abv.bg",
            //    UserName = "principal.two@abv.bg",
            //};

            //await dbContext.Users.AddAsync(principal2);


            //var principal3 = new ApplicationUser
            //{
            //    FirstName = "Polina",
            //    LastName = "Hristova",
            //    Gender = Gender.Female,
            //    DateOfBirth = new DateTime(1963, 3, 11),
            //    UserType = Models.Enums.UserType.Principal,
            //    Email = "principal.three@abv.bg",
            //    UserName = "principal.three@abv.bg",
            //};

            //await dbContext.Users.AddAsync(principal3);

            //var nusrserySchool1 = dbContext.NurserySchools.Where(x => x.Name == "My World").FirstOrDefault();
            //var principal1db = dbContext.Principals.Where(x => x.User.Email == principal1.Email).FirstOrDefault();
            //nusrserySchool1.Principal.Id = principal1db.Id;

            //var nusrserySchool2 = dbContext.NurserySchools.Where(x => x.Name == "Smiles").FirstOrDefault();
            //var principal2db = dbContext.Principals.Where(x => x.User.Email == principal2.Email).FirstOrDefault();
            //nusrserySchool2.Principal.Id = principal2db.Id;

            //var nusrserySchool3 = dbContext.NurserySchools.Where(x => x.Name == "Little Sunshine").FirstOrDefault();
            //var principal3db = dbContext.Principals.Where(x => x.User.Email == principal3.Email).FirstOrDefault();
            //nusrserySchool3.Principal.Id = principal3db.Id;
        }

    }
}
