namespace NurserySchoolWebPortal.Services.Data
{
    using NurserySchoolWebPortal.Web.ViewModels.Teachers;

    public interface ITeachersService
    {
        TeachersViewModel All(int page, int teachersPerPage);

        int GetCount();
    }
}
