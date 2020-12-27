using System.Collections.Generic;

namespace NurserySchoolWebPortal.Web.ViewModels.Images
{
    public class ImageInputModel
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string Extension { get; set; }

        public int NurseryGroupId { get; set; }

        public string NurseryGroup { get; set; }

        public IEnumerable<KeyValuePair<int, string>> GroupsItems { get; set; }
    }
}
