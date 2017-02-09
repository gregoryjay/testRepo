IF OBJECT_ID('dbo.USP_INS_HOLE') IS NULL
BEGIN
    EXEC('CREATE PROC dbo.USP_INS_HOLE AS SET NOCOUNT ON;');
END
GO

ALTER PROCEDURE dbo.USP_INS_HOLE
@COURSE_ID INT,
@TEE_MARKER_ID INT,
@NUMBER INT,
@PAR INT,
@HANDICAP INT,
@YARDAGE INT

AS
BEGIN
	SET NOCOUNT ON;
	BEGIN
		  INSERT INTO dbo.Holes
		          ( CourseId ,
		            TeeMarkerId ,
		            Number ,
		            Handicap ,
		            Yardage,
					Par
		          )
		  VALUES  ( @COURSE_ID, 
		            @TEE_MARKER_ID, 
		            @NUMBER, 
		            @HANDICAP, 
		            @YARDAGE,
					@PAR
		          )
	END;
END;
GO