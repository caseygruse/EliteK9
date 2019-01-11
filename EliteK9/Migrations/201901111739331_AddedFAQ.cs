namespace EliteK9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFAQ : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FAQs",
                c => new
                    {
                        QuestionID = c.Int(nullable: false, identity: true),
                        Question = c.String(nullable: false),
                        Answer = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FAQs");
        }
    }
}
