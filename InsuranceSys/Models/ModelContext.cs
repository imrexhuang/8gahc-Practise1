using System.Data.Entity;

namespace InsuranceSys.Models
{
    public class ModelContext : DbContext
    {
        public ModelContext() : base("name=DBEntities")
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerDetail> CustomerDetail { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<SysCode> SysCode { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}