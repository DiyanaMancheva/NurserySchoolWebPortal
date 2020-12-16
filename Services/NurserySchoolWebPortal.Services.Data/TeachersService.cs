namespace NurserySchoolWebPortal.Services.Data
{
    using System;
    using System.Collections.Generic;
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

        public TeachersViewModel All()
        {
            var teachers = this.GetRandom(10);

            const int TeachersPerSlide = 4;

            var teachersViewModel = new TeachersViewModel
            {
                Teachers = teachers,
                TeachersCount = teachers.Count(),
                TeachersPerSlide = TeachersPerSlide,
            };

            return teachersViewModel;
        }

        private IEnumerable<SingleTeacherViewModel> GetRandom(int count)
        {
            return this.teachersRepository.AllAsNoTracking()
                .OrderBy(x => Guid.NewGuid())
                .Take(count)
                .Select(x => new SingleTeacherViewModel
                {
                    Id = x.Id,
                    NurseryGroupId = x.NurseryGroupId,
                })
                .ToList();
        }
    }
}
