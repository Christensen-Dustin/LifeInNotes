using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Life_In_Notes.Models
{
    public class AppDBContext : IdentityDbContext<Account>
    {
        // Set for the DbContext class - constructor
        public AppDBContext(DbContextOptions<AppDBContext> options) 
            : base(options)
        {

        }

        // setup for Entry Class
        public DbSet<Entry> Entries { get; set; }

        // setup for Note Class
        public DbSet<Note> Notes { get; set; }
    }
}
