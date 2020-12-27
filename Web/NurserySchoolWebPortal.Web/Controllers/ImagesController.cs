﻿namespace NurserySchoolWebPortal.Web.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NurserySchoolWebPortal.Common;
    using NurserySchoolWebPortal.Data;
    using NurserySchoolWebPortal.Services.Data;
    using NurserySchoolWebPortal.Web.ViewModels.Administration.Groups;
    using NurserySchoolWebPortal.Web.ViewModels.Images;

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

        [Authorize(Roles = GlobalConstants.ParentRoleName)]
        public IActionResult AllPerGroup(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            string userName = this.User.Identity.Name;
            var currentUser = this.dbContext.Parents.Include(x => x.Children).FirstOrDefault(x => x.User.Email == userName);
            var child = currentUser.Children.FirstOrDefault();
            var groupId = child.NurseryGroupId;
            var school = this.dbContext.NurserySchools.FirstOrDefault(x => x.NurseryGroups.Any(x => x.Id == groupId));

            const int ImagesPerPage = 6;

            var viewModel = new ImagesListViewModel
            {
                ItemsPerPage = ImagesPerPage,
                PageNumber = id,
                ItemsCount = this.imagesService.GetCount(groupId),
                Images = this.imagesService.AllPerGroup(groupId, id, ImagesPerPage),
            };

            return this.View(viewModel);
        }
    }
}
