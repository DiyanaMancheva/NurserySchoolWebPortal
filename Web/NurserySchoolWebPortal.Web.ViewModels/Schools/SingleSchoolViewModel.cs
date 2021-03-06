﻿namespace NurserySchoolWebPortal.Web.ViewModels.Schools
{
    using System;
    using System.Collections.Generic;
    using NurserySchoolWebPortal.Data.Models;
    using NurserySchoolWebPortal.Web.ViewModels.Administration.Groups;
    using NurserySchoolWebPortal.Web.ViewModels.Posts;

    public class SingleSchoolViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Principal { get; set; }

        public GroupsListViewModel Groups { get; set; }

        public IEnumerable<SinglePostViewModel> Posts { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public DateTime DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
