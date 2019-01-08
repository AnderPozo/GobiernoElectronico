USE AgendaCulturalDB;  
GO  
CREATE PROCEDURE [AgendaCulturalDB].[sp_EventosCategoria]
@Id_categoria [int] 
AS
	SET NOCOUNT ON;
	SELECT ct.Id as Id_categoria,ev.Id as Id_evento,ev.Imagen,ev.Nombre as Nombre_evento,
	ct.Nombre as Categoria,cl.Fecha as Fecha_evento
    FROM AgendaCulturalDB.Evento ev
	INNER JOIN AgendaCulturalDB.Categoria ct
	ON ct.Id=ev.CategoriaId
	INNER JOIN AgendaCulturalDB.Calendario cl
	ON cl.EventoId=ev.Id
	WHERE ct.Id=@Id_categoria 
	ORDER BY ev.Id DESC;
GO  