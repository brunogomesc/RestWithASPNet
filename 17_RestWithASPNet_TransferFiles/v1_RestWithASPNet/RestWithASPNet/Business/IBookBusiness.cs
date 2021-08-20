using RestWithASPNet.Data.VO;
using RestWithASPNet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNet.Business
{
    public interface IBookBusiness
    {

        BookVO Create(BookVO person);

        BookVO Update(BookVO person);

        BookVO FindById(long id);

        List<BookVO> FindAll();

        void Delete(long id);

    }
}
