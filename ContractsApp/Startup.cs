using ContractsApp.Migrations;
using ContractsApp.Models;
using Microsoft.Owin;
using Owin;
using System.Data.Entity;

[assembly: OwinStartupAttribute(typeof(ContractsApp.Startup))]
namespace ContractsApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
            ConfigureAuth(app);
        }
    }
}
