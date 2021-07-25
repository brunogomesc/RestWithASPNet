using RestWithASPNet.Model;
using RestWithASPNet.Repository;
using RestWithASPNet.Repository.Generic;
using System;
using System.Collections.Generic;

namespace RestWithASPNet.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IRepository<Book> _repository;

        //Saving the context the database
        public BookBusinessImplementation(IRepository<Book> repository)
        {

            _repository = repository;

        }

        //Method for create Book in the database
        public Book Create(Book book)
        {
            try
            {

                return _repository.Create(book);

            }
            catch (Exception)
            {

                throw;

            }

        }

        //Method for delete Book in the database
        public void Delete(long id)
        {

            try
            {

                _repository.Delete(id);

            }
            catch (Exception)
            {

                throw;

            }

        }

        //Method for list all Persons in the database
        public List<Book> FindAll()
        {

            return _repository.FindAll();

        }

        //Method for list unique Person in the database
        public Book FindById(long id)
        {
            return _repository.FindById(id);
        }

        //Method for update Book in the database
        public Book Update(Book book)
        {
            try
            {

                return _repository.Update(book);

            }
            catch (Exception)
            {

                throw;

            }
        }

    }
}
