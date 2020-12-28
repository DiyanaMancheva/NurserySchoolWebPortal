namespace NurserySchoolWebPortal.Services.Data
{
    using NurserySchoolWebPortal.Web.ViewModels.Fees;

    using System.Threading.Tasks;

    public interface IFeesService
    {
        Task AddAsync(FeeInputModel input);

        FeeInputModel GetById(int id);
    }
}
