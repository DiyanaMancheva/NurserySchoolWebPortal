namespace NurserySchoolWebPortal.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGroupsService
    {
        int GetId(string name);

        IEnumerable<KeyValuePair<int, string>> GetAllAsKeyValuePairs();

        IEnumerable<KeyValuePair<int, string>> GetAllAsKeyValuePairsPerSchool(int schoolId);

        //Task<int> AddAsync(GroupInputModel input);
    }
}
