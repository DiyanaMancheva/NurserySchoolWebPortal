namespace NurserySchoolWebPortal.Data.Models
{
    using System.Collections.Generic;

    using NurserySchoolWebPortal.Data.Common.Models;

    public class PersonalInfo : BaseDeletableModel<int>
    {
        public PersonalInfo()
        {
            this.Immunizations = new HashSet<PersonalInfoImmunizations>();
        }

        public decimal Height { get; set; }

        public decimal Weight { get; set; }

        public int ChildId { get; set; }

        public virtual Child Child { get; set; }

        public virtual ICollection<PersonalInfoImmunizations> Immunizations { get; set; }
    }
}