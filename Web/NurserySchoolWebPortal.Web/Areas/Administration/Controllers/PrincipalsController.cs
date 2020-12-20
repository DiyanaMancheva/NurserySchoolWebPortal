namespace NurserySchoolWebPortal.Web.Areas.Administration.Controllers
{
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
        private readonly IPrincipalsService principalsService;
        private readonly ISchoolsService schoolsService;

        public PrincipalsController(
            IDeletableEntityRepository<Principal> principalsRepository,
            IPrincipalsService principalsService,
            ISchoolsService schoolsService)

        {
            this.principalsRepository = principalsRepository;
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
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return this.NotFound();
        //    }

        //    var principal = this.principalsRepository.All().FirstOrDefault(x => x.Id == id);
        //    if (principal == null)
        //    {
        //        return this.NotFound();
        //    }

        //    return this.View(principal);
        //}

        //// POST: Administration/Principals/Edit/2
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("FirstName,LastName,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Principal principal)
        //{
        //    if (id != principal.Id)
        //    {
        //        return this.NotFound();
        //    }

        //    if (this.ModelState.IsValid)
        //    {
        //        try
        //        {
        //            this.principalsRepository.Update(principal);
        //            await this.principalsRepository.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!this.CategoryExists(principal.Id))
        //            {
        //                return this.NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return this.RedirectToAction(nameof(this.Index));
        //    }

        //    return this.View(principal);
        //}

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

        //private bool CategoryExists(int id)
        //{
        //    return this.principalsRepository.All().Any(e => e.Id == id);
        //}
    }
}
