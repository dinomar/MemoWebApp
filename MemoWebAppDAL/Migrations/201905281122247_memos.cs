namespace MemoWebAppDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class memos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Memos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Title = c.String(maxLength: 128),
                        Text = c.String(maxLength: 1028),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Memos", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Memos", new[] { "UserId" });
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Memos");
        }
    }
}
