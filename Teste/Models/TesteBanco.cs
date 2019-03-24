using Teste.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Teste.Models
{
    public partial class TesteBanco : DbContext
    {

        public TesteBanco()
            : base("name=TesteBanco")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Pessoa> Pessoa { get; set; }

    }
}
   