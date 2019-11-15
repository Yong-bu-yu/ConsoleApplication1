using System;
using System.Data.SqlClient;

namespace 实验
{
    class Program
    {
        public static void ReadMyData(string myConnString)
        {
            string mySelectQuery = "Select OrderID, CustomerID FROM Orders";
            //根据SQL语句创建SqlConnection实例
            SqlConnection myConnection = new SqlConnection(myConnString);
            SqlCommand myCommand = new SqlCommand(mySelectQuery, myConnection);
            myConnection.Open();
            SqlDataReader myReader = myCommand.ExecuteReader();
            try
            {
                //读出所有数据
                while (myReader.Read())
                {
                    Console.WriteLine(myReader.GetInt32(0) + ", " + myReader.GetString(1));
                }
            }
            finally
            {
                myReader.Close();
                myCommand.Clone();
            }
        }
        static void Main(string[] args)
        {
            ReadMyData("server=(local);user id=sa;password=111111;initial catalog=northwind");
        }
    }
}
