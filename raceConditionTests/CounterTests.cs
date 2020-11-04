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
        private void Add_one_slow_then_one_fast_returns_two(ICounter counter)
        {
            int expected = 2;

            Thread thread1 = new Thread(counter.AddOneSlow);
            thread1.Start();
            counter.AddOneFast();

            Thread.Sleep(200); // wait for all threads to finish
            int actual = counter.Counter;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CannotCounter_Add_one_slow_then_one_fast_returns_two()
        {
            Add_one_slow_then_one_fast_returns_two(new CannotCounter());
        }

        [TestMethod()]
        public void CanCounter_Add_one_slow_then_one_fast_returns_two()
        {
            Add_one_slow_then_one_fast_returns_two(new CanCounter());
        }
    }
}