using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuPing.Entity
{
    public class UserLogOnEntity
    {
        public long C_Id { get; set; }
        public long C_UserId { get; set; }
        public string C_UserPassword { get; set; }
        public string C_UserSecretkey { get; set; }
        public DateTime? C_AllowStartTime { get; set; }
        public DateTime? C_AllowEndTime { get; set; }
        public DateTime? C_LockStartDate { get; set; }
        public DateTime? C_LockEndDate { get; set; }
        public DateTime? C_FirstVisitTime { get; set; }
        public DateTime? C_PreviousVisitTime { get; set; }
        public DateTime? C_LastVisitTime { get; set; }
        public DateTime? C_ChangePasswordDate { get; set; }
        public bool? C_MultiUserLogin { get; set; }
        public int? C_LogOnCount { get; set; }
        public bool? C_UserOnLine { get; set; }
        public string C_Question { get; set; }
        public string C_AnswerQuestion { get; set; }
        public bool? C_CheckIPAddress { get; set; }
        public string C_Language { get; set; }
        public string C_Theme { get; set; }
    }
}
