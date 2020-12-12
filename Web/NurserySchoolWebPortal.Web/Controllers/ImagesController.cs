namespace NurserySchoolWebPortal.Web.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using NurserySchoolWebPortal.Data;
    using NurserySchoolWebPortal.Services.Data;
    using NurserySchoolWebPortal.Web.ViewModels.Images;

    [Authorize(Roles = "Parent")]
    public class ImagesController : BaseController
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IImagesService imagesService;

        public ImagesController(
            ApplicationDbContext dbContext,
            IImagesService imagesService)
        {
            this.dbContext = dbContext;
            this.imagesService = imagesService;
        }

        public IActionResult AllPerGroup(int id = 1)
        {
            string userNam = this.User.Identity.Name;
            var currentUser = this.dbContext.Parents.Include(x => x.Children).FirstOrDefault(x => x.User.Email == userNam);
            var child = currentUser.Children.FirstOrDefault();
            var groupId = child.NurseryGroupId;
            var school = this.dbContext.NurserySchools.FirstOrDefault(x => x.NurseryGroups.Any(x => x.Id == groupId));

            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ImagesPerPage = 6;

            var viewModel = new ImagesListViewModel
            {
                ImagesPerPage = ImagesPerPage,
                PageNumber = id,
                ImagesCount = this.imagesService.GetCount(groupId),
                Images = this.imagesService.AllPerGroup(groupId, id, ImagesPerPage),
            };

            return this.View(viewModel);
        }
    }
}
