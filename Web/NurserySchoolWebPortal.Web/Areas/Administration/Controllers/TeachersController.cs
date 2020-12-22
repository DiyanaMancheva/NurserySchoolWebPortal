namespace NurserySchoolWebPortal.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NurserySchoolWebPortal.Data.Common.Repositories;
    using NurserySchoolWebPortal.Data.Models;
    using NurserySchoolWebPortal.Services.Data;
    using NurserySchoolWebPortal.Web.ViewModels.Teachers;

    public class TeachersController : AdministrationController
    {
        private readonly IDeletableEntityRepository<Teacher> teachersRepository;
        private readonly IGroupsService groupsService;
        private readonly ITeachersService teachersService;

        public TeachersController(
            IDeletableEntityRepository<Teacher> teachersRepository,
            IGroupsService groupsService,
            ITeachersService teachersService)
        {
            this.teachersRepository = teachersRepository;
            this.groupsService = groupsService;
            this.teachersService = teachersService;
        }

        // GET: Administration/Teachers
        public async Task<IActionResult> Index()
        {
            var teachers = this.teachersRepository.AllAsNoTracking()
                .Select(x => new SingleTeacherViewModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    CreatedOn = x.CreatedOn,
                    ModifiedOn = (System.DateTime)x.ModifiedOn,
                    IsDeleted = x.IsDeleted,
                    DeletedOn = (System.DateTime)x.DeletedOn,
                })
                .ToList();

            var viewModel = new TeachersViewModel
            {
                Teachers = teachers,
            };

            return this.View(viewModel);
        }

        // GET: Administration/Teachers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var teacher = await this.teachersRepository.All()
                .FirstOrDefaultAsync(x => x.Id == id);
            if (teacher == null)
            {
                return this.NotFound();
            }

            return this.View(teacher);
        }

        // GET: Administration/Teachers/Create
        public IActionResult Create()
        {
            var viewModel = new TeacherInputModel();
            viewModel.GroupsItems = this.groupsService.GetAllAsKeyValuePairs();

            return this.View(viewModel);
        }

        // POST: Administration/Teachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeacherInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.teachersService.AddAsync(input);

            return this.RedirectToAction(nameof(this.Index));
        }

        // GET: Administration/Teachers/Edit/2
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var teacher = this.teachersRepository.All().FirstOrDefault(x => x.Id == id);
            if (teacher == null)
            {
                return this.NotFound();
            }

            return this.View(teacher);
        }

        // POST: Administration/Teachers/Edit/2
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstName,LastName,NurserySchool,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.teachersRepository.Update(teacher);
                    await this.teachersRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.CategoryExists(teacher.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(teacher);
        }

        // GET: Administration/Teachers/Delete/2
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var teacher = await this.teachersRepository.All()
                .FirstOrDefaultAsync(x => x.Id == id);
            if (teacher == null)
            {
                return this.NotFound();
            }

            return this.View(teacher);
        }

        // POST: Administration/Teachers/Delete/2
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacher = this.teachersRepository.All().FirstOrDefault(x => x.Id == id);
            this.teachersRepository.Delete(teacher);
            await this.teachersRepository.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool CategoryExists(int id)
        {
            return this.teachersRepository.All().Any(e => e.Id == id);
        }
    }
}
