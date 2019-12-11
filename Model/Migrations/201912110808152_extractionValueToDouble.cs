namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class extractionValueToDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Добыча", "Значение", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Добыча", "Значение", c => c.Int(nullable: false));
        }
    }
}
