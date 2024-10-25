-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Carlos F. Soto Ocio
-- Create date: 09 May 2024
-- Description:	Retorma por SubCategoria los lugares registrados.
-- =============================================
CREATE PROCEDURE GetSubCategoriesAndPoints (
  @SubCatId int,
  @StateId int,
  @Lat float,
  @Lon float,
  @UMed varchar(2) )
AS
BEGIN

/*
 DECLARE @Lat float
 DECLARE @Lon float
 DECLARE @StateId int
 DECLARE @SubCatId int
 DECLARE @UMed varchar(2)

 SET @Lat = 32.5017392
 Set @Lon = -116.9740078
 SET @SubCatId = 1
 SET @UMed = 'Km'
 SET @StateId = 5
 */
 
 DECLARE @origen GEOGRAPHY

 IF @StateId is null
	SET @StateId = 0

 IF @Lat is null
	SET @Lat = 0

 IF @Lon is null
	SET @Lat = 0


 IF (@StateId = 0) and @Lat <> 0 and @Lon <> 0 
 BEGIN
	-- SET @origen = GEOGRAPHY::STPointFromText('POINT(-116.8227545 32.4608383)', 4326);
	SET @origen = GEOGRAPHY::Point(@lat, @Lon, 4326);


	SELECT Top 1 @StateId = Pl.StateId--, @origen.STDistance(GEOGRAPHY::Point(P.Lat, P.Lon, 4326)) / 1000 DistanciaKm 
	FROM Points P
		INNER JOIN dbo.Places Pl ON Pl.PlaceID = P.PlaceId
	WHERE Pl.SubCategoryId = @SubCatId
	ORDER BY @origen.STDistance(GEOGRAPHY::Point(P.Lat, P.Lon, 4326)) --/ 1000 DistanciaKm  

	SELECT SC.SubCategoryId Id, SC.Name
		, Pl.PlaceId, Pl.Name DisplayName, Pl.URLImage
		, CASE @UMed 
			WHEN 'Km' THEN @origen.STDistance(GEOGRAPHY::Point(Pl.Lat, Pl.Lon, 4326)) / 1000 
			ELSE  @origen.STDistance(GEOGRAPHY::Point(Pl.Lat, Pl.Lon, 4326)) / 1609 
			END Distance
		, NP.NumPoints
	FROM SubCategories SC
		INNER JOIN dbo.Places Pl ON Pl.SubCategoryId = SC.SubCategoryId
		LEFT  JOIN (
			SELECT PlaceId, Count(PointId) NumPoints FROM Points 
			GROUP BY PlaceId
		) NP ON NP.PlaceId = Pl.PlaceId
	WHERE Pl.SubCategoryId = @SubCatId And Pl.StateId = @StateId
	
 END
 ELSE
 BEGIN
	SELECT SC.SubCategoryId Id, SC.Name
		, Pl.PlaceId, Pl.Name DisplayName, Pl.URLImage
		, 0 Distance
		, NP.NumPoints
	FROM SubCategories SC
		INNER JOIN dbo.Places Pl ON Pl.SubCategoryId = SC.SubCategoryId
		LEFT  JOIN (
			SELECT PlaceId, Count(PointId) NumPoints FROM Points 
			GROUP BY PlaceId
		) NP ON NP.PlaceId = Pl.PlaceId
	WHERE Pl.SubCategoryId = @SubCatId And Pl.StateId = @StateId 
 END

END
GO



-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Carlos F. Soto Ocio
-- Create date: 29 May 2024
-- Description:	Obtener las muestras de un Punto en una fecha determinada, espedificando la clasificacion.
-- Parameters:
--		@PointId:	 Identificador del Punto de muestreo.
--		@DateC:		 Fecha de las muestras, 
--		@CategoryId: Identificacion de la Categoria.
--		@QSId:		 Identificador del Control de Calidad con el que se evaluaran las muestras.
-- =============================================
CREATE PROCEDURE GetSpesimensByPointId (
 @PointId int,
 @DateC datetime,
 @CategoryId int,
 @QSId int
)
AS
BEGIN
 /*
 DECLARE @PointId int
 DECLARE @DateC datetime
 DECLARE @QSId int
 DECLARE @CategoryId int

 SET @PointId = 33
 SET @DateC = '2024-05-28'
 SET @QSId = 4
 SET @CategoryId = 1
 */

 SET @DateC = DATEADD(d,1,@DateC)

 SELECT R.LabName, R.Method, I.Name ItemName, U.Name UnitName, Cast(R.Value as varchar(10)) Value , U.Abbr UnitAbbr
	, IsNull(QSIR.Notes,'') QS_Notes, IsNull(S.Name, '') QS_Name, IsNull(S.Color, '') QS_Color, IsNull(S.Hex, '') QS_Hex	
 FROM (
	SELECT T.* 
	FROM 
		(SELECT SI.*, ROW_NUMBER() OVER (PARTITION BY SI.LabName, SI.ItemId ORDER BY S.SpesimenDate DESC) AS rnk 
		FROM dbo.Spesimens S 
			INNER JOIN dbo.SpesimenItems SI ON SI.SpesimenId = S.SpesimenId	
			INNER JOIN dbo.Items It ON It.ItemId = SI.ItemId And It.CategoryId = @CategoryId
		WHERE S.PointId = @PointId And S.SpesimenDate < @DateC
		) T
	WHERE T.rnk = 1
	) R
	INNER JOIN dbo.Items I ON I.ItemId = R.ItemId
	INNER JOIN dbo.Units U ON U.UnitId = R.UnitId
	LEFT  JOIN dbo.QualityStandardItems QSI ON QSI.ItemId = R.ItemId And QSI.UnitId = R.UnitId And QSI.QSId = @QSId
	LEFT  JOIN dbo.QualityStandardItemRanges QSIR ON QSIR.QualityStandardItemQSIId = QSI.QSIId 
		And R.Value >= QSIR.LowerLim And R.Value <= QSIR.UpperLim 
	LEFT  JOIN dbo.Semaphores S ON S.SemaphoreId = QSIR.SemaphoreId
 ORDER BY R.LabName, I.Name


END
GO

