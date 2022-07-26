using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCadastroSeries.Interfaces
{
    public interface IRepository<T>
    {
        List<T> GetList();
        T ReturnById(int id);
        void Insert(T entity);
        void Delete(int id);
        void Update(int id, T entity);
        int NextId();
    }
}
