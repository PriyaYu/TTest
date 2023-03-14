using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Nexify_Engineer_Test_BackEnd.Models
{
    public class AppDbContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<MemberEntity> MemberDataSet { get; set; }
    }

    public class MemberEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? DateOfBirth { get; set; }
        public int Salary { get; set; }
        public string? Address { get; set; }
    }
}
