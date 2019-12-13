using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOPProject.AccessModifier1;

namespace OOPProject
{
    [TestClass]
    public class InheritanceProgramTest
    {
        PartTimeEmployee pTimeEmp = new PartTimeEmployee();
        FullTimeEmployee fTimeEmp = new FullTimeEmployee();

        [TestMethod]
        public void InheritanceTestMethod1()
        {
            pTimeEmp.empFName = "Krishna";
            pTimeEmp.empLName = "Goute";
            pTimeEmp.eMail = "saikrishna.goute@gmail.com";
            pTimeEmp.EmpFullName();
            Console.WriteLine(pTimeEmp.eMail);
            pTimeEmp.monthalySalary = 100000;

            pTimeEmp.empFName = "Sathvik";
            pTimeEmp.empLName = "Goute";
            pTimeEmp.eMail = "sathvik.goute@gmail.com";
            pTimeEmp.EmpFullName();
            Console.WriteLine(pTimeEmp.eMail);
            pTimeEmp.monthalySalary = 1000000;
            Console.WriteLine(pTimeEmp.monthalySalary);
        }

        
    }
}
namespace KrishnaNamespace
{
    [TestClass]
    public class InheritanceProgramTest
    {
        [TestMethod]
        public void InternalTest1()
        {
            InternalAccessModifier a = new InternalAccessModifier();
            a.setData(1, 4);
            a.displayData();

        }
    }
}
