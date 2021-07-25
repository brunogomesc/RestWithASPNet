using RestWithASPNet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNet.Business
{
    public interface IBookBusiness
    {

        Book Create(Book person);

        Book Update(Book person);

        Book FindById(long id);

        List<Book> FindAll();

        void Delete(long id);

    }
}
