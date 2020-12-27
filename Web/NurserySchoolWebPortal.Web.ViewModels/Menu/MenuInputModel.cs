using System;

namespace NurserySchoolWebPortal.Web.ViewModels.Menu
{
    public class MenuInputModel
    {
        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public string Monday { get; set; }

        public string Tuesday { get; set; }

        public string Wednesday { get; set; }

        public string Thursday { get; set; }

        public string Friday { get; set; }

        public int SchoolId { get; set; }

        public string SchoolName { get; set; }
    }
}
