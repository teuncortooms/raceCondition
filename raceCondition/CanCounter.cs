using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace raceCondition
{
    public class CanCounter : ICounter
    {
        public int Counter { get; private set; } = 0;
        private readonly object CountLock = new object();

        public void AddOneSlow()
        {
            lock (CountLock)
            {
                Counter++;
            }
            Thread.Sleep(100);
        }

        public void AddOneFast()
        {
            lock (CountLock)
            {
                Counter++;
            }
        }
    }
}
