DROP TABLE IF EXISTS #TipoIdentificacionTemp

SELECT
	IdTipoIdentificacion, Descripcion INTO #TipoIdentificacionTemp
FROM (

VALUES
(1, 'Cédula'),
(2, 'Pasaporte'),
(3, 'Cédula Jurídica')

) AS TEMP (IdTipoIdentificacion, Descripcion)


---ACTUALIZAR DATOS---

UPDATE TI SET
	TI.Descripcion = TM.Descripcion
FROM dbo.TipoIdentificacion TI
INNER JOIN #TipoIdentificacionTemp TM
	ON TI.Descripcion  = TM.Descripcion


---INSERTAR DATOS---

SET IDENTITY_INSERT dbo.TipoIdentificacion ON

INSERT INTO dbo.TipoIdentificacion(IdTipoIdentificacion, Descripcion)

SELECT 
	IdTipoIdentificacion,
	Descripcion

FROM #TipoIdentificacionTemp

EXCEPT
SELECT 
	IdTipoIdentificacion,
	Descripcion
	
FROM dbo.TipoIdentificacion

SET IDENTITY_INSERT dbo.TipoIdentificacion OFF

GO
