CREATE PROCEDURE [dbo].[TipoIdentificacion_Obtener]
	
	@IdTipoIdentificacion int = NULL

AS BEGIN
	SET NOCOUNT ON

	SELECT

		TI.IdTipoIdentificacion,
		TI.Descripcion

	FROM dbo.TipoIdentificacion TI

	WHERE 
	(@IdTipoIdentificacion IS NULL OR IdTipoIdentificacion = @IdTipoIdentificacion)

END

GO