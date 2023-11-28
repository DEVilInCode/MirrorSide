using System;

namespace Server.Game
{
    public class Mana
    {
        public const int MaxSlots = 10;

        public int Spent;
        public int Permanent;
        public int Temporary;

        public int Unlocked
        {
            get
            {
                return Math.Min(Permanent + Temporary, MaxSlots);
            }
        }

        public int Available
        {
            get
            {
                return Math.Min(Permanent + Temporary - Spent, MaxSlots);
            }
        }
    }
}
