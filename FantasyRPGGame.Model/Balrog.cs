using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyRPGGame.Model
{
    public class Balrog : Demon
    {
        public override string Race { get { return "Balrog"; } }

        public Balrog(IRandom random) : base(random)
        {
        }

        public override int CalculateDamage()
        {
            int dmg = 0;

            // Belogs are deadly and inflict base damage twice
            // Formula taken from the Creature Class
            dmg += _random.Next(Strength) + 1; // Base Damage Once
            dmg += _random.Next(Strength) + 1; // Base Damage Twice

            // 25% for extra 10 damage
            // Spec taken from demon
            if (_random.Next(100) < 25)
            {
                dmg += 10;
            }

            return dmg;
        }
    }
}
