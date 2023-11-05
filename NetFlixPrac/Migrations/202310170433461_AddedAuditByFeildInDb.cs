namespace NetFlixPrac.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAuditByFeildInDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "CreatedBy", c => c.String());
            AddColumn("dbo.Customers", "UpdatedBy", c => c.String());
            AddColumn("dbo.Customers", "DeletedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "DeletedBy");
            DropColumn("dbo.Customers", "UpdatedBy");
            DropColumn("dbo.Customers", "CreatedBy");
        }
    }
}
