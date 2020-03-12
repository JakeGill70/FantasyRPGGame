using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyRPGGame.Model
{
    public interface IRandom
    {
        public int Next(int maxValue);
    }
}
