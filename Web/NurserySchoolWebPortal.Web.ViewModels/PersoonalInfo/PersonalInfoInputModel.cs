namespace NurserySchoolWebPortal.Web.ViewModels.PersoonalInfo
{
    using System;
    using System.Collections.Generic;

    using NurserySchoolWebPortal.Data.Models;

    public class PersonalInfoInputModel
    {
        public int Id { get; set; }

        public decimal Height { get; set; }

        public decimal Weight { get; set; }

        public int ChildId { get; set; }

        public string Child { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public IEnumerable<Immunization> Immunizations { get; set; }

        public IEnumerable<KeyValuePair<int, string>> ChildrenItems { get; set; }
    }
}
