namespace NurserySchoolWebPortal.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NurserySchoolWebPortal.Common;
    using NurserySchoolWebPortal.Data.Common.Repositories;
    using NurserySchoolWebPortal.Data.Models;
    using NurserySchoolWebPortal.Services.Data;
    using NurserySchoolWebPortal.Web.ViewModels.Teachers;

    public class TeachersController : AdministrationController
    {
        private readonly IDeletableEntityRepository<Teacher> teachersRepository;
        private readonly IDeletableEntityRepository<NurseryGroup> groupsRepository;
        private readonly IGroupsService groupsService;
        private readonly ITeachersService teachersService;

        public TeachersController(
            IDeletableEntityRepository<Teacher> teachersRepository,
            IDeletableEntityRepository<NurseryGroup> groupsRepository,
            IGroupsService groupsService,
            ITeachersService teachersService)
        {
            this.teachersRepository = teachersRepository;
            this.groupsRepository = groupsRepository;
            this.groupsService = groupsService;
            this.teachersService = teachersService;
        }

        public async Task<IActionResult> Index()
        {
            var teachers = this.teachersRepository.AllAsNoTrackingWithDeleted()
                .Select(x => new SingleTeacherViewModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    CreatedOn = x.CreatedOn,
                    ModifiedOn = (System.DateTime)x.ModifiedOn,
                    IsDeleted = x.IsDeleted,
                    DeletedOn = (System.DateTime)x.DeletedOn,
                })
                .ToList();

            var viewModel = new TeachersViewModel
            {
                Teachers = teachers,
            };

            return this.View(viewModel);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var teacherViewModel = await this.teachersRepository.All()
                .Where(x => x.Id == id)
                .Select(x => new SingleTeacherViewModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    NurseryGroup = x.NurseryGroup.Name,
                    DateOfBirth = x.DateOfBirth.ToShortDateString(),
                    Address = x.Address,
                    CreatedOn = x.CreatedOn,
                    ModifiedOn = (DateTime)x.ModifiedOn,
                    DeletedOn = (DateTime)x.DeletedOn,
                    IsDeleted = x.IsDeleted,
                })
                .FirstOrDefaultAsync();

            if (teacherViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(teacherViewModel);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Create()
        {
            var viewModel = new TeacherInputModel();
            viewModel.GroupsItems = this.groupsService.GetAllAsKeyValuePairs();

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeacherInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.teachersService.AddAsync(input);

            return this.RedirectToAction(nameof(this.Index));
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var teacherViewModel = this.teachersRepository.All()
                .Where(x => x.Id == id)
                .Select(x => new TeacherInputModel
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Address = x.Address,
                    ModifiedOn = (DateTime)x.ModifiedOn,
                    CreatedOn = x.CreatedOn,
                    IsDeleted = x.IsDeleted,
                    DeletedOn = (DateTime)x.DeletedOn,
                })
                .FirstOrDefault();

            teacherViewModel.GroupsItems = this.groupsService.GetAllAsKeyValuePairs();

            if (teacherViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(teacherViewModel);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TeacherInputModel input)
        {
            var currentTeacher = this.teachersRepository.AllAsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            //var date = DateTime.Now;
            //DateTime.TryParse("01.01.0001 г. 00:00:00                ", out date);
            //var deleted = input.DeletedOn;

            //if (date.ToString() == string.Empty)
            //{
            //    deleted = null;
            //}
            //else
            //{
            //    deleted = input.DeletedOn;
            //}

            var teacher = new Teacher
            {
                Id = input.Id,
                FirstName = input.FirstName,
                LastName = input.LastName,
                Address = input.Address,
                IsDeleted = input.IsDeleted,   // ????????
                DeletedOn = input.DeletedOn,   // ????????
                CreatedOn = input.CreatedOn,   // ????????
                ModifiedOn = input.ModifiedOn, // ????????
                NurseryGroupId = int.Parse(input.Group),
                DateOfBirth = currentTeacher.DateOfBirth,
                Gender = currentTeacher.Gender,
            };

            if (id != teacher.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.teachersRepository.Update(teacher);
                    await this.teachersRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.TeacherExists(teacher.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(teacher);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var teacherViewModel = await this.teachersRepository.All()
                .Where(x => x.Id == id)
                .Select(x => new SingleTeacherViewModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    NurseryGroup = x.NurseryGroup.Name,
                    DateOfBirth = x.DateOfBirth.ToShortDateString(),
                    Address = x.Address,
                    CreatedOn = x.CreatedOn,
                    ModifiedOn = (DateTime)x.ModifiedOn,
                    DeletedOn = (DateTime)x.DeletedOn,
                    IsDeleted = x.IsDeleted,
                })
                .FirstOrDefaultAsync();

            if (teacherViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(teacherViewModel);
        }

        [HttpPost]
        [ActionName("Delete")]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacher = this.teachersRepository.All().FirstOrDefault(x => x.Id == id);
            this.teachersRepository.Delete(teacher);
            await this.teachersRepository.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool TeacherExists(int id)
        {
            return this.teachersRepository.All().Any(x => x.Id == id);
        }
    }
}
