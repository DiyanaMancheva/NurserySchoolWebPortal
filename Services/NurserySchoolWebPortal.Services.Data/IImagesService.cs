namespace NurserySchoolWebPortal.Services.Data
{
    using NurserySchoolWebPortal.Web.ViewModels.Images;

    public interface IImagesService
    {
        ImagesViewModel AllPerGroup(int groupId, int page, int imagesPerPage);

        int GetCount(int id);
    }
}
