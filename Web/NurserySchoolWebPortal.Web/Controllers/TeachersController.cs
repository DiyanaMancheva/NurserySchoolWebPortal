namespace NurserySchoolWebPortal.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using NurserySchoolWebPortal.Services.Data;
    using NurserySchoolWebPortal.Web.ViewModels.Teachers;

    public class TeachersController : BaseController
    {
        private readonly ITeachersService teachersService;

        public TeachersController(ITeachersService teachersService)
        {
            this.teachersService = teachersService;
        }

        public IActionResult All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int TeachersPerPage = 2;

            var viewModel = new TeachersListViewModel
            {
                ItemsPerPage = TeachersPerPage,
                PageNumber = id,
                ItemsCount = this.teachersService.GetCount(),
                Teachers = this.teachersService.All(id, TeachersPerPage),
            };

            return this.View(viewModel);
        }
    }
}
