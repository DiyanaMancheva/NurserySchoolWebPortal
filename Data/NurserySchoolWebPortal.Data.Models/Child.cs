namespace NurserySchoolWebPortal.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using NurserySchoolWebPortal.Data.Common.Models;

    public class Child : BaseDeletableModel<int>
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string EGN { get; set; }

        [Required]
        public string Address { get; set; }

        public virtual PersonalInfo PersonalInfo { get; set; }

        public virtual Fee Fee { get; set; }

        public virtual Parent Parent { get; set; }

        public int NurseryGroupId { get; set; }

        public virtual NurseryGroup NurseryGroup { get; set; }
    }
}
