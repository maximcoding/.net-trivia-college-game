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
    public class QuestionService : IService<Question>  
    {
        private DbConnection _conn;
        private DataTable _dataTable = null;
        private Question _question = null;
        private IList<PropertyInfo> _properties = null;


        //Constructor PlayerDAO
        public QuestionService()
        {
            this._conn = new DbConnection();
            this._dataTable = new DataTable();
            this._question = new Question();
            this._properties = DTableExtension.GetPropertiesForType<Question>();
        }

         public IList<Question> GetQuestionsByCategoryId(int categoryId)
         {
             List<Question> questionList = new List<Question>();
             string query = "SELECT * FROM Question WHERE category_id = @categoryId";
             SqlParameter[] sqlParameters = new SqlParameter[1];
             sqlParameters[0] = new SqlParameter("@categoryId", categoryId);
             _dataTable = _conn.executeSelectDataTable(query, sqlParameters, CommandType.Text);
             return  DTableExtension.ToAnyList<Question>(_dataTable);
         }

         public Question FindById(int id)
         {
             throw new NotImplementedException();
         }

         public bool Insert(Question entity)
         {
             throw new NotImplementedException();
         }

         public bool Update(Question entity)
         {
             throw new NotImplementedException();
         }

         public bool Delete(Question entity)
         {
             throw new NotImplementedException();
         }

         public IList<Question> GetAll()
         {
             throw new NotImplementedException();
         }

    }
}
