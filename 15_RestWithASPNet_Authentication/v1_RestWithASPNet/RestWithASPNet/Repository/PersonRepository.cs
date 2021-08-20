﻿using RestWithASPNet.Model;
using RestWithASPNet.Model.Context;
using RestWithASPNet.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNet.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {

        public PersonRepository(SqlContext context) : base(context) { }

        public Person Disable(long id)
        {

            if (!_context.Persons.Any(p => p.Id.Equals(id))) return null;

            var user = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

            if(user != null)
            {

                user.Enabled = false;

                try
                {

                    _context.Entry(user).CurrentValues.SetValues(user);
                    _context.SaveChanges();

                }
                catch (Exception)
                {

                    throw;
                }

            }

            return user;

        }
    }
}