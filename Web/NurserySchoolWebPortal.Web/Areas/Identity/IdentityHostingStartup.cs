using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NurserySchoolWebPortal.Data;
using NurserySchoolWebPortal.Data.Models;

[assembly: HostingStartup(typeof(NurserySchoolWebPortal.Web.Areas.Identity.IdentityHostingStartup))]
namespace NurserySchoolWebPortal.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}