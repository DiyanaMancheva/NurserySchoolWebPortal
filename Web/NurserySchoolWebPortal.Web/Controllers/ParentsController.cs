namespace NurserySchoolWebPortal.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NurserySchoolWebPortal.Data;
    using NurserySchoolWebPortal.Services.Data;
    using NurserySchoolWebPortal.Web.ViewModels.Parents;

    public class ParentsController : BaseController
    {
        private readonly ApplicationDbContext dbContext;
        //private readonly ParentsService parentsService;

        public ParentsController(ApplicationDbContext dbContext)//, ParentsService parentsService)
        {
            this.dbContext = dbContext;
            //this.parentsService = parentsService;
        }

        [Authorize(Roles = "Parent")]
        public IActionResult PersonalPage()
        {
            //var viewModel = this.parentsService.GetAll();

            string userNam = this.User.Identity.Name;
            var currentUser = this.dbContext.Parents.Include(x => x.Children).FirstOrDefault(x => x.User.Email == userNam);
            var child = currentUser.Children.FirstOrDefault();
            var groupId = child.NurseryGroupId;
            var school = this.dbContext.NurserySchools.FirstOrDefault(x => x.NurseryGroups.Any(x => x.Id == groupId));

            var postsSlide1 = this.dbContext.Posts.Where(x => x.NurserySchoolId == school.Id).Select(x => new PostViewModel
            {
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                Title = x.Title,
                Content = x.Content,
                Created = x.CreatedOn,
            })
                .OrderByDescending(x => x.Created)
                .Take(4)
                .ToList();

            var postsSlide2 = this.dbContext.Posts.Where(x => x.NurserySchoolId == school.Id).Select(x => new PostViewModel
            {
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                Title = x.Title,
                Content = x.Content,
                Created = x.CreatedOn,
            })
                .OrderByDescending(x => x.Created)
                .Skip(4).Take(4)
                .ToList();

            var postsSlide3 = this.dbContext.Posts.Where(x => x.NurserySchoolId == school.Id).Select(x => new PostViewModel
            {
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                Title = x.Title,
                Content = x.Content,
                Created = x.CreatedOn,
            })
                .OrderByDescending(x => x.Created)
                .Skip(8).Take(4)
                .ToList();

            var images = this.dbContext.Images.Where(x => x.NurseryGroupId == currentUser.Children.FirstOrDefault().NurseryGroupId)
                .Where(x => x.NurseryGroupId == groupId).Select(x => new ImageViewModel
                {
                    Id = x.Id,
                    Url = x.Url,
                    Extension = x.Extension,
                })
                .ToList();

            var viewModel = new ParentPageViewModel
            {
                PostsSlide1 = postsSlide1,
                PostsSlide2 = postsSlide2,
                PostsSlide3 = postsSlide3,
                Images = images,
            };

            return this.View(viewModel);
        }
    }
}
