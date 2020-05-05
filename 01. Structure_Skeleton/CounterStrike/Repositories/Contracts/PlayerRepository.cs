using CounterStrike.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Repositories.Contracts
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private List<IPlayer> players;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }
        public IReadOnlyCollection<IPlayer> Models => this.players.AsReadOnly();

        public void Add(IPlayer model)
        {
            if (model == null)
            {
                throw new ArgumentException("Cannot add null in Player Repository");
            }

            this.players.Add(model);
        }

        public IPlayer FindByName(string name)
        {
            return this.players.FirstOrDefault(p => p.Username == name);
        }

        public bool Remove(IPlayer model)
        {
            if (this.players.Contains(model))
            {
                this.players.Remove(model);
                return true;
            }

            return false;
        }
    }
}
