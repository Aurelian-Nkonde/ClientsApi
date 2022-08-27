using System;
using Microsoft.EntityFrameworkCore;
using clients.Models;

namespace clients.Data 
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt): base(opt)
        {
            
        }

        public DbSet<Client> clients {get;set;}
    }
}