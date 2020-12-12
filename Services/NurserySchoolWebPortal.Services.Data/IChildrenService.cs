using NurserySchoolWebPortal.Web.ViewModels.Children;

namespace NurserySchoolWebPortal.Services.Data
{
    public interface IChildrenService
    {
        ChildViewModel ById(int id);
    }
}
