namespace NurserySchoolWebPortal.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using NurserySchoolWebPortal.Data.Common.Repositories;
    using NurserySchoolWebPortal.Data.Models;
    using NurserySchoolWebPortal.Web.ViewModels.Teachers;

    public class TeachersService : ITeachersService
    {
        private readonly IDeletableEntityRepository<Teacher> teachersRepository;
        private readonly IDeletableEntityRepository<NurseryGroup> groupsRepository;

        public TeachersService(
            IDeletableEntityRepository<Teacher> teachersRepository,
            IDeletableEntityRepository<NurseryGroup> groupsRepository)
        {
            this.teachersRepository = teachersRepository;
            this.groupsRepository = groupsRepository;
        }

        public async Task<int> AddAsync(TeacherInputModel input)
        {
            var groupId = this.groupsRepository.AllAsNoTracking()
               .Where(x => x.Id == Int32.Parse(input.Group))
               .Select(x => x.Id)
               .FirstOrDefault();

            var teacher = new Teacher
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                Address = input.Address,
                DateOfBirth = input.DateOfBirth,
                NurseryGroupId = groupId,
            };

            await this.teachersRepository.AddAsync(teacher);
            await this.teachersRepository.SaveChangesAsync();
            return teacher.Id;
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
