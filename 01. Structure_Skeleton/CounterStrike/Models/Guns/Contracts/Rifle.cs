using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns.Contracts
{
    public class Rifle : Gun
    {
        public Rifle(string name, int bulletsCount) : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            if (BulletsCount <= 0)
            {
                return 0;
            }

            this.BulletsCount -= 10;
            return 10;
        }
    }
}
