using Microsoft.EntityFrameworkCore;
using RestWithASPNet.Model.Base;
using RestWithASPNet.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNet.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {

        protected SqlContext _context;

        private DbSet<T> dataSet;

        //Saving the context the database
        public GenericRepository(SqlContext context)
        {

            _context = context;

            dataSet = context.Set<T>();

        }

        public T Create(T item)
        {
            try
            {

                dataSet.Add(item);
                _context.SaveChanges();
                return item;

            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public void Delete(long id)
        {

            var result = dataSet.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {

                try
                {

                    dataSet.Remove(result);
                    _context.SaveChanges();

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Exists(long id)
        {
            return dataSet.Any(p => p.Id.Equals(id));
        }

        public List<T> FindAll()
        {
            return dataSet.ToList();
        }

        public T FindById(long id)
        {
            return dataSet.SingleOrDefault(p => p.Id.Equals(id));
        }

        public T Update(T item)
        {
            var result = dataSet.SingleOrDefault(p => p.Id.Equals(item.Id));

            if (result != null)
            {

                try
                {

                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return result;

                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {

                return null;

            }
        }
    }
}
