using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheaterRepertory.Models;

namespace TheaterRepertory.Data
{
    public class TheaterRepertoryContext : DbContext
    {
        public TheaterRepertoryContext (DbContextOptions<TheaterRepertoryContext> options)
            : base(options)
        {
        }

        public DbSet<TheaterRepertory.Models.Play> Play { get; set; }
    }
}
