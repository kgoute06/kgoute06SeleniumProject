using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject.Collections.ConvertDataTable_List
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Address { get; set; }
        public string MobileNo
        {
            get; set;
        }

        public void studentLIst()
        {
            DataTable dt = new DataTable("Student");
            dt.Columns.Add("StudentId", typeof(Int32));
            dt.Columns.Add("StudentName", typeof(string));
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("MobileNo", typeof(string));
            //Data  
            dt.Rows.Add(1, "Manish", "Hyderabad", "0000000000");
            dt.Rows.Add(2, "Venkat", "Hyderabad", "111111111");
            dt.Rows.Add(3, "Namit", "Pune", "1222222222");
            dt.Rows.Add(4, "Abhinav", "Bhagalpur", "3333333333");

            
            
        }

        

    }

}
