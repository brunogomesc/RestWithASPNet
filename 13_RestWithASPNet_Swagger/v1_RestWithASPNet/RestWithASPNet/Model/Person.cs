using RestWithASPNet.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNet.Model
{
    //Class identifying the columns in the database
    [Table("person")]
    public class Person : BaseEntity
    {

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("adress")]
        public string Adress { get; set; }

        [Column("gender")]
        public string Gender { get; set; }

    }
}
