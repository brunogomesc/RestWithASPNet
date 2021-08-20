using RestWithASPNet.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNet.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {

        T Create(T item);

        T FindById(long id);

        T Update(T item);

        List<T> FindAll();

        void Delete(long id);

        bool Exists(long id);

        List<T> FindWithPagedSearch(string query);

        int GetCount(string query);

    }
}
