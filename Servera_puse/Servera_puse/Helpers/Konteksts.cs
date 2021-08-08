using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using Servera_puse.Entities;
using System.Security.Cryptography;
using System.Text;

namespace Servera_puse.Helpers
{
    public class Konteksts : DbContext
    {
        protected readonly IConfiguration Configuration;

        public Konteksts(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public DbSet<File> Datnes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Parametr> Parametrs { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Uzdevuma_DB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var algoritms = SHA256.Create();
            modelBuilder.Entity<User>().HasData(
                new User[]
                {
                    new User { Id = 1, Username = "Admin", Password = Convert.ToBase64String(algoritms.ComputeHash(Encoding.UTF8.GetBytes("Admin"))), Role = Role.Admin },
                    new User { Id = 2, Username = "User", Password = Convert.ToBase64String(algoritms.ComputeHash(Encoding.UTF8.GetBytes("User"))), Role = Role.User }
                }
                );
            modelBuilder.Entity<Parametr>().HasData(
                new Parametr[]
                {
                    new Parametr{Name=Parametr_list.Size, Value=5},
                    new Parametr{Name=Parametr_list.a_max, Value=300},
                    new Parametr{Name=Parametr_list.b_max, Value=300},
                    new Parametr{Name=Parametr_list.a_min, Value=100},
                    new Parametr{Name=Parametr_list.b_min, Value=100}
                }
                );
        }
    }
}
