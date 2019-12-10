namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Добыча",
                c => new
                    {
                        ID_Добычи = c.Guid(nullable: false),
                        Дата = c.DateTime(nullable: false, storeType: "date"),
                        Значение = c.Int(nullable: false),
                        ID_Скважины = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Добычи)
                .ForeignKey("dbo.Скважины", t => t.ID_Скважины)
                .Index(t => t.ID_Скважины);
            
            CreateTable(
                "dbo.Скважины",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Номер = c.String(nullable: false, maxLength: 10),
                        Глубина = c.Int(nullable: false),
                        Тип = c.String(nullable: false, maxLength: 15),
                        Датабурения = c.DateTime(name: "Дата бурения", nullable: false, storeType: "date"),
                        ID_Месторождения = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Месторождения", t => t.ID_Месторождения)
                .Index(t => t.ID_Месторождения);
            
            CreateTable(
                "dbo.Месторождения",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Название = c.String(nullable: false, maxLength: 50),
                        Тип = c.String(nullable: false, maxLength: 30),
                        Датаоткрытия = c.DateTime(name: "Дата открытия", nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Скважины", "ID_Месторождения", "dbo.Месторождения");
            DropForeignKey("dbo.Добыча", "ID_Скважины", "dbo.Скважины");
            DropIndex("dbo.Скважины", new[] { "ID_Месторождения" });
            DropIndex("dbo.Добыча", new[] { "ID_Скважины" });
            DropTable("dbo.Месторождения");
            DropTable("dbo.Скважины");
            DropTable("dbo.Добыча");
        }
    }
}
