using ShuPing.Entity;
using ShuPing.Interface.IRepository;
using ShuPing.Repository;
using ShuPing.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShuPing.Application;

namespace ShuPing.Repository
{
    public class UserRepository : RepositoryBase<UserEntity>, IUserRepository
    {
        IUserRepository service = new UserRepository();
        UserLogOnApp userLogOnApp = new UserLogOnApp();

        public void DeleteForm(long keyValue)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                db.Delete<UserEntity>(user => user.C_Id == keyValue);
                db.Delete<UserLogOnEntity>(userLogOn => userLogOn.C_UserId == keyValue);
                db.Commit();
            }
        }

        public void SubmitForm(UserEntity userEntity, UserLogOnEntity userLogOnEntity, long keyValue)
        {
            
        }
    }
}
