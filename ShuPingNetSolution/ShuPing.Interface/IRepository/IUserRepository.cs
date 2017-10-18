using ShuPing.Entity;
using ShuPing.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuPing.Interface.IRepository
{
    public interface IUserRepository : IRepositoryBase<UserEntity>
    {
        void DeleteForm(long keyValue);
        void SubmitForm(UserEntity userEntity, UserLogOnEntity userLogOnEntity, long keyValue);
    }
}
