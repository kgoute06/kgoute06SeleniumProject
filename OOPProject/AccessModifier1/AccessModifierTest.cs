using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOPProject.AccessModifier1;

namespace OOPProject.AccessModifier1
{
    [TestClass]
    public class AccessModifierTest
    {
        [TestMethod]
        public void Public_AccessModifierTest()
        {
            Public_Student S = new Public_Student(286315, "Krishna Goute");

            // Displaying details directly 
            // using the class members 
            // accessible through another method 
            Console.WriteLine("Roll number: {0}", S.rollNo);
            Console.WriteLine("Name: {0}", S.name);

            Console.WriteLine();

            // Displaying details using  
            // member method also public 
            Console.WriteLine("Roll number: {0}", S.getRollNo());
            Console.WriteLine("Name: {0}", S.getName());
        }

        [TestMethod]
        public void Protected_AccessModifierTest()
        {
            ProtecetdProgramClass obj1 = new ProtecetdProgramClass1();
            ProtecetdProgramClass1 obj2 = new ProtecetdProgramClass1();

            // Displaying the value of x 
            Console.WriteLine("Value of x is : {0}", obj2.getX());
        }

        [TestMethod]
        public void Internal_AccessModifierTest()
        {
            // Instantiate the class Complex 
            // in separate class but within  
            // the same assembly 
            InternalAccessModifier c = new InternalAccessModifier();

            // Accessible in class Program 
            c.setData(2, 1);
            c.displayData();
        }

        [TestMethod]
        public void ProtectedInternal_AccessModifierTest()
        {
            // Instantiate the class Complex 
            // in separate class but within  
            // the same assembly 
            Child c = new Child();

            // Accessible in class Program 
            c.value = 100;

            Console.WriteLine("Value = " +  c.value);
        }


        [TestMethod]
        public void Private_AccessModifierTest()
        {
            PrivateAccessmodifier obj = new PrivateAccessmodifier();

            // obj.value = 5; 
            // Also gives an error 

            // Use public functions to assign 
            // and use value of the member 'value' 
            obj.setValue(4);
            Console.WriteLine("Value = " + obj.getValue());
        }
    }
}


  

    class Child : ProtectedInternalClass
    {

       
    }
