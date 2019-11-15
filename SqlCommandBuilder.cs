using System;
using System.Data;
using System.Data.SqlClient;

namespace 实验
{
    class Program
    {
        public DataSet SelectSqlSrvRows(DataSet myDataSet,string myConnection,string mySelectQuery,string myTableName)
        {
            SqlConnection myConn = new SqlConnection(myConnection);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter()
; myDataAdapter.SelectCommand = new SqlCommand(mySelectQuery, myConn);
            SqlCommandBuilder custCB = new SqlCommandBuilder(myDataAdapter);
            myConn.Open();
            DataSet custDS = new DataSet();
            myDataAdapter.Fill(custDS, "Customers");
            myDataAdapter.Update(custDS, "Customers");
            myConn.Close();
            return custDS;
        }
        static void Main(string[] args)
        {

        }
    }
}
