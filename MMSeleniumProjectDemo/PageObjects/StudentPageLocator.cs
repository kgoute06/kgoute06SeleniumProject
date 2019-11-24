using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMSeleniumProjectDemo.PageObjects
{
    public class StudentPageLocator
    {
        public static readonly string firstNameIdLocator = "firstname";
        public static readonly string lastNameIdLocator = "lastname";

        public static readonly string studenformDancinglocator = "(//label[@class='checkbox-inline']//child::input[1])[1]";
        public static readonly string studenformReadinglocator = "(//label[@class='checkbox-inline']//child::input[1])[2]";
        public static readonly string studenformCricketlocator = "(//label[@class='checkbox-inline']//child::input[1])[3]";

        public static readonly string studenformMarriedlocator = "(//label[@class='radio-inline']//child::input[1])[1]";
        public static readonly string studenformSinglelocator = "(//label[@class='radio-inline']//child::input[1])[2]";
        public static readonly string studenformDivorcedlocator = "(//label[@class='radio-inline']//child::input[1])[3]";
    }
}
