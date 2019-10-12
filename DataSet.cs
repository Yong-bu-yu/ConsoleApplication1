        private void MakeTableWithForeignConstraint()
        {
            DataSet myDataSet = new DataSet("myDataSet");
            DataTable tCust = new DataTable("Customers");
            DataTable tOrders = new DataTable("Orders");
            DataColumn cName = new DataColumn("Name");
            DataColumn cID = new DataColumn("ID");
            DataColumn cOrderID = new DataColumn("OrderID");
            DataColumn cDate = new DataColumn("OrderDate");
            //把创建的列加入到表中
            tCust.Columns.Add(cName);
            tCust.Columns.Add(cID);
            tOrders.Columns.Add(cOrderID);
            tOrders.Columns.Add(cDate);
            //把Tables加入到DataSet
            myDataSet.Tables.Add(tCust);
            myDataSet.Tables.Add(tOrders);
            //创建两个表之间的关系
            DataRelation myRelation = new DataRelation("CustomersOrders", cID, cOrderID, true);
            myDataSet.Relations.Add(myRelation);
            foreach (DataTable t in myDataSet.Tables)
            {
                Console.WriteLine(t.TableName);
                Console.WriteLine("Constraints.Count " + t.Constraints.Count);
                Console.WriteLine("ParentRelations.Count " + t.ParentRelations.Count);
                Console.WriteLine("ChildRelations.Count " + t.ChildRelations.Count);
                foreach (Constraint cstrnt in t.Constraints)
                {
                    Console.WriteLine(cstrnt.ConstraintName);
                    Console.WriteLine(cstrnt.GetType());
                }
            }
        }
