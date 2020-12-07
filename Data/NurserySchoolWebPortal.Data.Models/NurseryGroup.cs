namespace NurserySchoolWebPortal.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using NurserySchoolWebPortal.Data.Common.Models;

    public class NurseryGroup : BaseDeletableModel<int>
    {
        public NurseryGroup()
        {
            this.Children = new HashSet<Child>();
            this.Teachers = new HashSet<Teacher>();
            this.Images = new HashSet<Image>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Room { get; set; }

        [ForeignKey(nameof(NurserySchool))]
        public int NurserySchoolId { get; set; }

        public virtual NurserySchool NurserySchool { get; set; }

        public virtual ICollection<Child> Children { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}