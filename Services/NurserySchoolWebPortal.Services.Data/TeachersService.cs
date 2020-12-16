namespace NurserySchoolWebPortal.Services.Data
{
    using System;
    using System.Linq;

    using NurserySchoolWebPortal.Data.Common.Repositories;
    using NurserySchoolWebPortal.Data.Models;
    using NurserySchoolWebPortal.Web.ViewModels.Teachers;

    public class TeachersService : ITeachersService
    {
        private readonly IDeletableEntityRepository<Teacher> teachersRepository;

        public TeachersService(IDeletableEntityRepository<Teacher> teachersRepository)
        {
            this.teachersRepository = teachersRepository;
        }

        public TeachersViewModel All(int page, int teachersPerPage = 3)
        {
            var teachers = this.teachersRepository.AllAsNoTracking()
                .OrderBy(x => Guid.NewGuid())
                .Skip((page - 1) * teachersPerPage)
                .Take(teachersPerPage)
                .Select(x => new SingleTeacherViewModel
                {
                    Id = x.Id,
                    FullName = x.FirstName + " " + x.LastName,
                    NurseryGroupId = x.NurseryGroupId,
                    NurserySchool = x.NurseryGroup.NurserySchool.Name,
                    //ProfilePic = x.Url,
                    //PersonalMessage = x.PersonalMessage,
                })
                .ToList();

            var teachersViewModel = new TeachersViewModel
            {
                Teachers = teachers,
            };

            return teachersViewModel;
        }

        public int GetCount()
        {
            return this.teachersRepository.AllAsNoTracking().Count();
        }
    }
}
