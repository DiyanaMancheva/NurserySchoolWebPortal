namespace NurserySchoolWebPortal.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NurserySchoolWebPortal.Data.Common.Repositories;
    using NurserySchoolWebPortal.Data.Models;
    using NurserySchoolWebPortal.Services.Data;
    using NurserySchoolWebPortal.Web.ViewModels.Schools;

    public class SchoolsController : AdministrationController
    {
        private readonly IDeletableEntityRepository<NurserySchool> schoolsRepository;
        private readonly IGroupsService groupsService;

        public SchoolsController(
            IDeletableEntityRepository<NurserySchool> schoolsRepository,
            IGroupsService groupsService)
        {
            this.schoolsRepository = schoolsRepository;
            this.groupsService = groupsService;
        }

        public IActionResult Index()
        {
            var schools = this.schoolsRepository.AllAsNoTrackingWithDeleted()
                .Select(x => new SingleSchoolViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreatedOn = x.CreatedOn,
                    ModifiedOn = (System.DateTime)x.ModifiedOn,
                    IsDeleted = x.IsDeleted,
                    DeletedOn = (System.DateTime)x.DeletedOn,
                })
                .ToList();

            var viewModel = new SchoolsViewModel
            {
                Schools = schools,
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var school = await this.schoolsRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => new SingleSchoolViewModel 
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    CreatedOn = x.CreatedOn,
                    ModifiedOn = (DateTime)x.ModifiedOn,
                    Principal = x.Principal.User.FirstName + " " + x.Principal.User.LastName,
                })
                .FirstOrDefaultAsync();

            if (school == null)
            {
                return this.NotFound();
            }

            return this.View(school);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NurserySchool school)
        {
            if (this.ModelState.IsValid)
            {
                await this.schoolsRepository.AddAsync(school);
                await this.schoolsRepository.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(school);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var schoolViewModel = this.schoolsRepository.All()
                .Where(x => x.Id == id)
                .Select(x => new SchoolInputModel
                {
                    Name = x.Name,
                    Address = x.Address,
                    Principal = x.Principal.User.FirstName + " " + x.Principal.User.LastName,
                    ModifiedOn = (DateTime)x.ModifiedOn,
                    CreatedOn = x.CreatedOn,
                    IsDeleted = x.IsDeleted,
                    DeletedOn = (DateTime)x.DeletedOn,
                })
                .FirstOrDefault();

            schoolViewModel.GroupsItems = this.groupsService.GetAllAsKeyValuePairsPerSchool((int)id);

            if (schoolViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(schoolViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SchoolInputModel input)
        {
            if (id != input.Id)
            {
                return this.NotFound();
            }

            var currentSchool = this.schoolsRepository.AllAsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            var school = new NurserySchool
            {
                Id = id,
                Name = input.Name,
                Address = input.Address,
                CreatedOn = currentSchool.CreatedOn,
                ModifiedOn = input.ModifiedOn,
                DeletedOn = currentSchool.DeletedOn,
                IsDeleted = currentSchool.IsDeleted,
            };

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.schoolsRepository.Update(school);
                    await this.schoolsRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.SchoolExists(input.Id))
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

            return this.View(school);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var school = await this.schoolsRepository.All()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (school == null)
            {
                return this.NotFound();
            }

            return this.View(school);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var school = this.schoolsRepository.All().FirstOrDefault(x => x.Id == id);
            this.schoolsRepository.Delete(school);
            await this.schoolsRepository.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool SchoolExists(int id)
        {
            return this.schoolsRepository.All().Any(e => e.Id == id);
        }
    }
}
