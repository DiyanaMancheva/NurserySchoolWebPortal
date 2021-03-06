﻿using System;

namespace NurserySchoolWebPortal.Web.ViewModels.Teachers
{
    public class SingleTeacherViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public string Address { get; set; }

        public string DateOfBirth { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public DateTime DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public int NurseryGroupId { get; set; }

        public string NurseryGroup { get; set; }

        public string NurserySchool { get; set; }

        public string ProfilePic { get; set; }

        public string PersonalMessage { get; set; }
    }
}
