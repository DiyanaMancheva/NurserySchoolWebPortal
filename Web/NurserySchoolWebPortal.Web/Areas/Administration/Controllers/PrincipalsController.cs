namespace NurserySchoolWebPortal.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
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

        public PrincipalsController(
            IDeletableEntityRepository<Principal> principalsRepository,
            IDeletableEntityRepository<ApplicationUser> usersRepository,
            IPrincipalsService principalsService,
            ISchoolsService schoolsService)

        {
            this.principalsRepository = principalsRepository;
            this.usersRepository = usersRepository;
            this.principalsService = principalsService;
            this.schoolsService = schoolsService;
        }

        // GET: Administration/Principals
        public async Task<IActionResult> Index()
        {
            var principals = this.principalsRepository.AllAsNoTracking()
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

        //// GET: Administration/Principals/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return this.NotFound();
        //    }

        //    var principal = await this.principalsRepository.All()
        //        .FirstOrDefaultAsync(x => x.Id == id);
        //    if (principal == null)
        //    {
        //        return this.NotFound();
        //    }

        //    return this.View(principal);
        //}

        // GET: Administration/Principals/Create
        public IActionResult Create()
        {
            var viewModel = new PrincipalInputModel();
            viewModel.SchoolsItems = this.schoolsService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        // POST: Administration/Principals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var principalViewModel = this.usersRepository.All()
                .Where(x => x.Principal.Id == id)
                //.Select(x => new PrincipalInputModel
                //{
                //    ModifiedOn = x.ModifiedOn,
                //    CreatedOn = x.CreatedOn,
                //    IsDeleted = x.IsDeleted,
                //    DeletedOn = x.DeletedOn,
                //    NurserySchoolId = x.NurserySchoolId,
                //})
                .FirstOrDefault();

            //principalViewModel.SchoolsItems = this.schoolsService.GetAllAsKeyValuePairs();

            if (principalViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(principalViewModel);
        }

        //// POST: Administration/Principals/Edit/2
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,UserName,Email,Address,PhoneNumber,IsDeleted,DeletedOn,CreatedOn,ModifiedOn")] ApplicationUser user)
        {
            //if (id != user.Principal.Id)
            //{
            //  //return this.NotFound();
            //    return this.RedirectToAction(nameof(this.Index));
            //}

            if (this.ModelState.IsValid)
            {
                try
                {
                    //var currentUser = this.usersRepository.All()
                    //    .FirstOrDefault(x => x.Id == input.Id);

                    //var user = new ApplicationUser
                    //{
                    //    FirstName = input.FirstName,
                    //    LastName = input.LastName,
                    //    UserName = input.UserName,
                    //    Email = input.Email,
                    //    Address = input.Address,
                    //    PhoneNumber = input.PhoneNumber,
                    //    CreatedOn = input.CreatedOn,
                    //    ModifiedOn = input.ModifiedOn,
                    //    IsDeleted = input.IsDeleted,
                    //    DeletedOn = input.DeletedOn,
                    //};

                    //user.Principal.NurserySchoolId = Int32.Parse(input.NurserySchool);

                    //this.usersRepository.Update(user);

                    var userId = this.usersRepository.AllAsNoTracking()
                        .Where(x => x.Principal.Id == id)
                        .Select(x => x.Id)
                        .FirstOrDefault();

                    user.Id = userId;

                    this.usersRepository.Update(user);

                    //await this.usersRepository.SaveChangesAsync();
                    await this.usersRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!this.PrincipalExists(user.Principal.Id))
                    //{
                    //    return this.NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}

                    return this.NotFound();
                }

                return this.RedirectToAction(nameof(this.Index));
                //return this.NotFound();
            }

            return this.View(user);
        }

        //// GET: Administration/Principals/Delete/2
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return this.NotFound();
        //    }

        //    var principal = await this.principalsRepository.All()
        //        .FirstOrDefaultAsync(x => x.Id == id);
        //    if (principal == null)
        //    {
        //        return this.NotFound();
        //    }

        //    return this.View(principal);
        //}

        //// POST: Administration/Categories/Delete/2
        //[HttpPost]
        //[ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var principal = this.principalsRepository.All().FirstOrDefault(x => x.Id == id);
        //    this.principalsRepository.Delete(principal);
        //    await this.principalsRepository.SaveChangesAsync();
        //    return this.RedirectToAction(nameof(this.Index));
        //}

        private bool PrincipalExists(int id)
        {
            return this.principalsRepository.All().Any(e => e.Id == id);
        }
    }
}
