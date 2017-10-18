using ShuPing.Entity;
using System.Data.Entity.ModelConfiguration;

namespace ShuPing.Mapping
{
    public class UserMap: EntityTypeConfiguration<UserEntity>
    {
        public UserMap()
        {
            this.ToTable("T_Users", "dbo"); ///映射数据表/架构
            this.HasKey(p => p.C_Id).Property(p=>p.C_Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);         //设置主键
            //this.Property(p => p.C_Birthday).IsRequired();//设置不可空
            //this.Property(p => p.C_CreatorTime).HasPrecision(2);//设置精度
            //this.Property(p => p.C_DeleteUserId).HasMaxLength(50);
            //this.Ignore(p => p.C_DeleteMark);
        }
    }
}
