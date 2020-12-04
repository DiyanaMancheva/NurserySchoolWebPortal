namespace NurserySchoolWebPortal.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using NurserySchoolWebPortal.Data.Common.Models;

    public class Parent : BaseDeletableModel<int>
    {
        public Parent()
        {
            this.Children = new HashSet<Child>();
        }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Child> Children { get; set; }
    }
}
