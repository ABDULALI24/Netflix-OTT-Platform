namespace NetFlixPrac.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAuditOnFeildInDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customers", "UpdatedOn", c => c.DateTime(nullable:true ));
            AddColumn("dbo.Customers", "DeletedOn", c => c.DateTime(nullable:true ));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "DeletedOn");
            DropColumn("dbo.Customers", "UpdatedOn");
            DropColumn("dbo.Customers", "CreatedOn");
        }
    }
}
