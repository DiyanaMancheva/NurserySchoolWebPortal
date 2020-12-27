namespace NurserySchoolWebPortal.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using NurserySchoolWebPortal.Common;
    using NurserySchoolWebPortal.Data.Common.Repositories;
    using NurserySchoolWebPortal.Data.Models;
    using NurserySchoolWebPortal.Services.Data;
    using NurserySchoolWebPortal.Web.ViewModels.Menu;

    public class MenuController : BaseController
    {
        private readonly IMenuService menuService;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public MenuController(
            IMenuService menuService,
            IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.menuService = menuService;
            this.usersRepository = usersRepository;
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

            return this.RedirectToAction("Index");
        }
    }
}
