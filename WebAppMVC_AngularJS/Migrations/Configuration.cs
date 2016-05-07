namespace WebAppMVC_AngularJS.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebAppMVC_AngularJS.Models.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebAppMVC_AngularJS.Models.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.People.AddOrUpdate(
              p => p.Name,
              new People {Name= "Andrew", NickName = "Andrew_Peters" },
              new People {Name= "Brice",   NickName = "Brice_Lambson" },
              new People {Name= "Rowan",   NickName = "Rowan_Miller" }
            );
            //
        }
    }
}
