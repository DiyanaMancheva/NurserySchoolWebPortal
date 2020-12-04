namespace NurserySchoolWebPortal.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using NurserySchoolWebPortal.Data.Models;

    public class NurseryGroupsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.NurseryGroups.Any())
            {
                return;
            }

            await dbContext.NurseryGroups.AddAsync(new NurseryGroup
            {
                Name = "Rainbow",
                Room = "201",
                NurserySchoolId = 1,
            });

            await dbContext.NurseryGroups.AddAsync(new NurseryGroup
            {
                Name = "Mecho Puh",
                Room = "202",
                NurserySchoolId = 1,
            });

            await dbContext.NurseryGroups.AddAsync(new NurseryGroup
            {
                Name = "Bon Bon",
                Room = "101",
                NurserySchoolId = 1,
            });

            await dbContext.NurseryGroups.AddAsync(new NurseryGroup
            {
                Name = "Smehurkovci",
                Room = "101",
                NurserySchoolId = 2,
            });

            await dbContext.NurseryGroups.AddAsync(new NurseryGroup
            {
                Name = "Slunchogled",
                Room = "102",
                NurserySchoolId = 2,
            });

            await dbContext.NurseryGroups.AddAsync(new NurseryGroup
            {
                Name = "Slunce",
                Room = "103",
                NurserySchoolId = 2,
            });

            await dbContext.NurseryGroups.AddAsync(new NurseryGroup
            {
                Name = "Pirati",
                Room = "102",
                NurserySchoolId = 3,
            });

            await dbContext.NurseryGroups.AddAsync(new NurseryGroup
            {
                Name = "Kokiche",
                Room = "202",
                NurserySchoolId = 3,
            });
        }
    }
}
