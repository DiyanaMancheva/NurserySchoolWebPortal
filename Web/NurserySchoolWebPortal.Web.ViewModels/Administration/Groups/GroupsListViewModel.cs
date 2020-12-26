namespace NurserySchoolWebPortal.Web.ViewModels.Administration.Groups
{
    using NurserySchoolWebPortal.Data.Models;
    using System.Collections.Generic;

    public class GroupsListViewModel
    {
        public IEnumerable<NurseryGroup> Groups { get; set; }
    }
}
