namespace NurserySchoolWebPortal.Web.ViewModels.Children
{
    using System.Collections.Generic;

    public class PersonalInfoViewModel
    {
        public int Id { get; set; }

        public decimal Height { get; set; }

        public decimal Weight { get; set; }

        public IEnumerable<ImmunizationViewModel> Immunizations { get; set; }
    }
}
