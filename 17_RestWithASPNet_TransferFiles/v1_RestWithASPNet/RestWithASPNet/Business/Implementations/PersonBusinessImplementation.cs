using RestWithASPNet.Data.Converter.Implementations;
using RestWithASPNet.Data.VO;
using RestWithASPNet.Hypermedia.Utils;
using RestWithASPNet.Model;
using RestWithASPNet.Repository;
using RestWithASPNet.Repository.Generic;
using System;
using System.Collections.Generic;

namespace RestWithASPNet.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IPersonRepository _repository;
        private readonly PersonConverter _converter;

        //Saving the context the database
        public PersonBusinessImplementation(IPersonRepository repository)
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

        public PersonVO Disable(long id)
        {

            var personEntity = _repository.Disable(id);

            return _converter.Parse(personEntity);

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

        public List<PersonVO> FindByName(string firstName, string lastName)
        {

            return _converter.Parse(_repository.FindByName(firstName,lastName));

        }

        public PagedSearchVO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pagedSize, int page)
        {

            var sort = (!string.IsNullOrWhiteSpace(sortDirection) && !sortDirection.Equals("desc")) ? "asc" : "desc";

            var size = (pagedSize < 1) ? 10 : pagedSize;

            var offset = page > 0 ? (page - 1) * size : 0;


            //definition script
            string query = @$"select top {size}* from person (nolock) p where 1 = 1  ";

            if (!string.IsNullOrWhiteSpace(name)) query += $"and p.first_name like '%{name}%' ";

            query += $"order by p.first_name {sort}";

            //definiton script on count
            string countQuery = @"select count(*) from person (nolock) p where 1 = 1";

            if (!string.IsNullOrWhiteSpace(name)) countQuery += $"and p.first_name like '%{name}%' ";

            var persons = _repository.FindWithPagedSearch(query);

            int totalResult = _repository.GetCount(countQuery);

            return new PagedSearchVO<PersonVO> {
                CurrentPage = page,
                List = _converter.Parse(persons),
                PagedSize = size,
                SortDirections = sort,
                TotalResult = totalResult
            };

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
