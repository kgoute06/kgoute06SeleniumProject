using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject.AccessModifier1
{
    class PrivateAccessmodifier
    {
        private int value;
        // value is Accessible  
        // only inside the class 
        public void setValue(int v)
        {
            value = v;
        }

        public int getValue()
        {
            return value;
        }

    }

    class PrivateAccessmodifier1 : PrivateAccessmodifier
    {

        public void showValue()
        {
            // Trying to access value 
            // Inside a derived class 
            // Console.WriteLine( "Value = " + value ); 
            // Gives an error 
        }
    }

}
