namespace AI_TaskM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class maintask15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ToDoes", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.ToDoes", "User_Id");
            AddForeignKey("dbo.ToDoes", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ToDoes", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ToDoes", new[] { "User_Id" });
            DropColumn("dbo.ToDoes", "User_Id");
        }
    }
}
