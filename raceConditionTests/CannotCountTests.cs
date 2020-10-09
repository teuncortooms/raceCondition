using Microsoft.VisualStudio.TestTools.UnitTesting;
using raceCondition;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace raceCondition.Tests
{
    [TestClass()]
    public class CannotCountTests
    {
        [TestMethod()]
        public void AddOneManyTimes()
        {
            long many = 15;
            CannotCount cannotCount = new CannotCount();
            for (long i = 0; i < many; i++)
            {
                Thread thread = new Thread(cannotCount.AddOne);
                thread.Start();
            }
            Thread.Sleep(500);
            Assert.AreEqual(many, cannotCount.Counter);
        }
    }
}