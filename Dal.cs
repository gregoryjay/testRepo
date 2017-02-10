using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using WPFSandbox.Courses;
using WPFSandbox.Holes;
using WPFSandbox.HoleStats;
using WPFSandbox.Players;
using WPFSandbox.Rounds;

namespace WPFSandbox.DataAccess
{
    public class Dal
    {
        public Dal()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["GolfConnectionString"].ConnectionString;
        }

        private IDbConnection _dbConnection;
        private readonly string _connectionString;

        public IEnumerable<Course> GetAllCourses()
        {
            using (_dbConnection = new SqlConnection(_connectionString))
            {
                return _dbConnection.Query<Course>("SELECT * FROM dbo.Courses", commandType: CommandType.Text);
            }
        }

        internal void UpdateHoleStat(HoleStat _editingHoleStat)
        {
            throw new NotImplementedException();
        }

        internal IEnumerable<RoundStat> GetRoundStats(int roundId)
        {
            using (_dbConnection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ROUND_ID", roundId);

                return _dbConnection.Query<RoundStat>("dbo.USP_GET_ROUND_STATS", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        internal IEnumerable<HoleStat> GetHoleStats(int roundId)
        {
            using (_dbConnection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ROUND_ID", roundId);

                return _dbConnection.Query<HoleStat>("dbo.USP_GET_HOLE_STATS", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        internal void InsertHoleStat(HoleStat holeStat)
        {
            using (_dbConnection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@HOLE_ID", holeStat.HoleId);
                parameters.Add("@ROUND_ID", holeStat.RoundId);
                parameters.Add("@SCORE", holeStat.Score);
                parameters.Add("@GIR", holeStat.Gir);
                parameters.Add("@FWY_HIT", holeStat.FwyHit);
                parameters.Add("@PUTTS", holeStat.Putts);

                _dbConnection.Execute("dbo.USP_INS_HOLE_STAT", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        internal void InsertRound(Round round)
        {
            using (_dbConnection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PLAYER_ID", round.PlayerId);
                parameters.Add("@COURSE_ID", round.CourseId);
                parameters.Add("@TEE_TIME", round.TeeTime);
                parameters.Add("@GROUP_SIZE", round.GroupSize);
                parameters.Add("@TREE_HOLE", round.TreeHole);
                parameters.Add("@DRINK_HOLE", round.DrinkHole);

                _dbConnection.Execute("dbo.USP_INS_ROUND", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        internal void UpdateRound(Round _editingingRound)
        {
            throw new NotImplementedException();
        }

        internal void InsertPlayer(Player player)
        {
            using (_dbConnection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@NAME", player.Name);
                parameters.Add("@HANDICAP", player.Handicap);
                parameters.Add("@AGE", player.Age);
                parameters.Add("@IS_MALE", player.IsMale);

                _dbConnection.Execute("dbo.USP_INS_PLAYER", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        internal void UpdatePlayer(Player _editingPlayer)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CourseStat> GetCourseStats(int courseId)
        {
            using (_dbConnection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@COURSE_ID", courseId);

                return _dbConnection.Query<CourseStat>("dbo.USP_GET_COURSE_STATS", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        internal IEnumerable<Player> GetPlayers()
        {
            using (_dbConnection = new SqlConnection(_connectionString))
            {
                return _dbConnection.Query<Player>("SELECT * FROM dbo.Players", commandType: CommandType.Text);
            }
        }

        internal IEnumerable<Round> GetRounds(int courseId, int playerId)
        {
            using (_dbConnection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@COURSE_ID", courseId);
                parameters.Add("@PLAYER_ID", playerId);

                return _dbConnection.Query<Round>("dbo.USP_GET_ROUNDS", parameters, commandType: CommandType.StoredProcedure);
            }
        }


        internal IEnumerable<Round> GetRounds(int courseId)
        {
            using (_dbConnection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@COURSE_ID", courseId);

                return _dbConnection.Query<Round>("dbo.USP_GET_ROUNDS", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        internal void InsertHole(Hole hole)
        {
            using (_dbConnection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@COURSE_ID", hole.CourseId);
                parameters.Add("@TEE_MARKER_ID", hole.TeeMarkerId);
                parameters.Add("@NUMBER", hole.Number);
                parameters.Add("@PAR", hole.Par);
                parameters.Add("@HANDICAP", hole.Handicap);
                parameters.Add("@YARDAGE", hole.Yardage);

                _dbConnection.Execute("dbo.USP_INS_HOLE", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        internal void UpdateHole(Hole _editingHole)
        {
            throw new NotImplementedException();
        }

        internal IEnumerable<Hole> GetHoles(int courseId, int teeMarkerId)
        {
            using (_dbConnection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@COURSE_ID", courseId);
                parameters.Add("@TEE_MARKER_ID", teeMarkerId);

                return _dbConnection.Query<Hole>("dbo.USP_GET_HOLES", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        internal void InsertCourseStat(CourseStat courseStat)
        {
            using (_dbConnection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@COURSE_ID", courseStat.CourseId);
                parameters.Add("@TEE_MARKER_ID", courseStat.TeeMarkerId);
                parameters.Add("@SLOPE", courseStat.Slope);
                parameters.Add("@RATING", courseStat.Rating);
                parameters.Add("@YARDAGE", courseStat.Yardage);

                _dbConnection.Execute("dbo.USP_INS_COURSE_STAT", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        internal void UpdateCourseStat(CourseStat _editingCourseStat)
        {
            throw new NotImplementedException();
        }

        public void InsertCourse(Course course)
        {
            using (_dbConnection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@NAME", course.Name);
                parameters.Add("@CITY", course.City);
                parameters.Add("@STATE", course.State);
                parameters.Add("@PAR", course.Par);

                _dbConnection.Execute("dbo.USP_INS_COURSE", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateCourse(Course course)
        {
            using (_dbConnection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@COURSE_ID", course.CourseId);
                parameters.Add("@NAME", course.Name);
                parameters.Add("@CITY", course.City);
                parameters.Add("@STATE", course.State);
                parameters.Add("@PAR", course.Par);

                _dbConnection.Execute("RPTG.USP_UPDATE_COURSE", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
