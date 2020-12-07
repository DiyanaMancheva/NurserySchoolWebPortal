namespace NurserySchoolWebPortal.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using NurserySchoolWebPortal.Data.Models;

    public class ImagesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Images.Any())
            {
                return;
            }

            await dbContext.Images.AddAsync(new Image
            {
                Url = "https://www.mosaicnursery.com/reem-island/wp-content/uploads/2018/08/Kids-Nursery-School-in-Abu-Dhabi-680x380.jpg",
                Extension = "jpg",
                NurseryGroupId = 1,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTJMRM46x1_ZTkgL96cypxgV_b5fUpFmHOvHA&usqp=CAU",
                Extension = "jpg",
                NurseryGroupId = 1,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "https://miro.medium.com/max/1200/1*Nn-ZuiqZVLKUFQN4EWJzXg.jpeg",
                Extension = "jpg",
                NurseryGroupId = 1,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "~/img/nurserySchools/3.jpg",
                Extension = "jpg",
                NurseryGroupId = 1,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "~/img/nurserySchools/4.jpg",
                Extension = "jpg",
                NurseryGroupId = 1,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "~/img/nurserySchools/5.jpg",
                Extension = "jpg",
                NurseryGroupId = 1,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "~/img/nurserySchools/6.jpg",
                Extension = "jpg",
                NurseryGroupId = 1,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "~/img/nurserySchools/7.jpg",
                Extension = "jpg",
                NurseryGroupId = 1,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "~/img/nurserySchools/8.jpg",
                Extension = "jpg",
                NurseryGroupId = 1,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "~/img/nurserySchools/9.jpg",
                Extension = "jpg",
                NurseryGroupId = 2,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "~/img/nurserySchools/10.jpg",
                Extension = "jpg",
                NurseryGroupId = 2,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "~/img/nurserySchools/11.jpg",
                Extension = "jpg",
                NurseryGroupId = 2,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "~/img/nurserySchools/12.jpg",
                Extension = "jpg",
                NurseryGroupId = 2,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "~/img/nurserySchools/13.jpg",
                Extension = "jpg",
                NurseryGroupId = 2,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "~/img/nurserySchools/14.jpg",
                Extension = "jpg",
                NurseryGroupId = 3,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "~/img/nurserySchools/15.jpg",
                Extension = "jpg",
                NurseryGroupId = 3,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "~/img/nurserySchools/16.jpg",
                Extension = "jpg",
                NurseryGroupId = 3,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "~/img/nurserySchools/17.jpg",
                Extension = "jpg",
                NurseryGroupId = 3,
            });
        }
    }
}
