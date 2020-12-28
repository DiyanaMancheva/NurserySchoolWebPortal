namespace NurserySchoolWebPortal.Web.ViewModels.Schools
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class SchoolInputModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        public string Principal { get; set; }

        public string Group { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public DateTime DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public IEnumerable<KeyValuePair<int, string>> GroupsItems { get; set; }
    }
}
