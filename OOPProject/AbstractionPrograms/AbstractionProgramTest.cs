using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OOPProject.AbstractionPrograms
{
    [TestClass]
    public class AbstractionProgramTest
    {
        [TestMethod]
        public void Abstraction_Test()
        {
            AbstractionDemo demo;

            demo = new AbstractionDemo1();

            demo.kgouteTest();

            
        }

        [TestMethod]
        public void Abstraction_Test1()
        {
            AbstractionDemo demo;

            demo = new AbstractionDemo1();

            demo.kgouteTest();
        }
    }
}
