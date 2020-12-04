namespace NurserySchoolWebPortal.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using NurserySchoolWebPortal.Data.Models;

    public class NurserySchoolsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.NurserySchools.Any())
            {
                return;
            }

            await dbContext.NurserySchools.AddAsync(new NurserySchool
            {
                Name = "My World",
                Address = "Sofia, Str.\"Stara Planina\" 34",
            });
            await dbContext.NurserySchools.AddAsync(new NurserySchool
            {
                Name = "Smiles",
                Address = "Sofia, Str.\"Panayot Volov\" 72",
            });
            await dbContext.NurserySchools.AddAsync(new NurserySchool
            {
                Name = "Little Sunshine",
                Address = "Sofia, Str.\"Vasil Levski\" 21",
            });
        }
    }
}
