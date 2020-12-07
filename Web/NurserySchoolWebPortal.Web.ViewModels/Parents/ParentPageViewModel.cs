namespace NurserySchoolWebPortal.Web.ViewModels.Parents
{
    using System.Collections.Generic;

    public class ParentPageViewModel
    {
        public IEnumerable<PostViewModel> Posts { get; set; }

        public IEnumerable<ImageViewModel> Images { get; set; }

        public int PostsCount { get; set; }
    }
}
