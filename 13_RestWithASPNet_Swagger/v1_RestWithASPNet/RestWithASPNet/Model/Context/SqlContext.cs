using Microsoft.EntityFrameworkCore;

namespace RestWithASPNet.Model.Context
{
    public class SqlContext : DbContext
    {

        public SqlContext()
        {

        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options){}

        //Propertie Person the Database, with model
        public DbSet<Person> Persons { get; set; }

        public DbSet<Book> Books { get; set; }

    }
}
