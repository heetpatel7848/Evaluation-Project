
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTask.Models
{
    public class PracticalTaskContext : DbContext
    {
        
            public PracticalTaskContext(DbContextOptions<PracticalTaskContext> options) : base(options)
            {
            }

            public DbSet<Item> Items { get; set; }
            public DbSet<PriceChange> PriceChanges { get; set; }

    }
}
