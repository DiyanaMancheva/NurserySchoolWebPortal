namespace NurserySchoolWebPortal.Web.ViewModels.Schools
{
    public class PrincipalViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => this.FirstName + " " + this.LastName;
    }
}
