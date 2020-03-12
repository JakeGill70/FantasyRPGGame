using System;

namespace FantasyRPGGame.Model
{
    public class Creature
    {
        /// <summary>
        /// 0 = Human, 1 = Cyberdemon, 2 = Balrog, 3 = Elf
        /// </summary>
        public int Type { get; set; }
        public int Strength { get; set; }
        public int HitPoints { get; set; }
        public string Race
        {
            get
            {
                switch (Type)
                {
                    case 0: return "Human";
                    case 1: return "Cyberdemon";
                    case 2: return "Balrog";
                    case 3: return "Elf";
                }
                return "Unknown";
            }
        }

        private Random _random;

        public Creature()
        {
            _random = new Random();
            Type = 0; // Human
            Strength = 50;
            HitPoints = 100;
        }

        public int TakeDamage(int damage)
        {
            // All creatures have a 1% chance of dodging the damage
            if (_random.Next(100) < 1)
            {
                damage = 0;
            }
            HitPoints -= damage;
            return damage;
        }

        public int CalculateDamage()
        {
            int damage = 0;

            // All creatures inflict damage that is a random number up to their strength
            // with a minimum damage of 1
            damage = _random.Next(Strength) + 1;
            // Humans are observant, they have a 10% chance of spotting a 
            // weakness and can inflict double damage
            if (Type == 0)
            {
                if (_random.Next(100) < 10)
                {
                    damage *= 2;
                }
            }
            // Demons have a 25% chance of inflicting extra 10 damage
            else if ((Type == 2) || (Type == 1))
            {
                if (_random.Next(100) < 25)
                {
                    damage += 10;
                }
            }
            // Elves have a 10% chance of inflicting additional magical damage
            // which is at half strength
            else if (Type == 3)
            {
                if (_random.Next(100) < 10)
                {
                    damage += _random.Next(Strength / 2) + 1;
                }
            }
            // Balrogs are deadly and can inflict base damage twice
            if (Type == 2)
            {
                damage += _random.Next(Strength) + 1;
            }
            return damage;
        }

        public int Attack(Creature creature)
        {
            return creature.TakeDamage(CalculateDamage());
        }
    }

}
