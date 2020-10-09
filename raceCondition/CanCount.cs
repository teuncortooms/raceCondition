using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace raceCondition
{
    public class CanCount
    {
        public int Counter { get; set; } = 0;
        object CountLock = new object(); 

        public void AddOne()
        {
            lock (CountLock)
            {
                Counter++;
            }
        }

    }
}
