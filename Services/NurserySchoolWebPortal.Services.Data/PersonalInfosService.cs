namespace NurserySchoolWebPortal.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using NurserySchoolWebPortal.Data.Common.Repositories;
    using NurserySchoolWebPortal.Data.Models;
    using NurserySchoolWebPortal.Web.ViewModels.PersoonalInfo;

    public class PersonalInfosService : IPersonalInfosService
    {
        private readonly IDeletableEntityRepository<Child> childrenRepository;
        private readonly IDeletableEntityRepository<PersonalInfo> personalInfosRepository;

        public PersonalInfosService(
            IDeletableEntityRepository<Child> childrenRepository,
            IDeletableEntityRepository<PersonalInfo> personalInfosRepository)
        {
            this.childrenRepository = childrenRepository;
            this.personalInfosRepository = personalInfosRepository;
        }

        public async Task AddAsync(PersonalInfoInputModel input)
        {
            var personalInfo = new PersonalInfo
            {
                Height = input.Height,
                Weight = input.Weight,
                ChildId = int.Parse(input.Child),
            };

            await this.personalInfosRepository.AddAsync(personalInfo);
            await this.personalInfosRepository.SaveChangesAsync();
        }

        public PersonalInfoInputModel GetById(int id)
        {
            var personalInfo = this.personalInfosRepository.AllAsNoTracking()
                 .Where(x => x.ChildId == id)
                 .Select(x => new PersonalInfoInputModel
                 {
                     Id = x.Id,
                     Height = x.Height,
                     Weight = x.Weight,
                     CreatedOn = x.CreatedOn,
                     ModifiedOn = (DateTime)x.ModifiedOn,
                 })
                 .FirstOrDefault();

            return personalInfo;
        }
    }
}
