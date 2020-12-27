namespace NurserySchoolWebPortal.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NurserySchoolWebPortal.Common;
    using NurserySchoolWebPortal.Data.Common.Repositories;
    using NurserySchoolWebPortal.Data.Models;
    using NurserySchoolWebPortal.Services.Data;
    using NurserySchoolWebPortal.Web.ViewModels.Posts;

    public class PostsController : BaseController
    {
        private readonly IPostsService postsService;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly IDeletableEntityRepository<Post> postsRepository;
        private readonly IDeletableEntityRepository<NurserySchool> schoolssRepository;

        public PostsController(
            IPostsService postsService,
            IDeletableEntityRepository<ApplicationUser> usersRepository,
            IDeletableEntityRepository<Post> postsRepository,
            IDeletableEntityRepository<NurserySchool> schoolssRepository)
        {
            this.postsService = postsService;
            this.usersRepository = usersRepository;
            this.postsRepository = postsRepository;
            this.schoolssRepository = schoolssRepository;
        }

        [Authorize(Roles = GlobalConstants.PrincipalRoleName + "," + GlobalConstants.ParentRoleName)]
        public IActionResult AllPerSchool()
        {
            string userName = this.User.Identity.Name;
            const int postsPerPage = 4;

            if (this.User.IsInRole(GlobalConstants.ParentRoleName))
            {
                //var currentUser = this.dbContext.Parents.Include(x => x.Children).FirstOrDefault(x => x.User.Email == userName);
                //var child = currentUser.Children.FirstOrDefault();
                var currentUser = this.usersRepository.AllAsNoTracking()
                    .FirstOrDefault(x => x.UserName == userName);
                var child = currentUser.Parent.Children.FirstOrDefault();
                var groupId = child.NurseryGroupId;
                //var school = this.dbContext.NurserySchools.FirstOrDefault(x => x.NurseryGroups.Any(x => x.Id == groupId));
                var school = this.schoolssRepository.AllAsNoTracking()
                    .FirstOrDefault(x => x.NurseryGroups.Any(x => x.Id == groupId));

                var posts = this.postsService.AllPerSchool(school.Id, postsPerPage);

                return this.View(posts);
            }
            else
            {
                var schoolId = this.usersRepository.AllAsNoTracking()
                    .Where(x => x.UserName == userName)
                    .Select(x => x.Principal.NurserySchoolId)
                    .FirstOrDefault();
                var posts = this.postsService.AllPerSchool(schoolId, postsPerPage);

                return this.View(posts);
            }
        }

        [Authorize(Roles = GlobalConstants.PrincipalRoleName + "," + GlobalConstants.ParentRoleName)]
        public IActionResult GetById(int id)
        {
            var post = this.postsService.GetById(id);

            return this.View(post);
        }

        [Authorize(Roles = GlobalConstants.PrincipalRoleName)]
        public IActionResult Create()
        {
            var viewModel = new PostInputModel();

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.PrincipalRoleName)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var userName = this.User.Identity.Name;
            var schoolId = this.usersRepository.AllAsNoTracking()
                .Where(x => x.UserName == userName)
                .Select(x => x.Principal.NurserySchoolId)
                .FirstOrDefault();

            await this.postsService.AddAsync(input, schoolId);

            return this.RedirectToAction(nameof(this.AllPerSchool));
        }

        [Authorize(Roles = GlobalConstants.PrincipalRoleName)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var post = await this.postsRepository.All()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return this.View(post);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.PrincipalRoleName)]
        public async Task<IActionResult> Delete(int id)
        {
            var post = this.postsRepository.All().FirstOrDefault(x => x.Id == id);
            this.postsRepository.Delete(post);
            await this.postsRepository.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.AllPerSchool));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var postViewModel = this.postsService.GetById((int)id);

            if (postViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(postViewModel);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.PrincipalRoleName)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SinglePostViewModel input)
        {
            var currentPost = this.postsRepository.AllAsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            var post = new Post
            {
                Id = input.Id,
                Title = input.Title,
                Content = input.Content,
                ImageUrl = input.ImageUrl,
                NurserySchoolId = currentPost.NurserySchoolId,
                IsDeleted = currentPost.IsDeleted,
                DeletedOn = currentPost.DeletedOn,
                CreatedOn = currentPost.CreatedOn,
                ModifiedOn = input.ModifiedOn,
            };

            if (id != post.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.postsRepository.Update(post);
                    await this.postsRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.PostExists(post.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return this.RedirectToAction(nameof(this.AllPerSchool));
            }

            return this.View(post);
        }

        private bool PostExists(int id)
        {
            return this.postsRepository.All().Any(x => x.Id == id);
        }
    }
}
