namespace NurserySchoolWebPortal.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NurserySchoolWebPortal.Data.Common.Repositories;
    using NurserySchoolWebPortal.Data.Models;

    public class ChildrenController : AdministrationController
    {
        private readonly IDeletableEntityRepository<Child> dataRepository;

        public ChildrenController(IDeletableEntityRepository<Child> dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        // GET: Administration/Categories/Details/5
        public async Task<IActionResult> GetById(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var child = await this.dataRepository.All()
                .FirstOrDefaultAsync(x => x.Id == id);
            if (child == null)
            {
                return this.NotFound();
            }

            return this.View(child);
        }
    }
}
