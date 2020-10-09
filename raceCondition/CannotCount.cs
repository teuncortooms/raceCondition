using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace raceCondition
{
    public class CannotCount
    {
        public int Counter { get; set; } = 0;

        public void AddOne()
        {
            Counter++;
        }

    }
}
