using Microsoft.EntityFrameworkCore;
using System;

namespace KCBVooma.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<AccountModel> Accounts { get; set; }
        public DbSet<CreditCardModel> CreditCards { get; set; }


    }
}
