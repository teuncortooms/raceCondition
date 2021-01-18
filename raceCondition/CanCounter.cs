using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace raceCondition
{
    public class CanCounter : ICounter
    {
        private readonly object CountLock = new object();

        public int Counter { get; private set; } = 0;

        public void AddMany(int howmany)
        {
            lock (CountLock)
            {
                for (int i = 0; i < howmany; i++)
                {
                    Counter++;
                }
            }
        }

        public void SubtractMany(int howmany)
        {
            lock (CountLock)
            {
                for (int i = 0; i < howmany; i++)
                {
                    Counter--;
                }
            }
        }
    }
}
