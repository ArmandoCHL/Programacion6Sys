CREATE PROCEDURE [exp].[TipoIdentificacion_Insertar]
		
	@IdTipoIdentificacion int,
	@Descripcion varchar(50)

AS BEGIN
SET NOCOUNT ON

	BEGIN TRANSACTION TRASA 

		BEGIN TRY

		INSERT INTO dbo.TipoIdentificacion
		(Descripcion)
		VALUES
		(@Descripcion)

	COMMIT TRANSACTION TRASA
		SELECT 0 AS CodError, '' AS MsgError

		END TRY

			BEGIN CATCH
				
			SELECT 
				ERROR_NUMBER() AS CodeError,
				ERROR_MESSAGE() AS MsgError

			ROLLBACK TRANSACTION TRASA

			END CATCH

			END

RETURN 0

GO
