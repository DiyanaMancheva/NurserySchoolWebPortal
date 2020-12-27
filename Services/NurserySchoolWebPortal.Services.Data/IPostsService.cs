namespace NurserySchoolWebPortal.Services.Data
{
    using System.Threading.Tasks;

    using NurserySchoolWebPortal.Web.ViewModels.Posts;

    public interface IPostsService
    {
        Task AddAsync(PostInputModel input, int schoolId);

        AllPerSchool AllPerSchool(int schoolId, int postsPerPage);

        SinglePostViewModel GetById(int id);
    }
}
