namespace NurserySchoolWebPortal.Web.ViewModels.Posts
{
    using System;

    public class SinglePostViewModel
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public int NurserySchoolId { get; set; }

        public string ShortContent => this.Content.Length > 100 ? this.Content.Substring(0, 100) + "..." :
            this.Content;
    }
}
