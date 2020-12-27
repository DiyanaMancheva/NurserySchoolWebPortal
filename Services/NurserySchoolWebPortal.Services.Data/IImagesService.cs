namespace NurserySchoolWebPortal.Services.Data
{
    using System.Threading.Tasks;

    using NurserySchoolWebPortal.Web.ViewModels.Images;

    public interface IImagesService
    {
        Task AddAsync(ImageInputModel input);

        ImagesViewModel AllPerGroup(int groupId, int page, int imagesPerPage);

        ImagesViewModel AllPerSchool(int schoolId, int page, int imagesPerPage);

        int GetCount(int id);

        int GetCountPerSchool(int id);
    }
}
