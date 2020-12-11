namespace NurserySchoolWebPortal.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using NurserySchoolWebPortal.Services.Data;

    public class PostsController : BaseController
    {
        private readonly IPostsService postsService;

        public PostsController(IPostsService postsService)
        {
            this.postsService = postsService;
        }

        public IActionResult GetById(int id)
        {
            var post = this.postsService.GetById(id);

            return this.View(post);
        }
    }
}
