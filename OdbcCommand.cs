public void ReadMyData(string myConnString)
{
            string mySelectQuery = "Select OrderID,CustomerID FROM Orders";
            OdbcConnection myConnection = new OdbcConnection(myConnString);
            OdbcCommand myCommand = new OdbcCommand(mySelectQuery, myConnection);
            myConnection.Open();
            OdbcDataReader myReader = myCommand.ExecuteReader();
            try
            {
                while (myReader.Read())
                    Console.WriteLine(myReader.GetInt32(0) + "," + myReader.GetString(1));
            }
            finally
            {
                //always call Close when done with reader.
                myReader.Close();
                //always call Close when down with connection.
                myConnection.Close();
            }
}
