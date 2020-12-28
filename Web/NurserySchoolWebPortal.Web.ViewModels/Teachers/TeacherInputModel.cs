namespace NurserySchoolWebPortal.Web.ViewModels.Teachers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using NurserySchoolWebPortal.Data.Models;

    public class TeacherInputModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public int GroupId { get; set; }

        public string Group { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public DateTime DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public IEnumerable<KeyValuePair<int, string>> GroupsItems { get; set; }
    }
}
