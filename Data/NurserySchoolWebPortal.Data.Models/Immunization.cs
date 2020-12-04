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
            this.PersonalInfos = new HashSet<PersonalInfoImmunizations>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public virtual ICollection<PersonalInfoImmunizations> PersonalInfos { get; set; }
    }
}
