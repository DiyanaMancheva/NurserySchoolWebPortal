namespace NurserySchoolWebPortal.Web.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using NurserySchoolWebPortal.Data;
    using NurserySchoolWebPortal.Services.Data;

    [Authorize(Roles = "Parent")]
    public class ChildrenController : BaseController
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IChildrenService childrenService;

        public ChildrenController(
            ApplicationDbContext dbContext,
            IChildrenService childrenService)
        {
            this.dbContext = dbContext;
            this.childrenService = childrenService;
        }

        public IActionResult ById()
        {
            string userNam = this.User.Identity.Name;
            var currentUser = this.dbContext.Parents.Include(x => x.Children).FirstOrDefault(x => x.User.Email == userNam);
            var childUser = currentUser.Children.FirstOrDefault();
            var groupId = childUser.NurseryGroupId;
            var school = this.dbContext.NurserySchools.FirstOrDefault(x => x.NurseryGroups.Any(x => x.Id == groupId));

            var child = this.childrenService.ById(childUser.Id);

            return this.View(child);
        }
    }
}
