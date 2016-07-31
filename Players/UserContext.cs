using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Players
{
    class TeamContext : DbContext
    {
        public TeamContext(): base("DbConnection")
        { }
        public DbSet<Team>  Teams { get; set; }
        public DbSet<Player> Users { get; set; }
    }
}
