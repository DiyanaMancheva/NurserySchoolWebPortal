namespace NurserySchoolWebPortal.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using NurserySchoolWebPortal.Data.Common.Models;

    public class Teacher : BaseDeletableModel<int>
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public int NurseryGroupId { get; set; }

        public virtual NurseryGroup NurseryGroup { get; set; }
    }
}