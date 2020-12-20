namespace NurserySchoolWebPortal.Services.Data
{
    using System.Collections.Generic;

    using NurserySchoolWebPortal.Web.ViewModels.Schools;

    public interface ISchoolsService
    {
        SchoolsViewModel All();

        IEnumerable<KeyValuePair<int, string>> GetAllAsKeyValuePairs();
    }
}
