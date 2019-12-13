using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject
{
    // C# program to show the  
    // working of abstract class 
    public abstract class AbstractionDemo
    {
        // abstract method 'kgouteTest()' 
        public abstract void kgouteTest();

    }

    // class 'AbstractionDemo' inherit 
    // in child class 'AbstractionDemo1' 
    public class AbstractionDemo1 : AbstractionDemo
    {

        // abstract method 'kgouteTest()'  
        // declare here with  
        // 'override' keyword 
        public override void kgouteTest()
        {
            Console.WriteLine("class AbstractionDemo1");
        }
    }

    // class 'GeeksForGeeks' inherit in  
    // another child class 'Geek2' 
    public class AbstractionDemo2 : AbstractionDemo
    {

        // same as the previous class 
        public override void kgouteTest()
        {
            Console.WriteLine("class AbstractionDemo2");
        }
    }



    abstract class AreaClass
    {
        // declare method  
        // 'Area' as abstract 
        abstract public int Area();
    }

    // class 'AreaClass' inherit 
    // in child class 'Square' 
    class Square : AreaClass
    {
        int side = 0;

        // constructor 
        public Square(int n)
        {
            side = n;
        }

        // the abstract method  
        // 'Area' is overridden here 
        public override int Area()
        {
            return side * side;
        }
    }

    class gfg
    {

        // Main Method 
        public static void Main()
        {
            Square s = new Square(6);
            Console.WriteLine("Area  = " + s.Area());
        }
    }

    //Following are some important observations about abstract classes in C#

    //1) An Abstract class does not mean that it only contain abstract methods.An Abstract class can also contain non-abstract methods also.



    abstract class kgouteTestAbstract2
    {
        public void TestDemo1()
        {
            Console.WriteLine("'TestDemo1()' is non-abstract method");
        }
    }

    // C# program to show the working of  
    // the non-abstract method in the  
    // abstract class 


    abstract class AbstractClass
    {

        // Non abstract method 
        public int AddTwoNumbers(int Num1, int Num2)
        {
            return Num1 + Num2;
        }

        // An abstract method which  
        // overridden in the derived class 
        public abstract int MultiplyTwoNumbers(int Num1, int Num2);

    }

    // Child Class of AbstractClass 
    class Derived : AbstractClass
    {

        // implementing the abstract  
        // method 'MultiplyTwoNumbers' 
        // using override keyword, 
        public override int MultiplyTwoNumbers(int Num1, int Num2)
        {
            return Num1 * Num2;
        }
    }

}