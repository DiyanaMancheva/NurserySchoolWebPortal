namespace NurserySchoolWebPortal.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using NurserySchoolWebPortal.Data.Models;

    public class ChildrenSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Children.Any())
            {
                return;
            }

            await dbContext.Children.AddAsync(new Child
            {
                FirstName = "Ivan",
                MiddleName = "Kostadinov",
                LastName = "Dimitrov",
                Gender = Gender.Male,
                EGN = "5212125673",
                Address = "Sofia, Str.Malkara 35, app.4",
                NurseryGroupId = 1,
                DateOfBirth = new DateTime(2017, 3, 17),
            });

            await dbContext.Children.AddAsync(new Child
            {
                FirstName = "Dimiter",
                MiddleName = "Kostadinov",
                LastName = "Petrov",
                Gender = Gender.Male,
                EGN = "5210063675",
                Address = "Sofia, Boulv.Vasil Levski 5, app.14",
                NurseryGroupId = 1,
                DateOfBirth = new DateTime(2017, 3, 17),
            });

            await dbContext.Children.AddAsync(new Child
            {
                FirstName = "Peter",
                MiddleName = "Ivanov",
                LastName = "Karolev",
                Gender = Gender.Male,
                EGN = "5107171245",
                Address = "Sofia, Str.Malkara 12, app.24",
                NurseryGroupId = 2,
                DateOfBirth = new DateTime(2017, 3, 17),
            });

            await dbContext.Children.AddAsync(new Child
            {
                FirstName = "Marina",
                MiddleName = "Kostova",
                LastName = "Dimitrova",
                Gender = Gender.Female,
                EGN = "5306137623",
                Address = "Sofia, Str.Parchevich 17, app.4",
                NurseryGroupId = 3,
                DateOfBirth = new DateTime(2017, 3, 17),
            });

            await dbContext.Children.AddAsync(new Child
            {
                FirstName = "Maya",
                MiddleName = "Kostadinova",
                LastName = "Stoyanova",
                Gender = Gender.Female,
                EGN = "5304128465",
                Address = "Sofia, Str.Malkara 35, app.12",
                NurseryGroupId = 2,
                DateOfBirth = new DateTime(2017, 3, 17),
            });

            await dbContext.Children.AddAsync(new Child
            {
                FirstName = "Stoyan",
                MiddleName = "Metodiev",
                LastName = "Dilov",
                Gender = Gender.Male,
                EGN = "5101127354",
                Address = "Sofia, Str.Suborna 5, app.7",
                NurseryGroupId = 6,
                DateOfBirth = new DateTime(2017, 3, 17),
            });
        }
    }
}
