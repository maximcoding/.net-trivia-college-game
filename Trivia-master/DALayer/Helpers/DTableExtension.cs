using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Collections;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using System.Text;

using DALayer.Helpers;
using DALayer.Services;
using DALayer.Models;

namespace DALayer.Helpers
{
    public static class DTableExtension
    {
        private static Object _lockObjStatic; // locks only static not - thead-safe resourses
        private static Dictionary<Type, IList<PropertyInfo>> typeDictionary;

        static DTableExtension(){
            _lockObjStatic = new object();
            typeDictionary = new Dictionary<Type, IList<PropertyInfo>>();
        }
       
        public static IList<PropertyInfo> GetPropertiesForType<T>()
        {
            lock (_lockObjStatic)
            {
                var type = typeof(T);
                if (!typeDictionary.ContainsKey(typeof(T)))
                {
                    typeDictionary.Add(type, type.GetProperties().ToList());
                }
                return typeDictionary[type];
            }
        }

        public static IList<T> ToAnyList<T>(this DataTable table) where T : new()
        {
            lock (_lockObjStatic)
            {
                IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
                IList<T> result = new List<T>();

                foreach (var row in table.Rows)
                {
                    var item = CreateObjFromRow<T>((DataRow)row, properties);
                    result.Add(item);
                }

                return result;
            }
        }

        public static T CreateObjFromRow<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
        {
            lock (_lockObjStatic)
            {
                var _myObject = Activator.CreateInstance<T>(); // reflection api 
                foreach (var property in properties) // ili typeof(T).GetProperties()
                {
                    if (!object.Equals(row[property.Name], DBNull.Value))
                    {
                        property.SetValue(_myObject, row[property.Name], null);
                    }
                }
                return _myObject;
            }
        }

    }
}
