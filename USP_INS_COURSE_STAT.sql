IF OBJECT_ID('dbo.USP_INS_COURSE_STAT') IS NULL
BEGIN
    EXEC('CREATE PROC dbo.USP_INS_COURSE_STAT AS SET NOCOUNT ON;');
END
GO

ALTER PROCEDURE dbo.USP_INS_COURSE_STAT
@COURSE_ID INT,
@TEE_MARKER_ID INT,
@SLOPE INT,
@RATING INT,
@YARDAGE INT

AS
BEGIN
	SET NOCOUNT ON;
	BEGIN
		  INSERT INTO dbo.CourseStats
		          ( CourseId ,
		            TeeMarkerId ,
		            Slope ,
		            Rating ,
		            Yardage
		          )
		  VALUES  ( @COURSE_ID, -- CourseId - int
		            @TEE_MARKER_ID, -- TeeMarkerId - int
		            @SLOPE, -- Slope - int
		            @RATING, -- Rating - int
		            @YARDAGE  -- Yardage - int
		          )
	END;
END;
GO