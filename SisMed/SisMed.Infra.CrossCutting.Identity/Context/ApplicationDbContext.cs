using System;
using Microsoft.AspNet.Identity.EntityFramework;
using SisMed.Infra.CrossCutting.Identity.Model;

namespace SisMed.Infra.CrossCutting.Identity.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDisposable
    {
        public ApplicationDbContext()
            : base("SisMed", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
