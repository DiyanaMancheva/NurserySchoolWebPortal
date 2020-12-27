namespace NurserySchoolWebPortal.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;
    using NurserySchoolWebPortal.Data.Common.Repositories;
    using NurserySchoolWebPortal.Data.Models;
    using NurserySchoolWebPortal.Web.ViewModels.Images;

    public class ImagesService : IImagesService
    {
        private readonly IDeletableEntityRepository<Image> imagesRepository;
        private readonly IDeletableEntityRepository<NurseryGroup> groupsRepository;

        public ImagesService(
            IDeletableEntityRepository<Image> imagesRepository,
            IDeletableEntityRepository<NurseryGroup> groupsRepository)
        {
            this.imagesRepository = imagesRepository;
            this.groupsRepository = groupsRepository;
        }

        public async Task AddAsync(ImageInputModel input)
        {
            var groupId = this.groupsRepository.AllAsNoTracking()
               .Where(x => x.Id == int.Parse(input.Group))
               .Select(x => x.Id)
               .FirstOrDefault();

            var image = new Image
            {
                Url = input.Url,
                Extension = input.Extension,
                NurseryGroupId = groupId,
            };

            await this.imagesRepository.AddAsync(image);
            await this.imagesRepository.SaveChangesAsync();
        }

        public ImagesViewModel AllPerGroup(int groupId, int page, int imagesPerPage = 6)
        {
            var images = this.imagesRepository.AllAsNoTracking()
                .Where(x => x.NurseryGroupId == groupId)
                .OrderByDescending(x => x.CreatedOn)
                .Skip((page - 1) * imagesPerPage)
                .Take(imagesPerPage)
                .Select(x => new SingleImageViewModel
                {
                    Id = x.Id,
                    Url = x.Url,
                })
                .ToList();

            var imagesViewModel = new ImagesViewModel
            {
                Images = images,
            };

            return imagesViewModel;
        }

        public ImagesViewModel AllPerSchool(int schoolId, int page, int imagesPerPage = 6)
        {
            var images = this.imagesRepository.AllAsNoTracking()
                .Where(x => x.NurseryGroup.NurserySchoolId == schoolId)
                .OrderByDescending(x => x.CreatedOn)
                .Skip((page - 1) * imagesPerPage)
                .Take(imagesPerPage)
                .Select(x => new SingleImageViewModel
                {
                    Id = x.Id,
                    Url = x.Url,
                })
                .ToList();

            var imagesViewModel = new ImagesViewModel
            {
                Images = images,
            };

            return imagesViewModel;
        }

        public int GetCount(int id)
        {
            return this.imagesRepository.AllAsNoTracking().Where(x => x.NurseryGroupId == id).Count();
        }

        public int GetCountPerSchool(int id)
        {
            var groups = this.groupsRepository.AllAsNoTracking()
                .Where(x => x.NurserySchoolId == id)
                .ToList();

            var imagesCount = 0;

            foreach (var group in groups)
            {
                var imagesPerGroup = this.imagesRepository.AllAsNoTracking().Where(x => x.NurseryGroupId == group.Id).Count();
                imagesCount += imagesPerGroup;
            }

            return imagesCount;
        }
    }
}
