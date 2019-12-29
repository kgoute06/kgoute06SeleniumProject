using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMSeleniumProjectDemo.TestUtils
{
    public class DBConnect
    {
        private SqlConnection myConnection;
        private string queryString;
        private string dbName;
        private string serverName;
        private string userName = "kgoute";
        private string password = "Saanvi$2020";


        public DBConnect(string queryString, string dbName, string serverName)
        {


            this.dbName = dbName;
            this.queryString = queryString;
            this.serverName = serverName;

        }

        public DBConnect(string queryString, string dbName, string serverName, String userName, String password)
        {


            this.dbName = dbName;
            this.queryString = queryString;
            this.serverName = serverName;
            this.userName = userName;
            this.password = password;

        }


        // ExecuteDBQuery Method

        public DataTable ExecuteDBQuery()

        {


            myConnection = new SqlConnection("user id=" + userName + ";" +
                                            "password=" + password + ";server=" + serverName + ";" +
                                            "Trusted_Connection=yes;" +
                                            "database=" + dbName + "; " +
                                            "connection timeout=30");

            SqlDataReader myReader = null;
            myConnection.Close(); //Close any existing connections
            myConnection.Open();

            SqlCommand myCommand = new SqlCommand(queryString, myConnection);
            myReader = myCommand.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(myReader);

            return dataTable;

        }
    }
}
