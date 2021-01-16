namespace MvcHtmlHelpers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20201226Migrations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Employees", "Mobile", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Department", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Title", c => c.String());
            AlterColumn("dbo.Employees", "Department", c => c.String());
            AlterColumn("dbo.Employees", "Email", c => c.String());
            AlterColumn("dbo.Employees", "Mobile", c => c.String());
            AlterColumn("dbo.Employees", "Name", c => c.String());
        }
    }
}
