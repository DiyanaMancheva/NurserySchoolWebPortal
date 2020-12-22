namespace NurserySchoolWebPortal.Services.Data
{
    using System.Collections.Generic;

    public interface IGroupsService
    {
        IEnumerable<KeyValuePair<int, string>> GetAllAsKeyValuePairs();
    }
}
