namespace NurserySchoolWebPortal.Web.ViewModels.Posts
{
    using System.Collections.Generic;

    public class AllPerSchool
    {
        public IEnumerable<SinglePostViewModel> PostsSlide1 { get; set; }

        public IEnumerable<SinglePostViewModel> PostsSlide2 { get; set; }

        public IEnumerable<SinglePostViewModel> PostsSlide3 { get; set; }

        public int PostsCount { get; set; }
    }
}
