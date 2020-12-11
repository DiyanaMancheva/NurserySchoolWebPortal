namespace NurserySchoolWebPortal.Services.Data
{
    using NurserySchoolWebPortal.Web.ViewModels.Posts;

    public interface IPostsService
    {
        SinglePostViewModel GetById(int id);
    }
}
