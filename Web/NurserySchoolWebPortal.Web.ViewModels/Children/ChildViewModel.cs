namespace NurserySchoolWebPortal.Web.ViewModels.Children
{
    using System;

    public class ChildViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public double FeeMoneyAmount { get; set; }

        public string FeeTitle { get; set; }

        public string FeeDateFrom { get; set; }

        public string FeeDateTo { get; set; }

        public FeeViewModel Fee { get; set; }

        public decimal Weight { get; set; }

        public decimal Height { get; set; }

        public PersonalInfoViewModel PersonalInfo { get; set; }

        public int Gender { get; set; }

        public string Address { get; set; }

        public string DateOfBirth { get; set; }

        public string EGN { get; set; }

        public int NurserySchool { get; set; }

        public string SchoolName { get; set; }

        public int NurseryGroup { get; set; }

        public string GroupName { get; set; }

        public ParentViewModel Parent { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string ParentName { get; set; }

        public int ParentId { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public DateTime DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
