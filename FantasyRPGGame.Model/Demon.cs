using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyRPGGame.Model
{
    public abstract class Demon : Creature
    {
        public override string Race { get { return "Demon"; } }

        public Demon(IRandom random) : base(random)
        {
        }

        public override int CalculateDamage()
        {
            int dmg = base.CalculateDamage();
            if (_random.Next(100) < 25) {
                dmg += 10;
            }
            return dmg;
        }
    }
}
