using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SampleAPI.DataAccessLayer.Models;

namespace SampleAPI.DataAccessLayer.Context
{
    public class DataContext:DbContext
    {
        public DataContext()
        {
            
        }       

        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseSqlite("Data Source=.\\Database\\User.db");
        

        public virtual DbSet<Employee> M_Employee { get; set; }
    }
}
