using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ShuPing.Data
{
    public class SPDbContext:DbContext
    {
        public SPDbContext()
            :base("SPConnection")
        {
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;
            //数据库结构变化时设定初始值
            Database.SetInitializer<SPDbContext>(new SPApplicationDbInitializer());
        }

        /// <summary>
        /// 通过反射映射实体与数据表
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            string assembleFileName = Assembly.GetExecutingAssembly().CodeBase.Replace("ShuPing.Data.dll", "ShuPing.Mapping.dll").Replace("file:///","");
            Assembly ass = Assembly.LoadFile(assembleFileName);
            
            var typesToRegister = ass.GetTypes()
                .Where(p => !string.IsNullOrEmpty(p.Namespace))
                .Where(q => q.BaseType != null && q.BaseType.IsGenericType && q.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
