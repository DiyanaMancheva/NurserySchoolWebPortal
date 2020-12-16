namespace NurserySchoolWebPortal.Web.ViewModels.Schools
{
    using System.Collections.Generic;

    using NurserySchoolWebPortal.Web.ViewModels.Posts;

    public class SingleSchoolViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public PrincipalViewModel Principal { get; set; }

        public IEnumerable<SinglePostViewModel> Posts { get; set; }
    }
}
