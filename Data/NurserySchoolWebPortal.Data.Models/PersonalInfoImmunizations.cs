namespace NurserySchoolWebPortal.Data.Models
{
    using NurserySchoolWebPortal.Data.Common.Models;

    public class PersonalInfoImmunizations : BaseDeletableModel<int>
    {
        public int PersonalInfoId { get; set; }

        public virtual PersonalInfo PersonalInfo { get; set; }

        public int ImmunizationId { get; set; }

        public virtual Immunization Immunization { get; set; }
    }
}
