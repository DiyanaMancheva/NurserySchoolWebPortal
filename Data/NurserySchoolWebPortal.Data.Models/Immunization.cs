namespace NurserySchoolWebPortal.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using NurserySchoolWebPortal.Data.Common.Models;

    public class Immunization : BaseDeletableModel<int>
    {
        public Immunization()
        {
            this.PersonalInfos = new HashSet<PersonalInfoImmunization>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public virtual ICollection<PersonalInfoImmunization> PersonalInfos { get; set; }
    }
}
