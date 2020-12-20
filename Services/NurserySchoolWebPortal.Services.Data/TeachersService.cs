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
                .Skip((page - 1) * teachersPerPage)
                .Take(teachersPerPage)
                .OrderBy(x => Guid.NewGuid())
                .Select(x => new SingleTeacherViewModel
                {
                    Id = x.Id,
                    FullName = x.FirstName + " " + x.LastName,
                    NurseryGroupId = x.NurseryGroupId,
                    NurserySchool = x.NurseryGroup.NurserySchool.Name,
                    NurseryGroup = x.NurseryGroup.Name,
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

        public TeachersViewModel AllPerGroup(int groupId, int page, int teachersPerPage = 3)
        {
            var teachers = this.teachersRepository.AllAsNoTracking()
                .Where(x => x.NurseryGroupId == groupId)
                .Skip((page - 1) * teachersPerPage)
                .Take(teachersPerPage)
                .Select(x => new SingleTeacherViewModel
                {
                    Id = x.Id,
                    FullName = x.FirstName + " " + x.LastName,
                    NurseryGroupId = x.NurseryGroupId,
                    NurserySchool = x.NurseryGroup.NurserySchool.Name,
                    NurseryGroup = x.NurseryGroup.Name,
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

        public int GetCount(int groupId = 0)
        {
            if (groupId == 0)
            {
                return this.teachersRepository.AllAsNoTracking().Count();
            }

            return this.teachersRepository.AllAsNoTracking().Where(x => x.NurseryGroupId == groupId).Count();
        }
    }
}
