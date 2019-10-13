
        private void CreateRelation()
        {
            DataColumn parentCol;
            DataColumn childCol;
            DataSet DataSet1=new DataSet();
            //把数据源与数据表相绑定
            parentCol = DataSet1.Tables["Customers"].Columns["CustID"];
            childCol = DataSet1.Tables["Orders"].Columns["CustID"];
            DataRelation relCustOrder = new DataRelation("CustomersOrder", parentCol, childCol);
            DataSet1.Relations.Add(relCustOrder);
        }
