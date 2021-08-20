using RestWithASPNet.Data.VO;
using RestWithASPNet.Model;
using RestWithASPNet.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNet.Repository
{
    public interface IPersonRepository : IRepository<Person>
    {

        Person Disable(long id);

        List<Person> FindByName(string firstName, string lastName);

    }
}
