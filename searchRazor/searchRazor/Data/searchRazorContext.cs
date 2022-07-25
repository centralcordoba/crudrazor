using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using searchRazor.Models;

namespace searchRazor.Data
{
    public class searchRazorContext : DbContext
    {
        public searchRazorContext (DbContextOptions<searchRazorContext> options)
            : base(options)
        {
        }

        public DbSet<searchRazor.Models.Car> Cars { get; set; }
    }
}
