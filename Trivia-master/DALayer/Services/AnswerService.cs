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
    public class AnswerService : IService<Answer>
    {
        private static DataTable _dataTable = null;
        private Answer _answer = null;
        private static IList<PropertyInfo> _properties = null;


        //Constructor PlayerDAO
        public AnswerService()
        {
            this._answer = new Answer();
            _properties = DTableExtension.GetPropertiesForType<Answer>();
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
        public static IList<Answer> getAllByQuestionId(int questionId)
        {
            string query = "SELECT * FROM Answer WHERE question_id = @questionId";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@questionId", questionId);
            _dataTable = DbConnection.executeSelectDataTable(query, sqlParameters, CommandType.Text);
            return DTableExtension.ToAnyList<Answer>(_dataTable);
        }

        public IList<Answer> GetAll()
        {
            throw new NotImplementedException();
        }

    }
}
