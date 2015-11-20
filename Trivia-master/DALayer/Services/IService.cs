using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Services
{
    public interface IService<TObject>
    {
        TObject FindById(int id);
        Boolean Insert(TObject entity);
        Boolean Delete(TObject entity);
        IList<TObject> GetAll();
    }
}
