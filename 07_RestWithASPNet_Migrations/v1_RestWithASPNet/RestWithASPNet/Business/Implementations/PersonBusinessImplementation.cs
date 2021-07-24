using RestWithASPNet.Model;
using RestWithASPNet.Model.Context;
using RestWithASPNet.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNet.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IPersonRepository _repository;

        //Saving the context the database
        public PersonBusinessImplementation(IPersonRepository repository)
        {

            _repository = repository;

        }

        //Method for create Person in the database
        public Person Create(Person person)
        {
            try
            {

                return _repository.Create(person);

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
        public List<Person> FindAll()
        {

            return _repository.FindAll();

        }

        //Method for list unique Person in the database
        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }

        //Method for update Person in the database
        public Person Update(Person person)
        {
            try
            {

                return _repository.Update(person);

            }
            catch (Exception)
            {

                throw;

            }
        }

    }
}
