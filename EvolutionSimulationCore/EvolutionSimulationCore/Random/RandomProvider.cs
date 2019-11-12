using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSimulationCore.Random
{
    public static class RandomProvider
    {
        private static readonly string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static Int32 GetRandomNumber(Int32 minValue, Int32 maxValue)
        {
            if (minValue > maxValue)
                throw new ArgumentOutOfRangeException("minValue");
            if (minValue == maxValue) return minValue;
            Int64 diff = maxValue - minValue;

            RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
            byte[] randomNumber = new byte[4];

            while (true)
            {
                rngCsp.GetBytes(randomNumber);
                UInt32 rand = BitConverter.ToUInt32(randomNumber, 0);

                Int64 max = (1 + (Int64)UInt32.MaxValue);
                Int64 remainder = max % diff;
                if (rand < max - remainder)
                {
                    return (Int32)(minValue + (rand % diff));
                }
            }
        }

        public static char GetRandomCharacter()
        {
            int index = GetRandomNumber(0, chars.Length);
            return chars[index];
        }
    }
}
