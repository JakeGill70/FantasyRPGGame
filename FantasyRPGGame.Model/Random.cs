namespace FantasyRPGGame.Model
{
    public class Random : IRandom
    {
        private System.Random _random;

        public Random()
        {
            _random = new System.Random();
        }

        public int Next(int maxValue)
        {
            return _random.Next(maxValue);
        }
    }
}
