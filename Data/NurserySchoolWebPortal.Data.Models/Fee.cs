namespace NurserySchoolWebPortal.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using NurserySchoolWebPortal.Data.Common.Models;

    public class Fee : BaseDeletableModel<int>
    {
        [Required]
        public string Title { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public double MoneyAmount { get; set; }

        public int ChildId { get; set; }

        public virtual Child Child { get; set; }
    }
}