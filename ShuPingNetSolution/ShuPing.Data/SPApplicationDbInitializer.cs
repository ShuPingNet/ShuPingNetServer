using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuPing.Data
{
    class SPApplicationDbInitializer : DropCreateDatabaseIfModelChanges<SPDbContext>
    {
        protected override void Seed(SPDbContext context)
        {
            InitializeIdentityForEf(context);
            base.Seed(context);
        }

        /// <summary>
        /// 重置种子
        /// </summary>
        /// <param name="context"></param>
        private void InitializeIdentityForEf(SPDbContext context)
        {
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('T_Users', RESEED, 100001)");
        }
    }
}
