namespace NurserySchoolWebPortal.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using NurserySchoolWebPortal.Data.Common.Models;

    public class Principal : BaseDeletableModel<int>
    {
        public Principal()
        {
            this.NurserySchools = new HashSet<NurserySchool>();
        }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<NurserySchool> NurserySchools { get; set; }
    }
}
