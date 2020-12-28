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
    using NurserySchoolWebPortal.Web.ViewModels.Administration.Principals;

    public class PrincipalsController : AdministrationController
    {
        private readonly IDeletableEntityRepository<Principal> principalsRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly IPrincipalsService principalsService;
        private readonly ISchoolsService schoolsService;
        private readonly IDeletableEntityRepository<NurserySchool> schoolsRepository;

        public PrincipalsController(
            IDeletableEntityRepository<Principal> principalsRepository,
            IDeletableEntityRepository<ApplicationUser> usersRepository,
            IPrincipalsService principalsService,
            ISchoolsService schoolsService,
            IDeletableEntityRepository<NurserySchool> schoolsRepository)

        {
            this.principalsRepository = principalsRepository;
            this.usersRepository = usersRepository;
            this.principalsService = principalsService;
            this.schoolsService = schoolsService;
            this.schoolsRepository = schoolsRepository;
        }

        public IActionResult Index()
        {
            var principals = this.principalsRepository.AllAsNoTrackingWithDeleted()
                .Select(x => new PrincipalViewModel
                {
                    Id = x.Id,
                    FirstName = x.User.FirstName,
                    LastName = x.User.LastName,
                    CreatedOn = x.CreatedOn,
                    ModifiedOn = x.ModifiedOn,
                    IsDeleted = x.IsDeleted,
                    DeletedOn = x.DeletedOn,
                    SchoolId = x.NurserySchoolId,
                })
                .ToList();

            var viewModel = new PrincipalsListViewModel
            {
                Principals = principals,
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }


            var schoolName = this.schoolsRepository.AllAsNoTracking()
                .Where(x => x.Principal.Id == id)
                .Select(x => x.Name)
                .FirstOrDefault();

            var principalViewModel = await this.principalsRepository.All()
                .Where(x => x.Id == id)
                .Select(x => new PrincipalViewModel
                {
                    Id = x.Id,
                    FirstName = x.User.FirstName,
                    LastName = x.User.LastName,
                    NurserySchool = schoolName,
                    DateOfBirthShort = x.User.DateOfBirth.ToShortDateString(),
                    Address = x.User.Address,
                    PhoneNumber = x.User.PhoneNumber,
                    UserName = x.User.UserName,
                    Email = x.User.Email,
                    CreatedOn = x.CreatedOn,
                    ModifiedOn = (DateTime)x.ModifiedOn,
                    DeletedOn = (DateTime)x.DeletedOn,
                    IsDeleted = x.IsDeleted,
                })
                .FirstOrDefaultAsync();


            if (principalViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(principalViewModel);
        }

        public IActionResult Create()
        {
            var viewModel = new PrincipalInputModel();
            viewModel.SchoolsItems = this.schoolsService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PrincipalInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.principalsService.AddAsync(input);

            return this.RedirectToAction("Index");
        }

        //// GET: Administration/Principals/Edit/2
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var principal = this.usersRepository.All()
                .Where(x => x.Principal.Id == id)
                .Select(x => new ApplicationUser
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserName = x.UserName,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    Address = x.Address,
                })
                .FirstOrDefault();

            if (principal == null)
            {
                return this.NotFound();
            }

            return this.View(principal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ApplicationUser input)
        {
            var currentUser = this.usersRepository.AllAsNoTracking()
                    .FirstOrDefault(x => x.Principal.Id == id);
            var currentPrincipal = this.usersRepository.AllAsNoTracking()
                .Where(x => x.Principal.Id == id)
                .Select(x => new Principal
                {
                    Id = x.Principal.Id,
                    CreatedOn = x.Principal.CreatedOn,
                    ModifiedOn = x.Principal.ModifiedOn,
                    IsDeleted = x.Principal.IsDeleted,
                    DeletedOn = x.DeletedOn,
                    UserId = x.Id,
                    NurserySchoolId = x.Principal.NurserySchoolId,
                })
                .FirstOrDefault();

            var user = new ApplicationUser
            {
                Id = currentUser.Id,
                FirstName = input.FirstName,
                LastName = input.LastName,
                UserName = input.UserName,
                Email = input.Email,
                PhoneNumber = input.PhoneNumber,
                Address = input.Address,
                CreatedOn = currentUser.CreatedOn,
                ModifiedOn = currentUser.ModifiedOn,
                IsDeleted = currentUser.IsDeleted,
                Gender = currentUser.Gender,
                UserType = currentUser.UserType,
                DateOfBirth = currentUser.DateOfBirth,
                AccessFailedCount = currentUser.AccessFailedCount,
                LockoutEnabled = currentUser.LockoutEnabled,
                TwoFactorEnabled = currentUser.TwoFactorEnabled,
                PhoneNumberConfirmed = currentUser.PhoneNumberConfirmed,
                EmailConfirmed = currentUser.EmailConfirmed,
            };

            var principal = new Principal
            {
                Id = currentPrincipal.Id,
                CreatedOn = currentPrincipal.CreatedOn,
                ModifiedOn = currentUser.ModifiedOn,
                UserId = currentPrincipal.UserId,
                IsDeleted = currentUser.IsDeleted,
                DeletedOn = currentUser.DeletedOn,
                NurserySchoolId = currentPrincipal.NurserySchoolId,
            };

            if (id != principal.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.principalsRepository.Update(principal);
                    await this.principalsRepository.SaveChangesAsync();
                    this.usersRepository.Update(user);
                    await this.usersRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.PrincipalExists(user.Principal.Id))
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

            return this.View(user);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var principalViewModel = await this.principalsRepository.All()
                .Where(x => x.Id == id)
                .Select(x => new PrincipalViewModel
                {
                    Id = x.Id,
                    FirstName = x.User.FirstName,
                    LastName = x.User.LastName,
                    NurserySchool = x.School.Name,
                    DateOfBirthShort = x.User.DateOfBirth.ToShortDateString(),
                    Address = x.User.Address,
                    UserName = x.User.UserName,
                    PhoneNumber = x.User.PhoneNumber,
                    Email = x.User.Email,

                    CreatedOn = x.CreatedOn,
                    ModifiedOn = (DateTime)x.ModifiedOn,
                    DeletedOn = (DateTime)x.DeletedOn,
                    IsDeleted = x.IsDeleted,
                })
                .FirstOrDefaultAsync();

            if (principalViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(principalViewModel);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var principal = this.principalsRepository.All().FirstOrDefault(x => x.Id == id);
            var user = this.usersRepository.All().FirstOrDefault(x => x.Principal.Id == id);
            this.principalsRepository.Delete(principal);
            this.usersRepository.Delete(user);
            await this.principalsRepository.SaveChangesAsync();
            await this.usersRepository.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool PrincipalExists(int id)
        {
            return this.principalsRepository.All().Any(e => e.Id == id);
        }
    }
}
