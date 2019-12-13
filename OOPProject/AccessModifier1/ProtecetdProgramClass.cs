using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject.AccessModifier1
{
    class ProtecetdProgramClass
    {
        // Member x declared as protected 
        protected int x;

        public ProtecetdProgramClass()
        {
            x = 10;

        }

    }

    class ProtecetdProgramClass1 : ProtecetdProgramClass
    {
        public int getX()
        {
            return x;

        }
    }
}
