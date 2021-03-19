using System;

namespace Services.Commons.Extensions
{
    public static class DoubleExtensions
    {
        public static double ToRadians(this double value)
        {
            return (Math.PI / 180) * value;
        }
    }
}