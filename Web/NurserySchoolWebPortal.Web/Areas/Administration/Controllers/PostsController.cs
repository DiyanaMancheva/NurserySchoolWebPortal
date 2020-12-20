namespace NurserySchoolWebPortal.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NurserySchoolWebPortal.Data.Common.Repositories;
    using NurserySchoolWebPortal.Data.Models;

    public class PostsController : AdministrationController
    {
        private readonly IDeletableEntityRepository<Post> postsRepository;

        public PostsController(IDeletableEntityRepository<Post> postsRepository)
        {
            this.postsRepository = postsRepository;
        }

        // GET: Administration/Posts
        public async Task<IActionResult> Index()
        {
            return this.View(await this.postsRepository.AllWithDeleted().ToListAsync());
        }

        //// GET: Administration/Teachers/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return this.NotFound();
        //    }

        //    var teacher = await this.teachersRepository.All()
        //        .FirstOrDefaultAsync(x => x.Id == id);
        //    if (teacher == null)
        //    {
        //        return this.NotFound();
        //    }

        //    return this.View(teacher);
        //}

        // GET: Administration/Posts/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Administration/Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Content,ImageUrl,NurserySchoolId,DeletedOn,Id,CreatedOn,ModifiedOn")] Post post)
        {
            if (this.ModelState.IsValid)
            {
                await this.postsRepository.AddAsync(post);
                await this.postsRepository.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(post);
        }

        //// GET: Administration/Teachers/Edit/2
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return this.NotFound();
        //    }

        //    var teacher = this.teachersRepository.All().FirstOrDefault(x => x.Id == id);
        //    if (teacher == null)
        //    {
        //        return this.NotFound();
        //    }

        //    return this.View(teacher);
        //}

        //// POST: Administration/Teachers/Edit/2
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("FirstName,LastName,NurserySchool,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Teacher teacher)
        //{
        //    if (id != teacher.Id)
        //    {
        //        return this.NotFound();
        //    }

        //    if (this.ModelState.IsValid)
        //    {
        //        try
        //        {
        //            this.teachersRepository.Update(teacher);
        //            await this.teachersRepository.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!this.CategoryExists(teacher.Id))
        //            {
        //                return this.NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return this.RedirectToAction(nameof(this.Index));
        //    }

        //    return this.View(teacher);
        //}

        //// GET: Administration/Teachers/Delete/2
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return this.NotFound();
        //    }

        //    var teacher = await this.teachersRepository.All()
        //        .FirstOrDefaultAsync(x => x.Id == id);
        //    if (teacher == null)
        //    {
        //        return this.NotFound();
        //    }

        //    return this.View(teacher);
        //}

        //// POST: Administration/Teachers/Delete/2
        //[HttpPost]
        //[ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var teacher = this.teachersRepository.All().FirstOrDefault(x => x.Id == id);
        //    this.teachersRepository.Delete(teacher);
        //    await this.teachersRepository.SaveChangesAsync();
        //    return this.RedirectToAction(nameof(this.Index));
        //}

        //private bool CategoryExists(int id)
        //{
        //    return this.teachersRepository.All().Any(e => e.Id == id);
        //}
    }
}
