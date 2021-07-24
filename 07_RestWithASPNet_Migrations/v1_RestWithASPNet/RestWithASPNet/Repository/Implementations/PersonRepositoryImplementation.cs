using RestWithASPNet.Model;
using RestWithASPNet.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNet.Repository.Implementations
{
    public class PersonRepositoryImplementation : IPersonRepository
    {
        private SqlContext _context;

        //Saving the context the database
        public PersonRepositoryImplementation(SqlContext context)
        {

            _context = context;

        }

        //Method for create Person in the database
        public Person Create(Person person)
        {
            try
            {

                _context.Add(person);
                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }

            return person;

        }

        //Method for delete Person in the database
        public void Delete(long id)
        {

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {

                try
                {

                    _context.Persons.Remove(result);
                    _context.SaveChanges();

                }
                catch (Exception)
                {

                    throw;
                }

            }

        }

        //Method for list all Persons in the database
        public List<Person> FindAll()
        {

            return _context.Persons.ToList();

        }

        //Method for list unique Person in the database
        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        //Method for update Person in the database
        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return null;

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

            if(result != null)
            {

                try
                {

                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();

                }
                catch (Exception)
                {

                    throw;
                }

            }

            return person;
        }

        //Method for validate the existing Person in the database
        public bool Exists(long id)
        {

            return _context.Persons.Any(p => p.Id.Equals(id));

        }
    }
}
