using RestWithASPNet.Data.VO;
using RestWithASPNet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNet.Repository
{
    public interface IUserRepository
    {

        User ValidateCredentials(UserVO user);

        User ValidateCredentials(string username);

        User RefreshUserInfo(User user);

    }
}
