namespace NurserySchoolWebPortal.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using NurserySchoolWebPortal.Services.Data;

    public class TeachersController : BaseController
    {
        private readonly ITeachersService teachersService;

        public TeachersController(ITeachersService teachersService)
        {
            this.teachersService = teachersService;
        }

        public IActionResult All()
        {
            var teachers = this.teachersService.All();

            return this.View(teachers);
        }
    }
}
