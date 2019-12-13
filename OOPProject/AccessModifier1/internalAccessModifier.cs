using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject.AccessModifier1
{
    // Declare class internalAccessModifier as internal 
    internal class InternalAccessModifier
    {
       
            int real;
            int img;

            public void setData(int r, int i)
            {
                real = r;
                img = i;
            }

            public void displayData()
            {
                Console.WriteLine("Real = {0}", real);
                Console.WriteLine("Imaginary = {0}", img);
            }
        }

    }


