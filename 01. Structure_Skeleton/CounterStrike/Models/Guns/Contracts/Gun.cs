using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns.Contracts
{
    public abstract class Gun : IGun
    {
        private string name;
        private int bulletsCount;
        
        public Gun(string name, int bulletsCount)
        {
            this.Name = name;
            this.BulletsCount = bulletsCount;
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGun);
                }
                this.name = value;
            }
        }

        public int BulletsCount
        {
            get { return this.bulletsCount; }
            protected internal set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunBulletsCount);
                }
                this.bulletsCount = value;
            }
        }

        public abstract int Fire();
       
        
    }
}
