namespace NurserySchoolWebPortal.Web.Areas.Administration.Controllers
{
    using NurserySchoolWebPortal.Common;
    using NurserySchoolWebPortal.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
