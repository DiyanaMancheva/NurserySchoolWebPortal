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
    using NurserySchoolWebPortal.Web.ViewModels.Children;

    public class ChildrenController : AdministrationController
    {
        private readonly IDeletableEntityRepository<Child> childrenRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly IGroupsService groupsService;
        private readonly ISchoolsService schoolsService;
        private readonly IChildrenService childrenService;

        public ChildrenController(
            IDeletableEntityRepository<Child> childrenRepository,
            IDeletableEntityRepository<ApplicationUser> usersRepository,
            IGroupsService groupsService,
            ISchoolsService schoolsService,
            IChildrenService childrenService)
        {
            this.childrenRepository = childrenRepository;
            this.usersRepository = usersRepository;
            this.groupsService = groupsService;
            this.schoolsService = schoolsService;
            this.childrenService = childrenService;
        }

        public IActionResult Index()
        {
            var children = this.childrenRepository.AllAsNoTrackingWithDeleted()
                .Select(x => new ChildViewModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    MiddleName = x.MiddleName,
                    LastName = x.LastName,
                    CreatedOn = x.CreatedOn,
                    ModifiedOn = (System.DateTime)x.ModifiedOn,
                    IsDeleted = x.IsDeleted,
                    DeletedOn = (System.DateTime)x.DeletedOn,
                })
                .ToList();

            var viewModel = new ChildrenViewModel
            {
                Children = children,
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var childViewModel = await this.childrenRepository.All()
                .Where(x => x.Id == id)
                .Select(x => new ChildViewModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    MiddleName = x.MiddleName,
                    LastName = x.LastName,
                    Gender = (int)x.Gender,
                    GroupName = x.NurseryGroup.Name,
                    NurseryGroup = x.NurseryGroupId,
                    SchoolName = x.NurseryGroup.NurserySchool.Name,
                    NurserySchool = x.NurseryGroup.NurserySchoolId,
                    DateOfBirth = x.DateOfBirth.ToShortDateString(),
                    EGN = x.EGN,
                    Address = x.Address,
                    ParentName = x.Parent.User.FirstName + " " + x.Parent.User.LastName,
                    ParentId = x.Parent.Id,
                    PhoneNumber = x.Parent.User.PhoneNumber,
                    CreatedOn = x.CreatedOn,
                    ModifiedOn = (DateTime)x.ModifiedOn,
                    DeletedOn = (DateTime)x.DeletedOn,
                    IsDeleted = x.IsDeleted,
                })
                .FirstOrDefaultAsync();

            if (childViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(childViewModel);
        }

        public IActionResult Create()
        {
            var viewModel = new ChildInputModel();
            viewModel.GroupsItems = this.groupsService.GetAllAsKeyValuePairs();
            viewModel.SchoolsItems = this.schoolsService.GetAllAsKeyValuePairs();

            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ChildInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.childrenService.AddAsync(input);

            return this.RedirectToAction(nameof(this.Index));
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var childViewModel = this.childrenRepository.All()
                .Where(x => x.Id == id)
                .Select(x => new ChildInputModel
                {
                    FirstName = x.FirstName,
                    MiddleName = x.MiddleName,
                    LastName = x.LastName,
                    Address = x.Address,
                    NurseryGroup = x.NurseryGroupId,
                    Parent = x.Parent.Id,
                    ParentName = x.Parent.User.FirstName + " " + x.Parent.User.LastName,
                    PhoneNumber = x.Parent.User.PhoneNumber,
                    CreatedOn = x.CreatedOn,
                    ModifiedOn = (DateTime)x.ModifiedOn,
                    DeletedOn = (DateTime)x.DeletedOn,
                    IsDeleted = x.IsDeleted,
                })
                .FirstOrDefault();

            childViewModel.GroupsItems = this.groupsService.GetAllAsKeyValuePairs();

            if (childViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(childViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ChildInputModel input)
        {
            var currentChild = this.childrenRepository.AllAsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            var groupId = input.GroupName == null ? currentChild.NurseryGroupId
                                                        : int.Parse(input.GroupName);

            var child = new Child
            {
                Id = input.Id,
                FirstName = input.FirstName,
                MiddleName = input.MiddleName,
                LastName = input.LastName,
                Address = input.Address,
                IsDeleted = currentChild.IsDeleted,
                DeletedOn = currentChild.DeletedOn,
                CreatedOn = currentChild.CreatedOn,
                ModifiedOn = input.ModifiedOn,
                NurseryGroupId = groupId,
                DateOfBirth = currentChild.DateOfBirth,
                EGN = currentChild.EGN,
                Gender = currentChild.Gender,
            };

            if (id != child.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.childrenRepository.Update(child);
                    await this.childrenRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.ChildExists(child.Id))
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

            return this.View(child);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var childViewModel = await this.childrenRepository.All()
                .Where(x => x.Id == id)
                .Select(x => new ChildViewModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    MiddleName = x.MiddleName,
                    LastName = x.LastName,
                    GroupName = x.NurseryGroup.Name,
                    SchoolName = x.NurseryGroup.NurserySchool.Name,
                    DateOfBirth = x.DateOfBirth.ToShortDateString(),
                    EGN = x.EGN,
                    Address = x.Address,
                    ParentName = x.Parent.User.FirstName + " " + x.Parent.User.LastName,
                    PhoneNumber = x.Parent.User.PhoneNumber,
                    CreatedOn = x.CreatedOn,
                    ModifiedOn = (DateTime)x.ModifiedOn,
                    DeletedOn = (DateTime)x.DeletedOn,
                    IsDeleted = x.IsDeleted,
                })
                .FirstOrDefaultAsync();

            if (childViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(childViewModel);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var child = this.childrenRepository.All().FirstOrDefault(x => x.Id == id);
            this.childrenRepository.Delete(child);
            await this.childrenRepository.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool ChildExists(int id)
        {
            return this.childrenRepository.All().Any(x => x.Id == id);
        }
    }
}
