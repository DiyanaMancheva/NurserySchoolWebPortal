namespace NurserySchoolWebPortal.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NurserySchoolWebPortal.Common;
    using NurserySchoolWebPortal.Data.Common.Repositories;
    using NurserySchoolWebPortal.Data.Models;
    using NurserySchoolWebPortal.Services.Data;
    using NurserySchoolWebPortal.Web.ViewModels.PersoonalInfo;

    public class PersonalInfosController : BaseController
    {
        private readonly IDeletableEntityRepository<Principal> principalsRepository;
        private readonly IDeletableEntityRepository<PersonalInfo> personalInfosRepository;
        private readonly IChildrenService childrenService;
        private readonly IPersonalInfosService personalInfosService;

        public PersonalInfosController(
            IDeletableEntityRepository<Principal> principalsRepository,
            IDeletableEntityRepository<PersonalInfo> personalInfosRepository,
            IChildrenService childrenService,
            IPersonalInfosService personalInfosService)
        {
            this.principalsRepository = principalsRepository;
            this.personalInfosRepository = personalInfosRepository;
            this.childrenService = childrenService;
            this.personalInfosService = personalInfosService;
        }

        [Authorize(Roles = GlobalConstants.PrincipalRoleName)]
        public IActionResult Create()
        {
            var viewModel = new PersonalInfoInputModel();
            var userName = this.User.Identity.Name;
            var currentPrincipal = this.principalsRepository.AllAsNoTracking()
                .FirstOrDefault(x => x.User.UserName == userName);
            var schoolId = currentPrincipal.NurserySchoolId;
            viewModel.ChildrenItems = this.childrenService.GetAllAsKeyValuePairsPerSchool(schoolId);

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.PrincipalRoleName)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonalInfoInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.personalInfosService.AddAsync(input);

            return this.RedirectToAction(nameof(this.Create));
        }

        [Authorize(Roles = GlobalConstants.PrincipalRoleName)]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var personalInfoViewModel = this.personalInfosService.GetById((int)id);

            if (personalInfoViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(personalInfoViewModel);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.PrincipalRoleName)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PersonalInfoInputModel input)
        {
            var currentPersonalInfo = this.personalInfosRepository.AllAsNoTracking()
                .FirstOrDefault(x => x.ChildId == id);

            var personalInfo = new PersonalInfo
            {
                Id = currentPersonalInfo.Id,
                Height = input.Height,
                Weight = input.Weight,
                ChildId = currentPersonalInfo.ChildId,
                IsDeleted = currentPersonalInfo.IsDeleted,
                DeletedOn = currentPersonalInfo.DeletedOn,
                CreatedOn = currentPersonalInfo.CreatedOn,
                ModifiedOn = input.ModifiedOn,
            };

            if (id != personalInfo.ChildId)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.personalInfosRepository.Update(personalInfo);
                    await this.personalInfosRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.PersonalInfoExists(personalInfo.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return this.RedirectToAction(nameof(this.Edit));
            }

            return this.View(personalInfo);
        }

        private bool PersonalInfoExists(int id)
        {
            return this.personalInfosRepository.All().Any(x => x.Id == id);
        }
    }
}
