namespace NurserySchoolWebPortal.Web.ViewModels.Administration.Groups
{
    using System.Collections.Generic;

    using NurserySchoolWebPortal.Data.Models;

    public class GroupsListViewModel
    {
        public IEnumerable<SingleGroupViewModel> Groups { get; set; }
    }
}
