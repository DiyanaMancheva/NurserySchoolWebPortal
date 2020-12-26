namespace NurserySchoolWebPortal.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using NurserySchoolWebPortal.Data.Common.Repositories;
    using NurserySchoolWebPortal.Data.Models;

    public class GroupsService : IGroupsService
    {
        private readonly IDeletableEntityRepository<NurseryGroup> groupsRepository;

        public GroupsService(IDeletableEntityRepository<NurseryGroup> groupsRepository)
        {
            this.groupsRepository = groupsRepository;
        }

        public IEnumerable<KeyValuePair<int, string>> GetAllAsKeyValuePairs()
        {
            var groups = this.groupsRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                })
                .OrderBy(x => x.Id)
                .ToList()
                .Select(x => new KeyValuePair<int, string>(x.Id, x.Name));

            return groups;
        }

        public IEnumerable<KeyValuePair<int, string>> GetAllAsKeyValuePairsPerSchool(int schoolId)
        {
            var groups = this.groupsRepository.AllAsNoTracking()
                .Where(x => x.NurserySchoolId == schoolId)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                })
                .OrderBy(x => x.Id)
                .ToList()
                .Select(x => new KeyValuePair<int, string>(x.Id, x.Name));

            return groups;
        }

        public int GetId(string name)
        {
            var groupId = this.groupsRepository.All()
                .Where(x => x.Name == name)
                .Select(x => x.Id)
                .FirstOrDefault();

            return groupId;
        }
    }
}
