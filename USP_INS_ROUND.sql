IF OBJECT_ID('dbo.USP_INS_ROUND') IS NULL
BEGIN
    EXEC('CREATE PROC dbo.USP_INS_ROUND AS SET NOCOUNT ON;');
END
GO

ALTER PROCEDURE dbo.USP_INS_ROUND
@PLAYER_ID INT,
@COURSE_ID INT,
@TEE_TIME DATETIME,
@GROUP_SIZE INT,
@TREE_HOLE INT,
@DRINK_HOLE INT

AS
BEGIN
	SET NOCOUNT ON;
	BEGIN
		  INSERT INTO dbo.Rounds(PlayerId, CourseId, TeeTime, GroupSize, TreeHole, DrinkHole)
		  VALUES  ( @PLAYER_ID,
					@COURSE_ID,
					@TEE_TIME,
					@GROUP_SIZE,
					@TREE_HOLE,
					@DRINK_HOLE)
	END;
END;
GO