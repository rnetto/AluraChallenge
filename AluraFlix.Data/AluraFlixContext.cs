using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AluraFlix.Domain;

namespace AluraFlix.Data
{
    public class AluraFlixContext : DbContext
    {
        public AluraFlixContext (DbContextOptions<AluraFlixContext> options)
            : base(options)
        {
        }

        public DbSet<AluraFlix.Domain.Video> Video { get; set; }
    }
}
