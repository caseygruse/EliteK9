namespace EliteK9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedNotifications : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificationID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        NotificationText = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.NotificationID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Notifications");
        }
    }
}
