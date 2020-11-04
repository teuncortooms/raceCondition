using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace raceCondition
{
    public class CannotCounter : ICounter
    {
        public int Counter { get; private set; } = 0;

        public void AddOneSlow()
        {
            Counter++;
            Thread.Sleep(100);
        }

        public void AddOneFast()
        {
            Counter++;
        }
    }
}
