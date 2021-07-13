using Microsoft.EntityFrameworkCore;

namespace RestWithASPNet.Model.Context
{
    public class SqlContext : DbContext
    {

        public SqlContext()
        {

        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options){}

        public DbSet<Person> Persons { get; set; }

    }
}
