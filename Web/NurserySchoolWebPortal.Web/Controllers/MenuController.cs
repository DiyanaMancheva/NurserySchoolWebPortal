namespace NurserySchoolWebPortal.Web.Controllers
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
    using NurserySchoolWebPortal.Web.ViewModels.Menu;

    public class MenuController : BaseController
    {
        private readonly IMenuService menuService;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly IDeletableEntityRepository<Menu> menuRepository;

        public MenuController(
            IMenuService menuService,
            IDeletableEntityRepository<ApplicationUser> usersRepository,
            IDeletableEntityRepository<Menu> menuRepository)
        {
            this.menuService = menuService;
            this.usersRepository = usersRepository;
            this.menuRepository = menuRepository;
        }

        [Authorize(Roles = GlobalConstants.PrincipalRoleName + "," + GlobalConstants.ParentRoleName)]
        public IActionResult GetCurrent()
        {
            var menu = this.menuService.GetCurrent();

            return this.View(menu);
        }

        [Authorize(Roles = GlobalConstants.PrincipalRoleName)]
        public IActionResult Create()
        {
            var viewModel = new MenuInputModel();

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.PrincipalRoleName)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MenuInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var userName = this.User.Identity.Name;
            var schoolId = this.usersRepository.AllAsNoTracking()
                .Where(x => x.UserName == userName)
                .Select(x => x.Principal.NurserySchoolId)
                .FirstOrDefault();

            await this.menuService.AddAsync(input, schoolId);

            return this.RedirectToAction(nameof(this.GetCurrent));
        }

        [Authorize(Roles = GlobalConstants.PrincipalRoleName)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var menu = await this.menuRepository.All()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return this.View(menu);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.PrincipalRoleName)]
        public async Task<IActionResult> Delete(int id)
        {
            var menu = this.menuRepository.All().FirstOrDefault(x => x.Id == id);
            this.menuRepository.Delete(menu);
            await this.menuRepository.SaveChangesAsync();
            return this.RedirectToAction("Index");
        }

        [Authorize(Roles = GlobalConstants.PrincipalRoleName)]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var menuViewModel = this.menuService.GetById((int)id);

            if (menuViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(menuViewModel);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.PrincipalRoleName)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MenuViewModel input)
        {
            var currentMenu = this.menuRepository.AllAsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            var menu = new Menu
            {
                Id = currentMenu.Id,
                DateFrom = DateTime.Parse(input.DateFrom),
                DateTo = DateTime.Parse(input.DateTo),
                Monday = input.Monday,
                Tuesday = input.Tuesday,
                Wednesday = input.Wednesday,
                Thursday = input.Thursday,
                Friday = input.Friday,
                NurserySchoolId = currentMenu.NurserySchoolId,
                IsDeleted = currentMenu.IsDeleted,
                DeletedOn = currentMenu.DeletedOn,
                CreatedOn = currentMenu.CreatedOn,
                ModifiedOn = input.ModifiedOn,
            };

            if (id != menu.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.menuRepository.Update(menu);
                    await this.menuRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.MenuExists(menu.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return this.RedirectToAction(nameof(this.GetCurrent));
            }

            return this.View(menu);
        }

        private bool MenuExists(int id)
        {
            return this.menuRepository.All().Any(x => x.Id == id);
        }
    }
}
