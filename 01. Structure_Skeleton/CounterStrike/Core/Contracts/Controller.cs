using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Core.Contracts
{
    public class Controller : IController
    {
        private GunRepository guns;
        private PlayerRepository players;
        private IMap map;
        public Controller()
        {
            this.guns = new GunRepository();
            this.players = new PlayerRepository();
            this.map = new Map();
        }
        public string AddGun(string type, string name, int bulletsCount)
        {
            
            if (type == "Pistol")
            {
                this.guns.Add(new Pistol(name, bulletsCount));
            }
            else if (type == "Rifle")
            {
                this.guns.Add(new Rifle(name, bulletsCount));
            }
            else
            {
                throw new ArgumentException("Invalid gun type.");
            }

            return $"Successfully added gun {name}.";
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            var gun = this.guns.FindByName(gunName);

            if (gun == null)
            {
                throw new ArgumentException("Gun cannot be found!");
            }

            if (type == "Terrorist")
            {
                this.players.Add(new Terrorist(username, health, armor, gun));
            }
            else if (type == "CounterTerrorist")
            {
                this.players.Add(new CounterTerrorist(username, health, armor, gun));
            }
            else
            {
                throw new ArgumentException("Invalid player type!");
            }

            return $"Successfully added player {username}.";
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var player in this.players.Models.OrderBy(p=> p.GetType().Name).ThenByDescending(p=>p.Health).ThenBy(p=>p.Username).ToList())
            {
                sb.AppendLine($"{player.GetType().Name}: {player.Username}");
                sb.AppendLine($"--Health: {player.Health}");
                sb.AppendLine($"--Armor: {player.Armor}");
                sb.AppendLine($"--Gun: {player.Gun.Name}");
            }
            return sb.ToString().TrimEnd();
        }

        public string StartGame()
        {
            var result = map.Start(this.players.Models.Where(p => p.IsAlive).ToList());

            return result;
        }
    }
}
