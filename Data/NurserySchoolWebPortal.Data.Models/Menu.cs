namespace NurserySchoolWebPortal.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using NurserySchoolWebPortal.Data.Common.Models;

    public class Menu : BaseDeletableModel<int>
    {
        [Required]
        public DateTime DateFrom { get; set; }

        [Required]
        public DateTime DateTo { get; set; }

        public string Monday { get; set; }

        public string Tuesday { get; set; }

        public string Wednesday { get; set; }

        public string Thursday { get; set; }

        public string Friday { get; set; }

        public int NurserySchoolId { get; set; }

        public virtual NurserySchool NurserySchool { get; set; }
    }
}