namespace NurserySchoolWebPortal.Services.Data
{
    using System.Threading.Tasks;

    using NurserySchoolWebPortal.Web.ViewModels.PersoonalInfo;

    public interface IPersonalInfosService
    {
        Task AddAsync(PersonalInfoInputModel input);

        PersonalInfoInputModel GetById(int id);
    }
}
