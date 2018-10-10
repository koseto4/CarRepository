using System;

namespace CarSystem.Common
{
    public static class RandomGenerator
    {
        public static int RandomNumber(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max + 1);
        }
    }
}
