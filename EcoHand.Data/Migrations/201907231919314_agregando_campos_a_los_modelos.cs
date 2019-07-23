namespace EcoHand.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregando_campos_a_los_modelos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gestos", "Descripcion", c => c.String());
            AddColumn("dbo.Gestos", "FechaCreacion", c => c.DateTime(nullable: false));
            AddColumn("dbo.Gestos", "FechaModificacion", c => c.DateTime(nullable: false));
            AddColumn("dbo.Gestos", "PosPulgar", c => c.Int(nullable: false));
            AddColumn("dbo.Gestos", "Posindice", c => c.Int(nullable: false));
            AddColumn("dbo.Gestos", "PosMayor", c => c.Int(nullable: false));
            AddColumn("dbo.Gestos", "PosAnular", c => c.Int(nullable: false));
            AddColumn("dbo.Gestos", "PosMeñique", c => c.Int(nullable: false));
            AddColumn("dbo.Secuencias", "Descripcion", c => c.String());
            AddColumn("dbo.Secuencias", "FechaCreacion", c => c.DateTime(nullable: false));
            AddColumn("dbo.Secuencias", "FechaModificacion", c => c.DateTime(nullable: false));
            AddColumn("dbo.Secuencias", "CodigoEjecutable", c => c.String());
            AddColumn("dbo.Secuencias", "CodigoEstructura", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Secuencias", "CodigoEstructura");
            DropColumn("dbo.Secuencias", "CodigoEjecutable");
            DropColumn("dbo.Secuencias", "FechaModificacion");
            DropColumn("dbo.Secuencias", "FechaCreacion");
            DropColumn("dbo.Secuencias", "Descripcion");
            DropColumn("dbo.Gestos", "PosMeñique");
            DropColumn("dbo.Gestos", "PosAnular");
            DropColumn("dbo.Gestos", "PosMayor");
            DropColumn("dbo.Gestos", "Posindice");
            DropColumn("dbo.Gestos", "PosPulgar");
            DropColumn("dbo.Gestos", "FechaModificacion");
            DropColumn("dbo.Gestos", "FechaCreacion");
            DropColumn("dbo.Gestos", "Descripcion");
        }
    }
}
