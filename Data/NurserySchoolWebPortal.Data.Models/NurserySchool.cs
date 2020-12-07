namespace NurserySchoolWebPortal.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using NurserySchoolWebPortal.Data.Common.Models;

    public class NurserySchool : BaseDeletableModel<int>
    {
        public NurserySchool()
        {
            this.NurseryGroups = new HashSet<NurseryGroup>();
            this.Posts = new HashSet<Post>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        public virtual Principal Principal { get; set; }

        public virtual Menu WeekMenu { get; set; }

        public virtual ICollection<NurseryGroup> NurseryGroups { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
