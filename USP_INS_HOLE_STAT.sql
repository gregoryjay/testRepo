IF OBJECT_ID('dbo.USP_INS_HOLE_STAT') IS NULL
BEGIN
    EXEC('CREATE PROC dbo.USP_INS_HOLE_STAT AS SET NOCOUNT ON;');
END
GO

ALTER PROCEDURE dbo.USP_INS_HOLE_STAT
@HOLE_ID INT,
@ROUND_ID INT,
@SCORE INT,
@GIR BIT,
@FWY_HIT BIT,
@PUTTS INT

AS
BEGIN
	SET NOCOUNT ON;
	BEGIN
		  INSERT INTO dbo.HoleStats
		          ( HoleId,
					RoundId,
					Score,
					GIR,
					FwyHit,
					Putts
		          )
		  VALUES  ( @HOLE_ID,
					@ROUND_ID,
					@SCORE,
					@GIR,
					@FWY_HIT,
					@PUTTS
		          )
	END;
END;
GO