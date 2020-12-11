namespace NurserySchoolWebPortal.Web.ViewModels.Parents
{
    using System;

    public class PostViewModel
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime Created { get; set; }

        public int NurserySchool { get; set; }

        public string ShortContent => this.Content.Length > 50 ? this.Content.Substring(0, 50) + "..." :
            this.Content;
    }
}
