using System;
using System.Data.Entity;

namespace Hangfire.Mailer.Models
{
    public class MailerDbContext : DbContext
    {
        public MailerDbContext()
            : base("MailerDb")
        {
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Medical> Medical { get; set; }
        public DbSet<User> User { get; set; }

    }
}