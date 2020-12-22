namespace NurserySchoolWebPortal.Services.Data
{
    using System.Collections.Generic;

    public interface IGroupsService
    {
        int GetId(string name);

        IEnumerable<KeyValuePair<int, string>> GetAllAsKeyValuePairs();
    }
}
