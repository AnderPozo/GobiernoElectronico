namespace ProyectoAgendaCultural.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventosCategoriaCalendario : DbMigration
    {
        public override void Up()
        {
            Sql(RecursosSQL.Listar_sp_Eventos_Categoria);
            Sql(RecursosSQL.Listar_sp_Eventos_Calendario);
        }
        
        public override void Down()
        {
        }
    }
}
