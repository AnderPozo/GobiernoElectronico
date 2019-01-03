namespace ProyectoAgendaCultural.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterArtista : DbMigration
    {
        public override void Up()
        {
            AddColumn("AgendaCulturalDB.Artista", "Fecha_nacimiento", c => c.DateTime(nullable: false));
            AddColumn("AgendaCulturalDB.Artista", "Descripcion", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("AgendaCulturalDB.Artista", "Descripcion");
            DropColumn("AgendaCulturalDB.Artista", "Fecha_nacimiento");
        }
    }
}
