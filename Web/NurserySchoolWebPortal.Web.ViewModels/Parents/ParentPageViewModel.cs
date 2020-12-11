namespace NurserySchoolWebPortal.Web.ViewModels.Parents
{
    using System.Collections.Generic;

    public class ParentPageViewModel
    {
        public IEnumerable<PostViewModel> PostsSlide1 { get; set; }

        public IEnumerable<PostViewModel> PostsSlide2 { get; set; }

        public IEnumerable<PostViewModel> PostsSlide3 { get; set; }

        public IEnumerable<ImageViewModel> Images { get; set; }

        public int PostsCount { get; set; }
    }
}
