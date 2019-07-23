namespace EcoHand.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicializando : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gestos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        UsuarioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Email = c.String(),
                        FechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Secuencias",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        UsuarioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => t.UsuarioID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Secuencias", "UsuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.Gestos", "UsuarioID", "dbo.Usuarios");
            DropIndex("dbo.Secuencias", new[] { "UsuarioID" });
            DropIndex("dbo.Gestos", new[] { "UsuarioID" });
            DropTable("dbo.Secuencias");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Gestos");
        }
    }
}
