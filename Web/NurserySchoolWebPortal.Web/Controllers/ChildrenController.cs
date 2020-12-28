namespace NurserySchoolWebPortal.Web.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NurserySchoolWebPortal.Common;
    using NurserySchoolWebPortal.Data;
    using NurserySchoolWebPortal.Data.Common.Repositories;
    using NurserySchoolWebPortal.Data.Models;
    using NurserySchoolWebPortal.Services.Data;
    using NurserySchoolWebPortal.Web.ViewModels.Children;

    public class ChildrenController : BaseController
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IChildrenService childrenService;
        private readonly IDeletableEntityRepository<Principal> principalsRepository;
        private readonly IDeletableEntityRepository<Child> childrenRepository;

        public ChildrenController(
            ApplicationDbContext dbContext,
            IChildrenService childrenService,
            IDeletableEntityRepository<Principal> principalsRepository,
            IDeletableEntityRepository<Child> childrenRepository)
        {
            this.dbContext = dbContext;
            this.childrenService = childrenService;
            this.principalsRepository = principalsRepository;
            this.childrenRepository = childrenRepository;
        }

        [Authorize(Roles = GlobalConstants.ParentRoleName)]
        public IActionResult ById()
        {
            string userName = this.User.Identity.Name;
            var currentUser = this.dbContext.Parents.Include(x => x.Children)
                .FirstOrDefault(x => x.User.Email == userName);
            var childUser = currentUser.Children.FirstOrDefault();
            var groupId = childUser.NurseryGroupId;
            var school = this.dbContext.NurserySchools
                .FirstOrDefault(x => x.NurseryGroups
                .Any(x => x.Id == groupId));

            var child = this.childrenService.ById(childUser.Id);

            return this.View(child);
        }

        [Authorize(Roles = GlobalConstants.PrincipalRoleName)]
        public IActionResult AllPerSchool()
        {
            var principalName = this.User.Identity.Name;
            var currentPrincipal = this.principalsRepository.AllAsNoTracking()
                .FirstOrDefault(x => x.User.UserName == principalName);
            var schoolId = currentPrincipal.NurserySchoolId;

            var children = this.childrenRepository.AllAsNoTrackingWithDeleted()
                .Where(x => x.NurseryGroup.NurserySchoolId == schoolId)
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
    }
}
