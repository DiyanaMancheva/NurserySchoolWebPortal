namespace NurserySchoolWebPortal.Web.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using NurserySchoolWebPortal.Data;
    using NurserySchoolWebPortal.Services.Data;

    [Authorize(Roles = "Parent")]
    public class PostsController : BaseController
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IPostsService postsService;

        public PostsController(
            ApplicationDbContext dbContext,
            IPostsService postsService)
        {
            this.dbContext = dbContext;
            this.postsService = postsService;
        }

        public IActionResult GetById(int id)
        {
            var post = this.postsService.GetById(id);

            return this.View(post);
        }

        public IActionResult AllPerSchool()
        {
            string userNam = this.User.Identity.Name;
            var currentUser = this.dbContext.Parents.Include(x => x.Children).FirstOrDefault(x => x.User.Email == userNam);
            var child = currentUser.Children.FirstOrDefault();
            var groupId = child.NurseryGroupId;
            var school = this.dbContext.NurserySchools.FirstOrDefault(x => x.NurseryGroups.Any(x => x.Id == groupId));

            var posts = this.postsService.AllPerSchool(school.Id);

            return this.View(posts);
        }
    }
}
