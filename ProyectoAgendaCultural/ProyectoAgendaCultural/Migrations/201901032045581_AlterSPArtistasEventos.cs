namespace ProyectoAgendaCultural.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterSPArtistasEventos : DbMigration
    {
        public override void Up()
        {
            Sql(RecursosSQL.Listar_sp_Artistas_Evento);
        }
        
        public override void Down()
        {
        }
    }
}
