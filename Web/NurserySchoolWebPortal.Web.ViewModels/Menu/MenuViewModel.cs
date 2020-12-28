using System;

namespace NurserySchoolWebPortal.Web.ViewModels.Menu
{
    public class MenuViewModel
    {
        public int Id { get; set; }

        public string DateFrom { get; set; }

        public string DateTo { get; set; }

        public string Monday { get; set; }

        public string Tuesday { get; set; }

        public string Wednesday { get; set; }

        public string Thursday { get; set; }

        public string Friday { get; set; }

        public int SchoolId { get; set; }

        public string SchoolName { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public DateTime DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
