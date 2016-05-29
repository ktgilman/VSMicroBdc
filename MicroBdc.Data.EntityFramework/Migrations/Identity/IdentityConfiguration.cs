namespace MicroBdc.Data.EntityFramework.Migrations.Identity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class IdentityConfiguration : DbMigrationsConfiguration<MicroBdc.Data.EntityFramework.Context.IdentityDbContext>
    {
        public IdentityConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MicroBdc.Data.EntityFramework.Context.IdentityDbContext";
        }

        protected override void Seed(MicroBdc.Data.EntityFramework.Context.IdentityDbContext context)
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
        }
    }
}
