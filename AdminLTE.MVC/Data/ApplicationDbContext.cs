using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using CMS.MVC.Models;
using CMS.Models;

namespace CMS.MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CMS.Models.tblcaseCategory> tblcaseCategory { get; set; }
        public DbSet<CMS.Models.tblCases> tblCases { get; set; }
        public DbSet<CMS.Models.tblClients> tblClients { get; set; }
        public DbSet<CMS.Models.tblcourt> tblcourt { get; set; }

    }
}
