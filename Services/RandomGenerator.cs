using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_investigation_game.Services
{
    internal static class RandomGenerator
    {
        static Random rnd = new Random();
        public static int GetRandomNumber( int max)
        {
            return rnd.Next(0, max);
        }
    }
}
