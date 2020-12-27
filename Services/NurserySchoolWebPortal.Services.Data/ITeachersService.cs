namespace NurserySchoolWebPortal.Services.Data
{
    using System.Threading.Tasks;

    using NurserySchoolWebPortal.Web.ViewModels.Teachers;

    public interface ITeachersService
    {
        Task AddAsync(TeacherInputModel input);

        TeachersViewModel All(int page, int teachersPerPage);

        TeachersViewModel AllPerGroup(int groupId, int page, int teachersPerPage);

        int GetCount(int groupId);
    }
}
