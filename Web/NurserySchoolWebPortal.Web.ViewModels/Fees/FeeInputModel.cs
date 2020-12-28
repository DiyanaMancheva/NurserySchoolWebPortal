namespace NurserySchoolWebPortal.Web.ViewModels.Fees
{
    using System;
    using System.Collections.Generic;

    public class FeeInputModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public double MoneyAmount { get; set; }

        public int ChildId { get; set; }

        public string Child { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public IEnumerable<KeyValuePair<int, string>> ChildrenItems { get; set; }
    }
}
