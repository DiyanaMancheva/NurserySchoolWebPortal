namespace NurserySchoolWebPortal.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using NurserySchoolWebPortal.Web.ViewModels.Children;

    public interface IChildrenService
    {
        Task AddAsync(ChildInputModel input);

        ChildViewModel ById(int id);

        IEnumerable<KeyValuePair<int, string>> GetAllAsKeyValuePairsPerSchool(int schoolId);
    }
}
