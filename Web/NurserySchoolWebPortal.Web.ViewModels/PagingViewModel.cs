namespace NurserySchoolWebPortal.Web.ViewModels
{
    using System;

    public class PagingViewModel
    {
        public int PageNumber { get; set; }

        public int ImagesCount { get; set; }

        public int ImagesPerPage { get; set; }

        public int PagesCount => (int)Math.Ceiling((double)this.ImagesCount / this.ImagesPerPage);

        public bool HasPreviousPage => this.PageNumber > 1;

        public int PreviousPageNumber => this.PageNumber - 1;

        public bool HasNextPage => this.PageNumber < this.PagesCount;

        public int NextPageNumber => this.PageNumber + 1;
    }
}
