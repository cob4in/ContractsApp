namespace ContractsApp.Migrations
{
    using ContractsApp.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ContractsApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "ContractsApp.Models.ApplicationDbContext";
        }

        protected override void Seed(ContractsApp.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.MinSalaryEntries.AddOrUpdate(entry => entry.MinSalaryEntryLevelName,
                new MinSalaryEntry("Junior",Utils.JobPosition.Programmer, 2500m).SetUpperBound(3, inclusive: false),
                new MinSalaryEntry("Mid", Utils.JobPosition.Programmer, 5000m).SetLowerBound(3).SetUpperBound(5),
                new MinSalaryEntry("Senior", Utils.JobPosition.Programmer, 5000m).SetLowerBound(5, inclusive: false),
                new MinSalaryEntry("Junior", Utils.JobPosition.Tester, 2000m).SetUpperBound(2, inclusive: false),
                new MinSalaryEntry("Mid", Utils.JobPosition.Tester, 2700m).SetLowerBound(2).SetUpperBound(4),
                new MinSalaryEntry("Senior", Utils.JobPosition.Tester, 3200m).SetLowerBound(4, inclusive: false)
                );
        }
    }
}
