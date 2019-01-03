USE AgendaCulturalDB;  
GO  
CREATE PROCEDURE [AgendaCulturalDB].[sp_OrganizadoresEvento]
@Id_evento [int] 
AS 
	SET NOCOUNT ON;
	SELECT ev.Id as Id_evento,org.Id as Id_organizador,org.Nombre as Nombre_organizador
	FROM AgendaCulturalDB.Organizador org
	INNER JOIN AgendaCulturalDB.EventoOrganizador evOrg
	ON evOrg.OrganizadorId=org.Id
	INNER JOIN AgendaCulturalDB.Evento ev
	ON ev.Id=evOrg.EventoId
	WHERE ev.Id=@Id_evento;
GO