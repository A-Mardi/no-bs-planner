using Microsoft.EntityFrameworkCore;
using NoBSPlanner.Models;

namespace NoBSPlanner.Models
{
    public class PlannerContext : DbContext
    {
        public PlannerContext(DbContextOptions<PlannerContext> options)
            : base(options)
        {
        }

        public DbSet<PlannerItem> PlannerItems { get; set; }
    }
}

