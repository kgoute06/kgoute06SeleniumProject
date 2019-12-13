using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject.AccessModifier1
{
    class Public_Student
    {
        // Declaring members rollNo  and name as public 
        public int rollNo;
        public string name;

        // Constructor 
        public Public_Student(int r, string n)
        {
            rollNo = r;
            name = n;
        }

        // methods getRollNo and getName 
        // also declared as public 
        public int getRollNo()
        {
            return rollNo;
        }
        public string getName()
        {
            return name;
        }
    }
}

