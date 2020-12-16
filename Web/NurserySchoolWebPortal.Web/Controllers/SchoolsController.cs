namespace NurserySchoolWebPortal.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using NurserySchoolWebPortal.Services.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class SchoolsController : BaseController
    {
        private readonly ISchoolsService schoolsService;

        public SchoolsController(ISchoolsService schoolsService)
        {
            this.schoolsService = schoolsService;
        }

        public IActionResult All()
        {
            var schools = this.schoolsService.All();

            return this.View(schools);
        }
    }
}
