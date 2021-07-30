using RestWithASPNet.Data.Converter.Implementations;
using RestWithASPNet.Data.VO;
using RestWithASPNet.Model;
using RestWithASPNet.Repository;
using RestWithASPNet.Repository.Generic;
using System;
using System.Collections.Generic;

namespace RestWithASPNet.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IRepository<Person> _repository;
        private readonly PersonConverter _converter;

        //Saving the context the database
        public PersonBusinessImplementation(IRepository<Person> repository)
        {

            _repository = repository;
            _converter = new PersonConverter();

        }

        //Method for create Person in the database
        public PersonVO Create(PersonVO person)
        {
            try
            {

                var personEntity = _converter.Parse(person);
                personEntity = _repository.Create(personEntity);
                return _converter.Parse(personEntity);

            }
            catch (Exception)
            {

                throw;

            }

        }

        //Method for delete Person in the database
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
        public List<PersonVO> FindAll()
        {

            return _converter.Parse(_repository.FindAll());

        }

        //Method for list unique Person in the database
        public PersonVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        //Method for update Person in the database
        public PersonVO Update(PersonVO person)
        {
            try
            {

                var personEntity = _converter.Parse(person);
                personEntity = _repository.Update(personEntity);
                return _converter.Parse(personEntity);

            }
            catch (Exception)
            {

                throw;

            }
        }

    }
}
