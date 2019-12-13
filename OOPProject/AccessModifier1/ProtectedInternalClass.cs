using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject.AccessModifier1
{
    class ProtectedInternalClass
    {
        // Declaring member as protected internal 
        protected internal int value;
    }

    class ABC
    {

        // Trying to access  
        // value in another class 
        public void testAccess()
        {
            // Member value is Accessible 
            ProtectedInternalClass obj1 = new ProtectedInternalClass();
            obj1.value = 12;
        }
    }
}

