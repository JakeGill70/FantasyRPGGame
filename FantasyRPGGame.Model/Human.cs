using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyRPGGame.Model
{
    public class Human : Creature
    {
        public override string Race { get { return "Human"; } }

        public Human(IRandom random) : base(random)
        {

        }

        public override int CalculateDamage()
        {
            int damage = base.CalculateDamage();
            if (_random.Next(100) < 10) {
                damage = damage << 1; // Fast multiplication of 2
            }
            return damage;
        }
    }
}
