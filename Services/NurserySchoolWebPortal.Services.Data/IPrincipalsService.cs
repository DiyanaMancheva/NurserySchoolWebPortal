namespace NurserySchoolWebPortal.Services.Data
{
    using System.Threading.Tasks;

    using NurserySchoolWebPortal.Web.ViewModels.Administration.Principals;

    public interface IPrincipalsService
    {
        //IEnumerable<T> All();

        //IEnumerable<int> AllIdsByCategory(int categoryId);

        Task<int> AddAsync(PrincipalInputModel input);

        //Task DeleteAsync(int id);
    }
}
