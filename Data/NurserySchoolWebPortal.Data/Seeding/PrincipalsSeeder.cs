namespace NurserySchoolWebPortal.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using NurserySchoolWebPortal.Data.Models;

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
            };

            var nusrserySchool1 = dbContext.NurserySchools.Where(x => x.Name == "My World").FirstOrDefault();
            principal1.Principal.NurserySchools.Add(nusrserySchool1);

            await dbContext.Users.AddAsync(principal1);

            var principal2 = new ApplicationUser
            {
                FirstName = "Anna",
                LastName = "Kostadinova",
                Gender = Gender.Female,
                DateOfBirth = new DateTime(1968, 9, 10),
            };

            var nusrserySchool2 = dbContext.NurserySchools.Where(x => x.Name == "Smiles").FirstOrDefault();
            principal2.Principal.NurserySchools.Add(nusrserySchool2);

            await dbContext.Users.AddAsync(principal2);


            var principal3 = new ApplicationUser
            {
                FirstName = "Polina",
                LastName = "Hristova",
                Gender = Gender.Female,
                DateOfBirth = new DateTime(1963, 3, 11),
            };

            var nusrserySchool3 = dbContext.NurserySchools.Where(x => x.Name == "Little Sunshine").FirstOrDefault();
            principal3.Principal.NurserySchools.Add(nusrserySchool3);

            await dbContext.Users.AddAsync(principal3);
        }

    }
}
