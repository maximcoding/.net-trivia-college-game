using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TriviaGame;
using System.Reflection;
using System.Data.SqlClient;


namespace TriviaGame
{
    public class AnswerService : IService<Answer>
    {
        private DbConnection _conn;
        private DataTable _dataTable = null;
        private Answer _answer = null;
        private IList<PropertyInfo> _properties = null;


        //Constructor PlayerDAO
        public AnswerService()
        {
            this._conn = new DbConnection();
            this._dataTable = new DataTable();
            this._answer = new Answer();
            this._properties = DTableExtension.GetPropertiesForType<Answer>();
        }


        public Answer FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Answer entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Answer entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Answer entity)
        {
            throw new NotImplementedException();
        }

        // close question return list.length =4  OR if open question return list.length = 1
        public IList<Answer> getAllByQuestionId(int questionId)
        {
            string query = "SELECT * FROM Answer WHERE question_id = @questionId";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@questionId", questionId);
            _dataTable = _conn.executeSelectDataTable(query, sqlParameters,CommandType.Text);
            return DTableExtension.ToAnyList<Answer>(_dataTable);
        }

        public IList<Answer> GetAll()
        {
            throw new NotImplementedException();
        }

    }
}
