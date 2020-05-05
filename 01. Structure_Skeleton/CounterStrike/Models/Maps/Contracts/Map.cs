using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;

namespace CounterStrike.Models.Maps.Contracts
{
    public class Map : IMap
    {
        public string Start(ICollection<IPlayer> players)
        {
            var terrorists = new List<IPlayer>();
            var counterT = new List<IPlayer>();

            foreach (var player in players)
            {
                if (player.GetType().Name == "Terrorist")
                {
                    terrorists.Add(player);
                }
                else if (player.GetType().Name == "CounterTerrorist")
                {
                    counterT.Add(player);
                }
            }

            while (true)
            {
                if (terrorists.Sum(t => t.Health) <= 0)
                {
                    return "Counter Terrorist wins!";

                }
                if (counterT.Sum(c => c.Health) <= 0)
                {
                    return "Terrorist wins!";
                }

                foreach (var terrorist in terrorists)
                {
                    if (terrorist.IsAlive)
                    {
                        foreach (var counter in counterT)
                        {
                            if (counter.Health > 0)
                            {
                            counter.TakeDamage(terrorist.Gun.Fire());

                            }
                        }
                    }
                }

               

                foreach (var counter in counterT)
                {
                    if (counter.IsAlive)
                    {
                        foreach (var terrorist in terrorists)
                        {
                            if (terrorist.Health > 0)
                            {
                            terrorist.TakeDamage(counter.Gun.Fire());
                            }
                        }
                    }
                }

               
            }
        }
    }
}
