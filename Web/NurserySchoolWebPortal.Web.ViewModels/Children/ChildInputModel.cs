namespace NurserySchoolWebPortal.Web.ViewModels.Children
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ChildInputModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        public string MiddleName { get; set; }

        [Required]
        [MinLength(3)]
        public string LastName { get; set; }

        public int Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(10)]
        public string EGN { get; set; }

        public string Address { get; set; }

        public int NurseryGroup { get; set; }

        public string GroupName { get; set; }

        public int NurserySchool { get; set; }

        public string SchoolName { get; set; }

        public int Parent { get; set; }

        public string ParentName { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public DateTime DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public IEnumerable<KeyValuePair<int, string>> GroupsItems { get; set; }

        public IEnumerable<KeyValuePair<int, string>> SchoolsItems { get; set; }
    }
}
