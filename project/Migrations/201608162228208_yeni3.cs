namespace project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yeni3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Uyelers", "Tarih", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Uyelers", "Tarih");
        }
    }
}
