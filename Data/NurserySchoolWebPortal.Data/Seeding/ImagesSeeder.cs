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
                Url = "https://c8.alamy.com/comp/B1H9G9/teacher-reading-to-nursery-school-children-B1H9G9.jpg",
                Extension = "jpg",
                NurseryGroupId = 1,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "https://www.channel4.com/media/images/Channel4/c4-news/2014/April/02/02_nursery_school_g_w.jpg",
                Extension = "jpg",
                NurseryGroupId = 1,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "https://www.kensingtonmums.co.uk/wp-content/uploads/2018/09/AdobeStock_65806888.jpeg",
                Extension = "jpg",
                NurseryGroupId = 1,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "https://www.daynurseries.co.uk/images2/advice/Nursery%20school%20children(1).jpg",
                Extension = "jpg",
                NurseryGroupId = 1,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "https://i2-prod.mirror.co.uk/incoming/article6130411.ece/ALTERNATES/s615/CS81901616.jpg",
                Extension = "jpg",
                NurseryGroupId = 1,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "https://www.leicestershire.gov.uk/sites/default/files/field/section_image/2015/10/6/Early%20years%20nursery.jpg",
                Extension = "jpg",
                NurseryGroupId = 1,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "https://thingstodoingeneva.ch/wp-content/uploads/2020/06/TTDIG-Nursery-Alternate-Main-image-750x500-1-600x375.jpg",
                Extension = "jpg",
                NurseryGroupId = 1,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "https://thingstodoingeneva.ch/wp-content/uploads/2020/06/TTDIG-Nursery-Alternate-Main-image-750x500-1-600x375.jpg",
                Extension = "jpg",
                NurseryGroupId = 1,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "https://www.acornscirencester.com/wp-content/uploads/acorns-nursery-cirencester-toddlers.jpg",
                Extension = "jpg",
                NurseryGroupId = 1,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "https://www.daynurseries.co.uk/images2/advice/Nursery%20school%20children(1).jpg",
                Extension = "jpg",
                NurseryGroupId = 1,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "https://as1.ftcdn.net/jpg/02/49/97/28/500_F_249972813_JfQ9gmhJq09uaIKy18FmY8ka2kzxlp8v.jpg",
                Extension = "jpg",
                NurseryGroupId = 2,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "https://mygreymatters.net/wp-content/uploads/Why-Early-Attendance-In-Nursery-School-Is-Important.jpg",
                Extension = "jpg",
                NurseryGroupId = 2,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "https://i.pinimg.com/originals/d9/b6/0f/d9b60fd2be53c4419c4baed58972f6f4.jpg",
                Extension = "jpg",
                NurseryGroupId = 2,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "https://miro.medium.com/max/1000/0*64swZuBN-uDOb_NC.jpg",
                Extension = "jpg",
                NurseryGroupId = 2,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "https://c.files.bbci.co.uk/F188/production/_91323816_thinkstockphotos-484794640.jpg",
                Extension = "jpg",
                NurseryGroupId = 2,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "https://www.mosaicnursery.com/reem-island/wp-content/uploads/2018/08/Kids-Nursery-School-in-Abu-Dhabi-680x380.jpg",
                Extension = "jpg",
                NurseryGroupId = 2,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTJMRM46x1_ZTkgL96cypxgV_b5fUpFmHOvHA&usqp=CAU",
                Extension = "jpg",
                NurseryGroupId = 2,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "https://miro.medium.com/max/1200/1*Nn-ZuiqZVLKUFQN4EWJzXg.jpeg",
                Extension = "jpg",
                NurseryGroupId = 2,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "https://c8.alamy.com/comp/B1H9G9/teacher-reading-to-nursery-school-children-B1H9G9.jpg",
                Extension = "jpg",
                NurseryGroupId = 2,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "https://www.channel4.com/media/images/Channel4/c4-news/2014/April/02/02_nursery_school_g_w.jpg",
                Extension = "jpg",
                NurseryGroupId = 2,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "https://www.kensingtonmums.co.uk/wp-content/uploads/2018/09/AdobeStock_65806888.jpeg",
                Extension = "jpg",
                NurseryGroupId = 2,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "https://www.daynurseries.co.uk/images2/advice/Nursery%20school%20children(1).jpg",
                Extension = "jpg",
                NurseryGroupId = 2,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "https://thingstodoingeneva.ch/wp-content/uploads/2020/06/TTDIG-Nursery-Alternate-Main-image-750x500-1-600x375.jpg",
                Extension = "jpg",
                NurseryGroupId = 3,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "https://thingstodoingeneva.ch/wp-content/uploads/2020/06/TTDIG-Nursery-Alternate-Main-image-750x500-1-600x375.jpg",
                Extension = "jpg",
                NurseryGroupId = 3,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "https://www.acornscirencester.com/wp-content/uploads/acorns-nursery-cirencester-toddlers.jpg",
                Extension = "jpg",
                NurseryGroupId = 3,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "https://www.daynurseries.co.uk/images2/advice/Nursery%20school%20children(1).jpg",
                Extension = "jpg",
                NurseryGroupId = 3,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "https://mygreymatters.net/wp-content/uploads/Why-Early-Attendance-In-Nursery-School-Is-Important.jpg",
                Extension = "jpg",
                NurseryGroupId = 3,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "https://i.pinimg.com/originals/d9/b6/0f/d9b60fd2be53c4419c4baed58972f6f4.jpg",
                Extension = "jpg",
                NurseryGroupId = 3,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "https://miro.medium.com/max/1000/0*64swZuBN-uDOb_NC.jpg",
                Extension = "jpg",
                NurseryGroupId = 3,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "https://c.files.bbci.co.uk/F188/production/_91323816_thinkstockphotos-484794640.jpg",
                Extension = "jpg",
                NurseryGroupId = 3,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "https://www.mosaicnursery.com/reem-island/wp-content/uploads/2018/08/Kids-Nursery-School-in-Abu-Dhabi-680x380.jpg",
                Extension = "jpg",
                NurseryGroupId = 3,
            });

            await dbContext.Images.AddAsync(new Image
            {
                Url = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTJMRM46x1_ZTkgL96cypxgV_b5fUpFmHOvHA&usqp=CAU",
                Extension = "jpg",
                NurseryGroupId = 3,
            });
        }
    }
}
