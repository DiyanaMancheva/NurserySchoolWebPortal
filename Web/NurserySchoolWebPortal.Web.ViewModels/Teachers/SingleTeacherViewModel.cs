namespace NurserySchoolWebPortal.Web.ViewModels.Teachers
{
    public class SingleTeacherViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => this.FirstName + " " + this.LastName; 

        public int NurseryGroupId { get; set; }

        public string NurserySchool { get; set; }
    }
}
