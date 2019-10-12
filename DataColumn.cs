        private void MakeTable(DataTable myTable)
        {
            DataTable meTable = new DataTable("myTable");
            DataColumn myColumn = new DataColumn();
            myColumn.DataType = Type.GetType("System.Decimal");
            myColumn.AllowDBNull = false;
            myColumn.Caption = "Price";
            myColumn.ColumnName = "Price";
            myColumn.DefaultValue = 25;
            meTable.Columns.Add(myColumn);
            DataRow myRow;
            for (int i = 0; i < 10; i++)
            {
                myRow = meTable.NewRow();
                myRow["Price"] = i + 1;
                meTable.Rows.Add(myRow);
            }
        }
