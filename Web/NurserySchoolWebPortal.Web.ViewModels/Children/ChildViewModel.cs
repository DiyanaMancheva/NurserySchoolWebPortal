namespace NurserySchoolWebPortal.Web.ViewModels.Children
{
    public class ChildViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public FeeViewModel Fee { get; set; }

        public PersonalInfoViewModel PersonalInfo { get; set; }
    }
}
