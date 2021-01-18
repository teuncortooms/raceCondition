using Microsoft.VisualStudio.TestTools.UnitTesting;
using raceCondition;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace raceCondition.Tests
{
    [TestClass()]
    public class CounterTests
    {
        private void Add_many_then_subtract_many_returns_0(ICounter counter)
        {
            int howmany = 1000000;
            int expected = 0;

            Thread otherThread = new Thread(() => counter.AddMany(howmany));
            otherThread.Start();
            counter.SubtractMany(howmany);

            otherThread.Join(); // wait for thread to finish
            int actual = counter.Counter;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CannotCounter_Add_many_then_subtract_many_returns_0()
        {
            Add_many_then_subtract_many_returns_0(new CannotCounter());
        }

        [TestMethod()]
        public void CanCounter_Add_many_then_subtract_many_returns_0()
        {
            Add_many_then_subtract_many_returns_0(new CanCounter());
        }
    }
}