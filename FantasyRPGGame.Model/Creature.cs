namespace FantasyRPGGame.Model
{
    public abstract class Creature
    {
        protected FantasyRPGGame.Model.IRandom _random;

        /// <summary>
        /// 0 = Human, 1 = Cyberdemon, 2 = Balrog, 3 = Elf
        /// </summary>
        public virtual int Strength { get; set; }
        public virtual int HitPoints { get; set; }
        public virtual string Race { get; }

        public Creature(IRandom random)
        {
            _random = random;
            Strength = 50;
            HitPoints = 100;
        }

        public virtual int TakeDamage(int damage)
        {
            // All creatures have a 1% chance of dodging the damage
            if (_random.Next(100) < 1)
            {
                damage = 0;
            }
            HitPoints -= damage;
            return damage;
        }

        public virtual int CalculateDamage()
        {
            int damage = _random.Next(Strength) + 1;
            return damage;
        }

        public virtual int Attack(Creature creature)
        {
            return creature.TakeDamage(CalculateDamage());
        }
    }

}
