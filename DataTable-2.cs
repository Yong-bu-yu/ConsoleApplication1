using System;
using System.Collections.Generic;
using System.Data;
namespace 实验
{
    class Program
    {
        private void CreateNewDataRow()
        {
            //定义一个DataTable对象
            DataTable myTable;
            myTable = MaKeNamesTable();
            DataRow myRow;
            myRow = myTable.NewRow();
            myRow["fName"] = "John";
            //向myTable的行中加入数据
            myTable.Rows.Add(myRow);
            //输出myTable中所有内容
            foreach (DataColumn dc in myTable.Columns)
                Console.WriteLine("{0} {1} {2}", dc.ColumnName, dc.DataType, dc.DefaultValue);
        }
        private DataTable MaKeNamesTable()
        {
            DataTable namesTable = new DataTable("Names");
            DataColumn idColumn = new DataColumn();
            //定义表列的数据类型、id、值
            idColumn.DataType = Type.GetType("System.Int32");
            idColumn.ColumnName = "id";
            idColumn.DefaultValue = 10;
            //把定义的列对象加入表中
            namesTable.Columns.Add(idColumn);
            DataColumn fNameColumn = new DataColumn();
            fNameColumn.DataType = Type.GetType("System.String");
            fNameColumn.ColumnName = "Fname";
            fNameColumn.DefaultValue = "Fine_Name";
            namesTable.Columns.Add(fNameColumn);
            return namesTable;
        }
        public static void Main(string[] args)
        {
            Program my = new Program();
            my.CreateNewDataRow();
        }
    }
}
