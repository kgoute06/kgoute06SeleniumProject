using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        [TestMethod]

        public void URITest()
        {
            // Construct three Uri objects.
            Uri uri1 = new Uri("http://dotnetperls.com/");
            Uri uri2 = new Uri(uri1, "/datagridview-tips");
            Uri uri3 = new Uri("http://dotnetperls.com/Test/Exists.html?good=true");

            // Write properties.
            Print(uri1);
            Print(uri2);
            Print(uri3);
        }

        static void Print(Uri uri)
        {
            // Print properties of Uri instance.
            Console.WriteLine("AbsolutePath = {0}", uri.AbsolutePath);
            Console.WriteLine("AbsoluteUri = {0}", uri.AbsoluteUri);
            Console.WriteLine("Authority = {0}", uri.Authority);
            Console.WriteLine("DnsSafeHost = {0}", uri.DnsSafeHost);
            Console.WriteLine("Fragment = {0}", uri.Fragment);
            Console.WriteLine("Host = {0}", uri.Host);
            Console.WriteLine("HostNameType = {0}", uri.HostNameType);
            Console.WriteLine("IsAbsoluteUri = {0}", uri.IsAbsoluteUri);
            Console.WriteLine("IsDefaultPort = {0}", uri.IsDefaultPort);
            Console.WriteLine("IsFile = {0}", uri.IsFile);
            Console.WriteLine("IsLoopback = {0}", uri.IsLoopback);
            Console.WriteLine("IsUnc = {0}", uri.IsUnc);
            Console.WriteLine("LocalPath = {0}", uri.LocalPath);
            Console.WriteLine("OriginalString = {0}", uri.OriginalString);
            Console.WriteLine("PathAndQuery = {0}", uri.PathAndQuery);
            Console.WriteLine("Port = {0}", uri.Port);
            Console.WriteLine("Query = {0}", uri.Query);
            Console.WriteLine("Scheme = {0}", uri.Scheme);
            Console.WriteLine("Segments = {0}", string.Join(",", uri.Segments));
            Console.WriteLine("UserEscaped = {0}", uri.UserEscaped);
            Console.WriteLine("UserInfo = {0}", uri.UserInfo);
            Console.WriteLine(new string('-', 40));
        }


        [TestMethod]
        public void REFKeyworkdProgramTest()
        {
            int outSideValue = 20;

            RefFunction(ref outSideValue);

            Console.WriteLine(outSideValue);

        }

        [TestMethod]
        public void OUTKeyworkdProgramTest()
        {
            int outSideValue = 20;

            OutFunction(out outSideValue);

            Console.WriteLine(outSideValue);
            int sum = 0;
            Addition(100, 200, out sum);

        }

        public  void RefFunction(ref int insdievalue)
        {
            insdievalue = insdievalue + 50;
        }

        public void OutFunction(out int insdievalue)
        {
            insdievalue = 0;
            insdievalue = insdievalue + 50;
        }

        public static void Addition(int num1,int num2 , out int sum)
        {
            sum = 0;
            sum = num1 + num2;
        }

        public int SwapTwoNumbers(ref int x, ref int y)
        {
            int temp;

            temp = x; /* save the value of x */
            x = y;    /* put y into x */
            y = temp; /* put temp into y */

            return temp;
        }

        [TestMethod]

        public void SwapTwoNumbers()
        {
            /* local variable definition */
            int a = 100;
            int b = 200;

            Console.WriteLine("Before swap, value of a : {0}", a);
            Console.WriteLine("Before swap, value of b : {0}", b);

            /* calling a function to swap the values */
            SwapTwoNumbers(ref a, ref b);

            Console.WriteLine("After swap, value of a : {0}", a);
            Console.WriteLine("After swap, value of b : {0}", b);

        }

        [TestMethod]

        public void ReadonlyCollectionProgram()
        {
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(3);
            list.Add(5);

            // Constructor.
            ReadOnlyCollection<int> read = new ReadOnlyCollection<int>(list);

            // Loop over ReadOnlyCollection.
            foreach (int value in read)
            {
                Console.WriteLine("read: {0}", value);
            }

            // Copy ReadOnlyCollection to an array.
            int[] array = new int[3];
            read.CopyTo(array, 0);

            // Display array.
            foreach (int value in array)
            {
                Console.WriteLine("array: {0}", value);
            }

            // Use methods on ReadOnlyCollection.
            int count = read.Count;
            bool contains = read.Contains(-1);
            int index = read.IndexOf(3);
            Console.WriteLine("{0}, {1}, {2}", count, contains, index);
        }
    }
}
