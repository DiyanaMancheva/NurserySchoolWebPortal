namespace NurserySchoolWebPortal.Web.ViewModels.Administration.Principals
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class PrincipalInputModel : NurserySchoolWebPortal.Data.Models.ApplicationUser
    {
        [Required]
        public string Password { get; set; }

        public int NurserySchoolId { get; set; }

        public string NurserySchool { get; set; }

        public IEnumerable<KeyValuePair<int, string>> SchoolsItems { get; set; }
    }
}
