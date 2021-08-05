using RestWithASPNet.Data.VO;
using RestWithASPNet.Model;
using RestWithASPNet.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RestWithASPNet.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly SqlContext _context;

        public UserRepository(SqlContext context)
        {
            _context = context;
        }

        public User ValidateCredentials(UserVO user)
        {

            var pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
            
            return _context.Users.FirstOrDefault(u => (u.Username == user.Username) && (u.Password == pass));  
        }

        private string ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }
    }
}
