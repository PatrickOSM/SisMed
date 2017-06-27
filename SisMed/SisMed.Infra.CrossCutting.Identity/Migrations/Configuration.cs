using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SisMed.Infra.CrossCutting.Identity.Context;
using SisMed.Infra.CrossCutting.Identity.Model;

namespace SisMed.Infra.CrossCutting.Identity.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            
        }
    }
}
