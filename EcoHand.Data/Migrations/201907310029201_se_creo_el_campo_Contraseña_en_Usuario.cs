namespace EcoHand.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class se_creo_el_campo_Contraseña_en_Usuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "Contraseña", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "Contraseña");
        }
    }
}
