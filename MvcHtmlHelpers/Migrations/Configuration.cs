namespace MvcHtmlHelpers.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MvcHtmlHelpers.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcHtmlHelpers.CmsModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MvcHtmlHelpers.CmsModel context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Employees.AddOrUpdate(
                e => e.Id,
                new Employee
                {
                    Id          = 1,
                    Name        = "David",
                    Mobile      = "0935-155-122",
                    Email       = "david@gmail.com",
                    Department  = "總經理室",
                    Title       = "CEO"
                },
                new Employee
                {
                    Id          = 2,
                    Name        = "Mary",
                    Mobile      = "0938-456-889",
                    Email       = "mary@gmail.com",
                    Department  = "人事部",
                    Title       = "管理師"
                },
                new Employee
                {
                    Id          = 3,
                    Name        = "Joe",
                    Mobile      = "0925-331-225",
                    Email       = "joe@gmail.com",
                    Department  = "財務部",
                    Title       = "經理"
                },
                new Employee
                {
                    Id          = 4,
                    Name        = "Mark",
                    Mobile      = "0935-863-991",
                    Email       = "mark@gmail.com",
                    Department  = "業務部",
                    Title       = "業務員"
                },
                new Employee
                {
                    Id          = 5,
                    Name        = "Rose",
                    Mobile      = "0987-335-668",
                    Email       = "rose@gmail.com",
                    Department  = "資訊部",
                    Title       = "工程師"
                }
            );

            context.Registers.AddOrUpdate(
                r => r.Id,
                new Register
                {
                    Id           = 1,
                    Name         = "Ryan",
                    Nickname     = "小馬",
                    Password     = "P@ssw0rd",
                    Email        = "ryan@gmail.com",
                    City         = 4,
                    Gender       = 1,
                    Commutermode = "1",
                    Comment      = "Nothing",
                    Terms        = true
                }
            );
        }
    }
}
