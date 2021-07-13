using RestWithASPNet.Model;
using RestWithASPNet.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RestWithASPNet.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private SqlContext _context;

        public PersonServiceImplementation(SqlContext context)
        {

            _context = context;

        }

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = 1,
                FirstName = "Bruno",
                LastName = "Costa",
                Adress = "Sao Paulo - SP - Brazil",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

    }
}
