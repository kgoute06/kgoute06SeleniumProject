using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject
{
    public class InheritanceEmployeeProgram
    {
        public string empFName;
        public string empLName;
        public string eMail;

        public void EmpFullName()
        {
            Console.WriteLine(empFName + "" + empLName);
        }
    }

    public class PartTimeEmployee : InheritanceEmployeeProgram
    {
        public float monthalySalary;

    }

    public class FullTimeEmployee : InheritanceEmployeeProgram
    {
        public float yearlySalar;

    }

    public class WeeklyEmployee : FullTimeEmployee
    {
        public float weeklySalary;

    }


}
