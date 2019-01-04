namespace ProyectoAgendaCultural.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StoreProcedures2 : DbMigration
    {
        public override void Up()
        {
            Sql(RecursosSQL.Listar_sp_Todos_Eventos);
            Sql(RecursosSQL.Listar_sp_Index_Eventos);
            Sql(RecursosSQL.Detalles_sp_Detalles_Eventos);

            Sql(RecursosSQL.Listar_sp_ArtistasTop);     
            Sql(RecursosSQL.Listar_sp_Eventos_de_Artista);
            Sql(RecursosSQL.Listar_sp_Organizadores_Evento);
        }
        
        public override void Down()
        {
        }
    }
}
