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

        [Required]
        public string Monday { get; set; }

        [Required]
        public string Tuesday { get; set; }

        [Required]
        public string Wednesday { get; set; }

        [Required]
        public string Thursday { get; set; }

        [Required]
        public string Friday { get; set; }

        public int NurserySchoolId { get; set; }

        public virtual NurserySchool NurserySchool { get; set; }
    }
}