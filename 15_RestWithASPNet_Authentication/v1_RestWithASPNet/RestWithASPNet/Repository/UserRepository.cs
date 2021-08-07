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

            try
            {

                var pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());

                return _context.Users.FirstOrDefault(u => (u.Username == user.Username) && (u.Password == pass));

            }
            catch (Exception)
            {

                throw;
                
            }

        }

        public User RefreshUserInfo(User user)
        {

            if (!_context.Users.Any(u => u.Id.Equals(user.Id))) return null;

            var result = _context.Users.SingleOrDefault(u => u.Id.Equals(user.Id));

            if (result != null)
            {

                try
                {

                    _context.Entry(result).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                    return result;

                }
                catch (Exception)
                {
                    throw;
                }
            }

            return result;

        }

        public User ValidateCredentials(string username)
        {
            return _context.Users.SingleOrDefault(u => u.Username == username);
        }

        public bool RevokeToken(string username)
        {
            
            var user = _context.Users.SingleOrDefault(u => u.Username == username);

            if (user is null) return false;

            user.RefreshToken = null;

            _context.SaveChanges();

            return true;

        }

        private string ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }

    }
}
