namespace NurserySchoolWebPortal.Web.ViewModels.Teachers
{
    using System;
    using System.Collections.Generic;

    public class TeachersViewModel
    {
        public IEnumerable<SingleTeacherViewModel> Teachers { get; set; }

        public int TeachersCount { get; set; }

        public int TeachersPerSlide { get; set; }

        public int SlidesCount => (int)Math.Ceiling((double)this.TeachersCount / this.TeachersPerSlide);


    }
}
