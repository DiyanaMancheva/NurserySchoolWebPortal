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
    using NurserySchoolWebPortal.Web.ViewModels.Fees;

    [Authorize(Roles = GlobalConstants.PrincipalRoleName)]
    public class FeesController : BaseController
    {
        private readonly IDeletableEntityRepository<Principal> principalsRepository;
        private readonly IChildrenService childrenService;
        private readonly IFeesService feesService;

        public FeesController(
            IDeletableEntityRepository<Principal> principalsRepository,
            IChildrenService childrenService,
            IFeesService feesService)
        {
            this.principalsRepository = principalsRepository;
            this.childrenService = childrenService;
            this.feesService = feesService;
        }

        public IActionResult Create()
        {
            var viewModel = new FeeInputModel();
            var userName = this.User.Identity.Name;
            var currentPrincipal = this.principalsRepository.AllAsNoTracking()
                .FirstOrDefault(x => x.User.UserName == userName);
            var schoolId = currentPrincipal.NurserySchoolId;
            viewModel.ChildrenItems = this.childrenService.GetAllAsKeyValuePairsPerSchool(schoolId);

            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FeeInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.feesService.AddAsync(input);

            return this.RedirectToAction("AllPerSchool", "Children", new { area = string.Empty });
        }
    }
}
