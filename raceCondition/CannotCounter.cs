using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace raceCondition
{
    public class CannotCounter : ICounter
    {
        public int Counter { get; private set; } = 0;

        public void AddMany(int howmany)
        {
            for (int i = 0; i < howmany; i++)
            {
                Counter++;
            }
        }

        public void SubtractMany(int howmany)
        {
            for (int i = 0; i < howmany; i++)
            {
                Counter--;
            }
        }
    }
}
