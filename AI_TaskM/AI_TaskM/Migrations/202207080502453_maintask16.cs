namespace AI_TaskM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class maintask16 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MainTasks", "Progress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MainTasks", "Progress");
        }
    }
}
