using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWithASPNet.Data.VO;
using RestWithASPNet.Model;

namespace RestWithASPNet.Business
{
    public interface IPersonBusiness
    {

        PersonVO Create(PersonVO person);

        PersonVO Update(PersonVO person);

        PersonVO FindById(long id);

        List<PersonVO> FindAll();

        PersonVO Disable(long id);

        void Delete(long id);

    }
}
