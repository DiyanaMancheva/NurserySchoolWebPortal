namespace NurserySchoolWebPortal.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using NurserySchoolWebPortal.Data.Common.Repositories;
    using NurserySchoolWebPortal.Data.Models;
    using NurserySchoolWebPortal.Web.ViewModels.Children;

    public class ChildrenService : IChildrenService
    {
        private readonly IDeletableEntityRepository<Child> childrenRepository;
        private readonly IDeletableEntityRepository<Fee> feesRepository;
        private readonly IDeletableEntityRepository<PersonalInfo> personalInfosRepository;
        private readonly IDeletableEntityRepository<Immunization> immunizationsRepository;
        private readonly IDeletableEntityRepository<Parent> parentsRepository;

        public ChildrenService(
            IDeletableEntityRepository<Child> childrenRepository,
            IDeletableEntityRepository<Fee> feesRepository,
            IDeletableEntityRepository<PersonalInfo> personalInfosRepository,
            IDeletableEntityRepository<Immunization> immunizationsRepository,
            IDeletableEntityRepository<Parent> parentsRepository)
        {
            this.childrenRepository = childrenRepository;
            this.feesRepository = feesRepository;
            this.personalInfosRepository = personalInfosRepository;
            this.immunizationsRepository = immunizationsRepository;
            this.parentsRepository = parentsRepository;
        }

        public async Task AddAsync(ChildInputModel input)
        {
            var child = new Child
            {
                FirstName = input.FirstName,
                MiddleName = input.MiddleName,
                LastName = input.LastName,
                Gender = (Gender)input.Gender,
                DateOfBirth = input.DateOfBirth,
                EGN = input.EGN,
                Address = input.Address,
                NurseryGroupId = int.Parse(input.GroupName),
            };

            await this.childrenRepository.AddAsync(child);
            await this.childrenRepository.SaveChangesAsync();
        }

        public ChildViewModel ById(int id)
        {
            var fee = this.feesRepository.AllAsNoTracking()
                .Where(x => x.ChildId == id)
                .Select(x => new FeeViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    DateFrom = x.DateFrom,
                    DateTo = x.DateTo,
                })
                .FirstOrDefault();

            var personalInfo = this.personalInfosRepository.AllAsNoTracking()
                .Where(x => x.ChildId == id)
                .Select(x => new PersonalInfoViewModel
                {
                    Id = x.Id,
                    Weight = x.Weight,
                    Height = x.Height,
                })
                .FirstOrDefault();

            var parent = this.parentsRepository.AllAsNoTracking()
                .Where(x => x.Children.Any(y => y.Id == id))
                .Select(x => new ParentViewModel
                {
                    Id = x.Id,
                    ParentName = x.User.FirstName + " " + x.User.LastName,
                    ParentEmail = x.User.Email,
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
                    FeeMoneyAmount = x.Fee.MoneyAmount,
                    FeeTitle = x.Fee.Title,
                    FeeDateFrom = x.Fee.DateFrom.ToShortDateString(),
                    FeeDateTo = x.Fee.DateTo.ToShortDateString(),
                    Weight = x.PersonalInfo.Weight,
                    Height = x.PersonalInfo.Height,
                    Gender = (int)x.Gender,
                    Address = x.Address,
                    DateOfBirth = x.DateOfBirth.ToShortDateString(),
                    SchoolName = x.NurseryGroup.NurserySchool.Name,
                    GroupName = x.NurseryGroup.Name,
                    ParentName = x.Parent.User.FirstName + " " + x.Parent.User.LastName,
                    PhoneNumber = x.Parent.User.PhoneNumber,
                    Email = x.Parent.User.Email,
                })
                .FirstOrDefault();

            return child;

            //var immunizations = this.immunizationsRepository.AllAsNoTracking()
            //   .Where(x => x.PersonalInfos.Contains(personalInfo))
        }

        public IEnumerable<KeyValuePair<int, string>> GetAllAsKeyValuePairsPerSchool(int schoolId)
        {
            var children = this.childrenRepository.AllAsNoTracking()
                .Where(x => x.NurseryGroup.NurserySchoolId == schoolId)
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.FirstName + " " + x.LastName,
                })
                .OrderBy(x => x.Id)
                .ToList()
                .Select(x => new KeyValuePair<int, string>(x.Id, x.Name));

            return children;
        }
    }
}
