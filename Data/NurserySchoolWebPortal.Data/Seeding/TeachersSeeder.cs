namespace NurserySchoolWebPortal.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using NurserySchoolWebPortal.Data.Models;

    public class TeachersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Teachers.Any())
            {
                return;
            }

            await dbContext.Teachers.AddAsync(new Teacher
            {
                FirstName = "Irina",
                LastName = "Marinova",
                Gender = Gender.Female,
                DateOfBirth = new DateTime(1980, 2, 10),
                Address = "Sofia, Str.\"Stara Planina\" 76, app.4",
                NurseryGroupId = 1,
            });

            await dbContext.Teachers.AddAsync(new Teacher
            {
                FirstName = "Petya",
                LastName = "Marinova",
                Gender = Gender.Female,
                DateOfBirth = new DateTime(1975, 3, 11),
                Address = "Sofia, Str.\"Krayova\" 76, app.9",
                NurseryGroupId = 2,
            });

            await dbContext.Teachers.AddAsync(new Teacher
            {
                FirstName = "Dimana",
                LastName = "Antonova",
                Gender = Gender.Female,
                DateOfBirth = new DateTime(1976, 9, 12),
                Address = "Sofia, Str.\"Milin kamyk\" 6, app.19",
                NurseryGroupId = 3,
            });
        }
    }
}
