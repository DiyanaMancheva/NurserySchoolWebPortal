namespace NurserySchoolWebPortal.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using NurserySchoolWebPortal.Data.Common.Models;

    public class Post : BaseDeletableModel<int>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string ImageUrl { get; set; }

        [ForeignKey(nameof(NurserySchool))]
        public int NurserySchoolId { get; set; }

        public virtual NurserySchool NurseryShool { get; set; }
    }
}