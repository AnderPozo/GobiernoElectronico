namespace ProyectoAgendaCultural.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProcedimientosAlmacenados : DbMigration
    {
        public override void Up()
        {
            Sql(RecursosSQL.Listar_sp_Todos_Eventos);
            Sql(RecursosSQL.Listar_sp_Index_Eventos);
        }
        
        public override void Down()
        {
            
        }
    }
}
