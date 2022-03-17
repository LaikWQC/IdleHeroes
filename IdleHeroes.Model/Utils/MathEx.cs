using System;

namespace IdleHeroes.Model
{
    public static class MathEx
    {
        public static double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }    
}
