namespace NurserySchoolWebPortal.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using NurserySchoolWebPortal.Data.Common.Repositories;
    using NurserySchoolWebPortal.Data.Models;
    using NurserySchoolWebPortal.Web.ViewModels.Posts;
    using NurserySchoolWebPortal.Web.ViewModels.Schools;

    public class SchoolsService : ISchoolsService
    {
        private readonly IDeletableEntityRepository<NurserySchool> schoolsRepository;
        private readonly IDeletableEntityRepository<Principal> principalsRepository;
        private readonly IDeletableEntityRepository<Post> postsRepository;

        public SchoolsService(
            IDeletableEntityRepository<NurserySchool> schoolsRepository,
            IDeletableEntityRepository<Principal> principalsRepository,
            IDeletableEntityRepository<Post> postsRepository)
        {
            this.schoolsRepository = schoolsRepository;
            this.principalsRepository = principalsRepository;
            this.postsRepository = postsRepository;
        }

        public SchoolsViewModel All()
        {
            var schools = this.schoolsRepository.AllAsNoTracking()
                .Select(x => new SingleSchoolViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                })
                .ToList();

            foreach (var school in schools)
            {
                var posts = this.postsRepository.AllAsNoTracking()
                .Where(x => x.Id == school.Id)
                .Select(x => new SinglePostViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    CreatedOn = x.CreatedOn,
                })
                .ToList();

                school.Posts = posts;
            }

            var viewModel = new SchoolsViewModel
            {
                Schools = schools,
            };

            return viewModel;
        }

        public IEnumerable<KeyValuePair<int, string>> GetAllAsKeyValuePairs()
        {
            var schools = this.schoolsRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                })
                .OrderBy(x => x.Id)
                .ToList()
                .Select(x => new KeyValuePair<int, string>(x.Id, x.Name));

            return schools;
        }
    }
}
