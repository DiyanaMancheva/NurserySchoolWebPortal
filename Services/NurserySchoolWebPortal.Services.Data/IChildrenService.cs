namespace NurserySchoolWebPortal.Services.Data
{
    using System.Threading.Tasks;

    using NurserySchoolWebPortal.Web.ViewModels.Children;

    public interface IChildrenService
    {
        Task AddAsync(ChildInputModel input);

        ChildViewModel ById(int id);
    }
}
