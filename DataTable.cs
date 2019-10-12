
        private void GetConstraints(DataTable myTable)
        {
            Console.WriteLine("TableName: " + myTable.TableName);
            //遍历集合输出每一项的名称和值
            foreach (Constraint cs in myTable.Constraints)
            {
                Console.WriteLine("Constraint Name: " + cs.ConstraintName);
                Console.WriteLine("Type: " + cs.GetType().ToString());
                //判断约束是UniqueConstraint还是ForeignKeyConstraint，分别输出
                if (cs is UniqueConstraint)
                    PrintUniqueConstraintProperties(cs);
                if (cs is UniqueConstraint)
                    PrintForeigKeyConstraintProperties(cs);
            }
        }
        private void PrintUniqueConstraintProperties(Constraint cs)
        {
            UniqueConstraint uCS;
            uCS = (UniqueConstraint)cs;
            DataColumn[] colArray;
            colArray = uCS.Columns;
            for (int i = 0; i < colArray.Length; i++)
                Console.WriteLine("Column Name: " + colArray[i].ColumnName);            
        }
        private void PrintForeigKeyConstraintProperties(Constraint cs)
        {
            ForeignKeyConstraint fkCS;
            fkCS = (ForeignKeyConstraint)cs;
            DataColumn[] colArray;
            colArray = fkCS.Columns;
            for (int i = 0; i < colArray.Length; i++)
                Console.WriteLine("Column Name: " + colArray[i].ColumnName);
            colArray = fkCS.RelatedColumns;
            for (int i = 0; i < colArray.Length; i++)
                Console.WriteLine("Related Column Name: " + colArray[i].ColumnName);
        }
