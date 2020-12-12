namespace NurserySchoolWebPortal.Services.Data
{
    using System.Linq;

    using NurserySchoolWebPortal.Data.Common.Repositories;
    using NurserySchoolWebPortal.Data.Models;
    using NurserySchoolWebPortal.Web.ViewModels.Images;

    public class ImagesService : IImagesService
    {
        private readonly IDeletableEntityRepository<Image> imagesRepository;

        public ImagesService(IDeletableEntityRepository<Image> imagesRepository)
        {
            this.imagesRepository = imagesRepository;
        }

        public ImagesViewModel AllPerGroup(int groupId, int page, int imagesPerPage = 6)
        {
            var images = this.imagesRepository.AllAsNoTracking()
                .OrderByDescending(x => x.CreatedOn)
                .Where(x => x.NurseryGroupId == groupId)
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
            return this.imagesRepository.All().Where(x => x.NurseryGroupId == id).Count();
        }

        //public IEnumerable<T> GetRandom<T>(int count)
        //{
        //    return this.recipesRepository.All()
        //        .OrderBy(x => Guid.NewGuid())
        //        .Take(count)
        //        .To<T>().ToList();
        //}
    }
}
