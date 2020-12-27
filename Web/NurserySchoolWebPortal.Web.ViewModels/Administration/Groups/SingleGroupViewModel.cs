using NurserySchoolWebPortal.Web.ViewModels.Images;
using System.Collections.Generic;

namespace NurserySchoolWebPortal.Web.ViewModels.Administration.Groups
{
    public class SingleGroupViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string SchoolName { get; set; }

        public int SchoolId { get; set; }

        public string Room { get; set; }

        public IEnumerable<KeyValuePair<int, string>> GroupsItems { get; set; }
    }
}
