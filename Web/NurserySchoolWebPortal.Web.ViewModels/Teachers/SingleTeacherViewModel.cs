namespace NurserySchoolWebPortal.Web.ViewModels.Teachers
{
    public class SingleTeacherViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public int NurseryGroupId { get; set; }

        public string NurseryGroup { get; set; }

        public string NurserySchool { get; set; }

        public string ProfilePic { get; set; }

        public string PersonalMessage { get; set; }
    }
}
