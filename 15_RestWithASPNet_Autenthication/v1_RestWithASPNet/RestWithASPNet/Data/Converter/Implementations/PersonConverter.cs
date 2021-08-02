using RestWithASPNet.Data.Converter.Contract;
using RestWithASPNet.Data.VO;
using RestWithASPNet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNet.Data.Converter.Implementations
{
    public class PersonConverter : IParse<PersonVO, Person>, IParse<Person, PersonVO>
    {
        public PersonVO Parse(Person origin)
        {

            if (origin == null) return null;

            return new PersonVO
            {

                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Adress = origin.Adress,
                Gender = origin.Gender

            };

        }

        public List<PersonVO> Parse(List<Person> origin)
        {

            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();

        }

        public Person Parse(PersonVO origin)
        {

            if (origin == null) return null;

            return new Person
            {

                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Adress = origin.Adress,
                Gender = origin.Gender

            };

        }

        public List<Person> Parse(List<PersonVO> origin)
        {

            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();

        }
    }
}
