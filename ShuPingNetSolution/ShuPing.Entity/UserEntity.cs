using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuPing.Entity
{
    public class UserEntity //: IEntity<UserEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public long C_Id { get; set; }
        public string C_Account { get; set; }
        public string C_RealName { get; set; }
        public string C_NickName { get; set; }
        public string C_HeadIcon { get; set; }
        public bool? C_Gender { get; set; }
        public DateTime? C_Birthday { get; set; }
        public string C_MobilePhone { get; set; }
        public string C_Email { get; set; }
        public string C_WeChat { get; set; }
        public string C_ManagerId { get; set; }
        public int? C_SecurityLevel { get; set; }
        public string C_Signature { get; set; }
        public string C_OrganizeId { get; set; }
        public string C_DepartmentId { get; set; }
        public string C_RoleId { get; set; }
        public string C_DutyId { get; set; }
        public bool? C_IsAdministrator { get; set; }
        public int? C_SortCode { get; set; }
        public bool? C_DeleteMark { get; set; }
        public bool? C_EnabledMark { get; set; }
        public string C_Description { get; set; }
        public DateTime? C_CreatorTime { get; set; }
        public string C_CreatorUserId { get; set; }
        public DateTime? C_LastModifyTime { get; set; }
        public string C_LastModifyUserId { get; set; }
        public DateTime? C_DeleteTime { get; set; }
        public string C_DeleteUserId { get; set; }
    }
}
