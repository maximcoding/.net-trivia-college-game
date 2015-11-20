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
    public class CategoryService : IService<Category>
    {
        private DbConnection _conn;
        private DataTable _dataTable = null;
        private Answer _player = null;
        private IList<PropertyInfo> _properties = null;


        //Constructor PlayerDAO
        public CategoryService()
        {
            this._conn = new DbConnection();
            this._dataTable = new DataTable();
            this._player = new Answer();
            this._properties = DTableExtension.GetPropertiesForType<Category>();
        }


        public Category FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Category entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Category entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public IList<Category> GetAll()
        {
            List<Category> _listGames = new List<Category>();
            string query = "SELECT * FROM Category";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            _dataTable = _conn.executeSelectDataTable(query, sqlParameters, CommandType.Text);
            return DTableExtension.ToAnyList<Category>(_dataTable);
        }
    }
}
