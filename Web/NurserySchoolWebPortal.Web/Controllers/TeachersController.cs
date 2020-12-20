namespace NurserySchoolWebPortal.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NurserySchoolWebPortal.Data;
    using NurserySchoolWebPortal.Services.Data;
    using NurserySchoolWebPortal.Web.ViewModels.Teachers;
    using System.Linq;

    public class TeachersController : BaseController
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ITeachersService teachersService;

        public TeachersController(
            ApplicationDbContext dbContext,
            ITeachersService teachersService)
        {
            this.dbContext = dbContext;
            this.teachersService = teachersService;
        }

        public IActionResult All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int TeachersPerPage = 4;

            var viewModel = new TeachersListViewModel
            {
                ItemsPerPage = TeachersPerPage,
                PageNumber = id,
                ItemsCount = this.teachersService.GetCount(0),
                Teachers = this.teachersService.All(id, TeachersPerPage),
            };

            return this.View(viewModel);
        }

        public IActionResult AllPerGroup(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            string userNam = this.User.Identity.Name;
            var currentUser = this.dbContext.Parents.Include(x => x.Children).FirstOrDefault(x => x.User.Email == userNam);
            var child = currentUser.Children.FirstOrDefault();
            var groupId = child.NurseryGroupId;

            const int TeachersPerPage = 4;

            var viewModel = new TeachersListViewModel
            {
                ItemsPerPage = TeachersPerPage,
                PageNumber = id,
                ItemsCount = this.teachersService.GetCount(groupId),
                Teachers = this.teachersService.AllPerGroup(groupId, id, TeachersPerPage),
            };

            return this.View(viewModel);
        }
    }
}
