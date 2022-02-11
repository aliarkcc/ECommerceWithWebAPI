using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Context
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options):base(options)
        {

        }
        public Context()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source =MEHMETPC\\SQLEXPRESS;Initial Catalog=ECommerceWithWebAPIdb;Integrated Security=True");
        }
    }
}
