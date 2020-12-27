namespace NurserySchoolWebPortal.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NurserySchoolWebPortal.Common;
    using NurserySchoolWebPortal.Data;
    using NurserySchoolWebPortal.Data.Common.Repositories;
    using NurserySchoolWebPortal.Data.Models;
    using NurserySchoolWebPortal.Services.Data;
    using NurserySchoolWebPortal.Web.ViewModels.Images;

    public class ImagesController : BaseController
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IImagesService imagesService;
        private readonly IGroupsService groupsService;
        private readonly IDeletableEntityRepository<Image> imagesRepository;

        public ImagesController(
            ApplicationDbContext dbContext,
            IImagesService imagesService,
            IGroupsService groupsService,
            IDeletableEntityRepository<Image> imagesRepository)
        {
            this.dbContext = dbContext;
            this.imagesService = imagesService;
            this.groupsService = groupsService;
            this.imagesRepository = imagesRepository;
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

        public IActionResult AllPerSchool(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            string userName = this.User.Identity.Name;
            var currentPrincipal = this.dbContext.Principals
                .FirstOrDefault(x => x.User.UserName == userName);
            var schoolId = currentPrincipal.NurserySchoolId;

            const int ImagesPerPage = 6;

            var viewModel = new ImagesListViewModel
            {
                ItemsPerPage = ImagesPerPage,
                PageNumber = id,
                ItemsCount = this.imagesService.GetCountPerSchool(schoolId),
                Images = this.imagesService.AllPerSchool(schoolId, id, ImagesPerPage),
            };

            return this.View(viewModel);
        }

        [Authorize(Roles = GlobalConstants.PrincipalRoleName)]
        public IActionResult Create()
        {
            var viewModel = new ImageInputModel();
            var userName = this.User.Identity.Name;
            var currentPrincipal = this.dbContext.Principals
                .FirstOrDefault(x => x.User.UserName == userName);
            var schoolId = currentPrincipal.NurserySchoolId;
            viewModel.GroupsItems = this.groupsService.GetAllAsKeyValuePairsPerSchool(schoolId);

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.PrincipalRoleName)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ImageInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.imagesService.AddAsync(input);

            return this.RedirectToAction(nameof(this.AllPerSchool));
        }

        [Authorize(Roles = GlobalConstants.PrincipalRoleName)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var image = await this.imagesRepository.All()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return this.View(image);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.PrincipalRoleName)]
        public async Task<IActionResult> Delete(int id)
        {
            var image = this.imagesRepository.All().FirstOrDefault(x => x.Id == id);
            this.imagesRepository.Delete(image);
            await this.imagesRepository.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.AllPerSchool));
        }
    }
}
