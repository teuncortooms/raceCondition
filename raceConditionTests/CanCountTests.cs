using Microsoft.VisualStudio.TestTools.UnitTesting;
using raceCondition;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace raceCondition.Tests
{
    [TestClass()]
    public class CanCountTests
    {
        [TestMethod()]
        public void AddOneManyTimes()
        {
            long many = 15;
            CanCount canCount = new CanCount();
            for (long i = 0; i < many; i++)
            {
                Thread thread = new Thread(canCount.AddOne);
                thread.Start();
            }
            Thread.Sleep(500);
            Assert.AreEqual(many, canCount.Counter);
        }
    }
}