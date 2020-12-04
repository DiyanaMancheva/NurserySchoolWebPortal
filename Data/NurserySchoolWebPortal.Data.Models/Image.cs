namespace NurserySchoolWebPortal.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using NurserySchoolWebPortal.Data.Common.Models;

    public class Image : BaseDeletableModel<int>
    {
        [Required]
        public string Url { get; set; }

        public string Extension { get; set; }

        [ForeignKey(nameof(NurseryGroup))]
        public int NurseryGroupId { get; set; }

        public virtual NurseryGroup NurseryGroup { get; set; }
    }
}