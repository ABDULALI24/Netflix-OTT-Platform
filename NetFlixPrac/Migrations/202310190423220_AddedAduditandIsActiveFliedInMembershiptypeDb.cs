namespace NetFlixPrac.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAduditandIsActiveFliedInMembershiptypeDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.MembershipTypes", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.MembershipTypes", "UpdatedOn", c => c.DateTime());
            AddColumn("dbo.MembershipTypes", "DeletedOn", c => c.DateTime());
            AddColumn("dbo.MembershipTypes", "CreatedBy", c => c.String());
            AddColumn("dbo.MembershipTypes", "UpdatedBy", c => c.String());
            AddColumn("dbo.MembershipTypes", "DeletedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "DeletedBy");
            DropColumn("dbo.MembershipTypes", "UpdatedBy");
            DropColumn("dbo.MembershipTypes", "CreatedBy");
            DropColumn("dbo.MembershipTypes", "DeletedOn");
            DropColumn("dbo.MembershipTypes", "UpdatedOn");
            DropColumn("dbo.MembershipTypes", "CreatedOn");
            DropColumn("dbo.MembershipTypes", "IsActive");
        }
    }
}
