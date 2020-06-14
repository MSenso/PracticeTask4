using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeTask4;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Form1 form = new Form1();
            form.e = 1;
            form.Sum_Calculation();

            form.e = 0.05;
            form.Sum_Calculation();

            form.e = 2;
            form.Sum_Calculation();

            form.e = 0.000000001;
            form.Sum_Calculation();
        }
    }
}
