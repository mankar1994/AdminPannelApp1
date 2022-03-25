using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPannelApp.Models
{
    public class AppDbContext:DbContext
    {
        //public AppDbContext() : base() { }
        public DbSet<Users> Users { get; set; }
        public DbSet<VerifyAccount> VerifyAccounts { get; set; }
        public DbSet<Book> Books { get; set;}
        public DbSet<Author> Authors { get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbConnection.ConnectionStr);
        }

    }
}
