namespace NurserySchoolWebPortal.Services.Data
{
    using System.Linq;

    using NurserySchoolWebPortal.Data.Common.Repositories;
    using NurserySchoolWebPortal.Data.Models;
    using NurserySchoolWebPortal.Web.ViewModels.Children;

    public class ChildrenService : IChildrenService
    {
        private readonly IDeletableEntityRepository<Child> childrenRepository;
        private readonly IDeletableEntityRepository<Fee> feeRepository;
        private readonly IDeletableEntityRepository<PersonalInfo> personalInfoRepository;
        private readonly IDeletableEntityRepository<Immunization> immunizationRepository;

        public ChildrenService(
            IDeletableEntityRepository<Child> childrenRepository,
            IDeletableEntityRepository<Fee> feeRepository,
            IDeletableEntityRepository<PersonalInfo> personalInfoRepository,
            IDeletableEntityRepository<Immunization> immunizationRepository)
        {
            this.childrenRepository = childrenRepository;
            this.feeRepository = feeRepository;
            this.personalInfoRepository = personalInfoRepository;
            this.immunizationRepository = immunizationRepository;
        }

        public ChildViewModel ById(int id)
        {
            var fee = this.feeRepository.AllAsNoTracking()
                .Where(x => x.ChildId == id)
                .Select(x => new FeeViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    DateFrom = x.DateFrom,
                    DateTo = x.DateTo,
                })
                .FirstOrDefault();

            var personalInfo = this.personalInfoRepository.AllAsNoTracking()
                .Where(x => x.ChildId == id)
                .Select(x => new PersonalInfoViewModel
                {
                    Id = x.Id,
                    Weight = x.Weight,
                    Height = x.Height,
                })
                .FirstOrDefault();

            var child = this.childrenRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => new ChildViewModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    MiddleName = x.MiddleName,
                    LastName = x.LastName,
                    Fee = fee,
                    PersonalInfo = personalInfo,
                })
                .FirstOrDefault();

            return child;

            //var immunizations = this.immunizationRepository.AllAsNoTracking()
            //   .Where(x => x.PersonalInfos.Contains(personalInfo))
        }
    }
}
