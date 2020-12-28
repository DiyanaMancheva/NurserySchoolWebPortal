namespace NurserySchoolWebPortal.Services.Data
{
    using System.Threading.Tasks;

    using NurserySchoolWebPortal.Data.Models;
    using NurserySchoolWebPortal.Web.ViewModels.Menu;

    public interface IMenuService
    {
        Task AddAsync(MenuInputModel input, int schoolId);

        MenuViewModel GetById(int id);

        MenuViewModel GetCurrent();
    }
}
