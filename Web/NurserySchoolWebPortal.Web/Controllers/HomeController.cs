namespace NurserySchoolWebPortal.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using NurserySchoolWebPortal.Common;
    using NurserySchoolWebPortal.Data;
    using NurserySchoolWebPortal.Data.Common.Repositories;
    using NurserySchoolWebPortal.Data.Models;
    using NurserySchoolWebPortal.Services.Data;
    using NurserySchoolWebPortal.Web.ViewModels;
    using NurserySchoolWebPortal.Web.ViewModels.Administration.Groups;

    public class HomeController : BaseController
    {
        private readonly IGroupsService groupsService;
        private readonly ApplicationDbContext dbContext;
        private readonly IDeletableEntityRepository<NurseryGroup> groupsRepository;

        public HomeController(
            IGroupsService groupsService,
            ApplicationDbContext dbContext,
            IDeletableEntityRepository<NurseryGroup> groupsRepository)
        {
            this.groupsService = groupsService;
            this.dbContext = dbContext;
            this.groupsRepository = groupsRepository;
        }

        public IActionResult Index()
        {
            //if (this.User.IsInRole(GlobalConstants.PrincipalRoleName))
            //{
            //    string userName = this.User.Identity.Name;
            //    var currentUser = this.dbContext.Principals.FirstOrDefault(x => x.User.Email == userName);
            //    var schoolId = currentUser.NurserySchoolId;


            //    var groups = this.groupsRepository.AllAsNoTracking()
            //        .Where(x => x.NurserySchoolId == schoolId)
            //        .Select(x => new SingleGroupViewModel
            //        {
            //            Id = x.Id,
            //            Name = x.Name,
            //        })
            //        .ToList();

            //    var viewModel = new GroupsListViewModel
            //    {
            //        Groups = groups,
            //    };

            //    return this.View(viewModel);

            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
