using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Reflection;

using DALayer.Models;
using DALayer.Helpers;

namespace DALayer.Services
{
    public class GameService : IService<Game>
    {
        private static DataTable _dataTable = null;
        private Game _game = null;
        private static IList<PropertyInfo> _properties = null;


        //Constructor PlayerDAO
        public GameService()
        {
            this._game = new Game();
            _properties = DTableExtension.GetPropertiesForType<Game>();
        }

        public Game FindById(int gameId)
        {
            string query = "SELECT * FROM Game WHERE id=@GameId";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@GameId", gameId);
            _dataTable = DbConnection.executeSelectDataTable(query, sqlParameters, CommandType.Text);
            foreach (DataRow _dataRow in _dataTable.Rows)
            {
                _game =  DTableExtension.CreateObjFromRow<Game>(_dataRow, _properties);
            }
            return _game;
        }

        public bool Insert(Game neGame)
        {
            string query = "INSERT INTO Game VALUES(@played_category_id,@player_id,@score,@number_right_questions,@played_date)";
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@played_category_id", neGame.played_category_id);
            sqlParameters[1] = new SqlParameter("@player_id", neGame.player_id);
            sqlParameters[2] = new SqlParameter("@score", neGame.score);
            sqlParameters[3] = new SqlParameter("@number_right_questions", neGame.number_right_questions);
            sqlParameters[4] = new SqlParameter("@played_date", neGame.played_date);
            return DbConnection.executeQuery(query, sqlParameters, CommandType.Text);
        }

        public bool Update(Game game)
        {
            string query = "UPDATE Game SET score=@Score,number_right_questions=@NumberRQ WHERE id=(SELECT MAX(id) FROM Game WHERE player_id=@PlayerId)";
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@score", game.score);
            sqlParameters[1] = new SqlParameter("@NumberRQ", game.number_right_questions);
            sqlParameters[2] = new SqlParameter("@PlayerId", game.player_id);
            return DbConnection.executeQuery(query, sqlParameters, CommandType.Text);
        }

        public Game GetPlayersLastGameResult(int userId)
        {
            var _userGames = new List<Game>();
            string query = "SELECT * FROM Game WHERE id=(SELECT MAX(id) FROM Game WHERE player_id=@UserId)";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@UserId", userId);
            _dataTable = DbConnection.executeSelectDataTable(query, sqlParameters, CommandType.Text);
            foreach (DataRow _dataRow in _dataTable.Rows)
            {
                return DTableExtension.CreateObjFromRow<Game>(_dataRow, _properties);
            }
            return null;
        }

        // result ok 
        public int? GetCountPlayerGames(int userId)
        {
            string query = "SELECT COUNT(id),SUM(score) FROM Game WHERE player_id=@UserId";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@UserId",userId);
            return DbConnection.executeSelectScalar(query, sqlParameters, CommandType.Text);
        }
        // result ok 
        public int? GetCountPlayerTotalScore(int userId)
        {
            string query = "SELECT SUM(score) FROM Game WHERE player_id=@PlayerId";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@PlayerId", userId);
            return DbConnection.executeSelectScalar(query, sqlParameters, CommandType.Text);

        }

        public bool Delete(Game entity)
        {
            throw new NotImplementedException();
        }

        public IList<Game> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
