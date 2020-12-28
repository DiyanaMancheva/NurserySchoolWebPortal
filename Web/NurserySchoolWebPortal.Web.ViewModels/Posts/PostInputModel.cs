namespace NurserySchoolWebPortal.Web.ViewModels.Posts
{
    using System.ComponentModel.DataAnnotations;

    public class PostInputModel
    {
        public string ImageUrl { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [MinLength(30)]
        public string Content { get; set; }
    }
}
