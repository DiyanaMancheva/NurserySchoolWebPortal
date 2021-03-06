﻿namespace NurserySchoolWebPortal.Web.ViewModels.Administration.Principals
{
    public class PrincipalViewModel : NurserySchoolWebPortal.Data.Models.ApplicationUser
    {
        public int Id { get; set; }

        public int SchoolId { get; set; }

        public string NurserySchool { get; set; }

        public string DateOfBirthShort { get; set; }
    }
}
