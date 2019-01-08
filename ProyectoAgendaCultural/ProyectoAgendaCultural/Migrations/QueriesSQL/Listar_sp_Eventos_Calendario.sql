USE AgendaCulturalDB;  
GO  
CREATE PROCEDURE [AgendaCulturalDB].[sp_EventosCalendario] 
AS   

    SET NOCOUNT ON;
	SELECT ev.Id as Id_evento,ev.Nombre,ev.Descripcion,cl.Fecha,cl.Hora_inicio,cl.Hora_final 
	FROM AgendaCulturalDB.Evento ev
	INNER JOIN AgendaCulturalDB.Calendario cl
	ON cl.EventoId=ev.Id;
GO