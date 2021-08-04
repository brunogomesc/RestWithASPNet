using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNet.Model
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("users")]
        public string Users { get; set; }

        [Column("full_name")]
        public string FullName { get; set; }

        [Column("pass")]
        public string Password { get; set; }

        [Column("refresh_token")]
        public string RefreshToken { get; set; }

        [Column("refresh_token_expiry_time")]
        public DateTime RefreshTokenExpiredTime { get; set; }

    }
}
