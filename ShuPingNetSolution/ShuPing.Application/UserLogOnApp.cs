using ShuPing.Entity;
using ShuPing.Interface.IRepository;
using ShuPing.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuPing.Application
{
    public class UserLogOnApp
    {
        private IUserLoginRepository service = new UserLogOnRepository();

        public UserLogOnEntity Get(string key)
        {
            return service.FindEntity(user => user.C_Account == key);
        }

        public UserEntity CheckLogin(string username, string password)
        {
            UserEntity userEntity = service.FindEntity(user => user.C_Account == username);
            if (null != userEntity)
            {
                if (userEntity.C_EnabledMark == true)
                {
                    UserLogOnEntity userLogOnEntity = userLogOnApp
                }
            }
        }
    }
}
