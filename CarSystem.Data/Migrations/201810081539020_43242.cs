namespace CarSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _43242 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CarModels", "ModelName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CarModels", "ModelName", c => c.String(nullable: false));
        }
    }
}
