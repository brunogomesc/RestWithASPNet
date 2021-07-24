using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWithASPNet.Model;

namespace RestWithASPNet.Repository
{
    public interface IPersonRepository
    {

        Person Create(Person person);

        Person Update(Person person);

        Person FindById(long id);

        List<Person> FindAll();

        void Delete(long id);

        bool Exists(long id);

    }
}
