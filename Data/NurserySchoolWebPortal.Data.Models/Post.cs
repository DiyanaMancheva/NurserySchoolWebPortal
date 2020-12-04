namespace NurserySchoolWebPortal.Data.Models
{
    using NurserySchoolWebPortal.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;

    public class Post : BaseDeletableModel<int>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public int NurserySchoolId { get; set; }

        public virtual NurserySchool NurseryShool { get; set; }
    }
}