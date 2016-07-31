using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Players
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new TeamContext())
            {

                Console.Write("Enter a name of a player: ");
                var name = Console.ReadLine();
                Console.Write("Enter a age of a player: ");
                int year = Console.Read();
                Console.Write("Enter a age of a player: ");
                var position = Console.ReadLine();

                var player = new Player { Name = name, Age = year, Position = position };
                db.Players.Add(player);
                db.SaveChanges();


                var query = from b in db.Players
                            orderby b.Name
                            select b;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }

        class Player
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Position { get; set; }
            public int Age { get; set; }

            public ICollection<Team> Teams { get; set; }
            public Player()
            {
                Teams = new List<Team>();
            }
        }

        class Team
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public ICollection<Player> Players { get; set; }
            public Team()
            {
                Players = new List<Player>();
            }
        }

        class TeamContext : DbContext
        {
            public DbSet<Player> Players { get; set; }
            public DbSet<Team> Teams { get; set; }
        }
    }
}
