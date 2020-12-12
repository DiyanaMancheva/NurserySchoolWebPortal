namespace NurserySchoolWebPortal.Web.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using NurserySchoolWebPortal.Data;
    using NurserySchoolWebPortal.Services.Data;
    using NurserySchoolWebPortal.Web.ViewModels.Children;
    using NurserySchoolWebPortal.Web.ViewModels.Parents;

    public class ParentsController : BaseController
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IParentsService parentsService;

        public ParentsController(ApplicationDbContext dbContext, IParentsService parentsService)
        {
            this.dbContext = dbContext;
            this.parentsService = parentsService;
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

            var fee = this.dbContext.Fees
                .Where(x => x.ChildId == child.Id)
                .Select(x => new FeeViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    DateFrom = x.DateFrom,
                    DateTo = x.DateTo,
                })
                .FirstOrDefault();

            var personalInfo = this.dbContext.PersonalInfos
                .Where(x => x.ChildId == child.Id)
                .Select(x => new PersonalInfoViewModel
                {
                    Id = x.Id,
                    Weight = x.Weight,
                    Height = x.Height,
                })
                .FirstOrDefault();

            var childViewModel = this.dbContext.Children
                .Where(x => x.Id == child.Id)
                .Select(x => new ChildViewModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    MiddleName = x.MiddleName,
                    LastName = x.LastName,
                    Fee = fee,
                    PersonalInfo = personalInfo,
                })
                .FirstOrDefault();

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
                ChildId = child.Id,
                Child = childViewModel,
                PostsSlide1 = postsSlide1,
                PostsSlide2 = postsSlide2,
                PostsSlide3 = postsSlide3,
                Images = images,
            };

            return this.View(viewModel);
        }
    }
}
