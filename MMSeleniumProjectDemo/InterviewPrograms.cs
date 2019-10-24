using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MMSeleniumProjectDemo
{
    [TestClass]
    public class InterviewPrograms
    {
        [TestMethod]
        //Swap two number without thrid variable
        public void SwapTwoNumberWithouThridTariable()
        {
            int first = 10, second = 20;

            first = first + second;
            second = first - second;
            first = first - second;

            Console.WriteLine(string.Format("{0}{1}", first, second));
        }
    }
}
