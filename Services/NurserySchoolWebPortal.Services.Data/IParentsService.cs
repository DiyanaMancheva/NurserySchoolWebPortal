namespace NurserySchoolWebPortal.Services.Data
{
    using NurserySchoolWebPortal.Web.ViewModels.Parents;

    public interface IParentsService
    {
        ParentPageViewModel GetAll();
    }
}
