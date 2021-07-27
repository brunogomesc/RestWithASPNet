using RestWithASPNet.Data.Converter.Implementations;
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
        private readonly BookConverter _converter;

        //Saving the context the database
        public BookBusinessImplementation(IRepository<Book> repository)
        {

            _repository = repository;
            _converter = new BookConverter();

        }

        //Method for create Book in the database
        public BookVO Create(BookVO book)
        {
            try
            {

                var bookEntity = _converter.Parse(book);
                bookEntity = _repository.Create(bookEntity);
                return _converter.Parse(bookEntity);

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
        public List<BookVO> FindAll()
        {

            return _converter.Parse(_repository.FindAll());

        }

        //Method for list unique Person in the database
        public BookVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        //Method for update Book in the database
        public BookVO Update(BookVO book)
        {
            try
            {

                var bookEntity = _converter.Parse(book);
                bookEntity = _repository.Create(bookEntity);
                return _converter.Parse(bookEntity);

            }
            catch (Exception)
            {

                throw;

            }
        }

    }
}
