using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            FillMyTreeView();
            base.OnLoad(e);
        }

        //创建一个新的ArrayList来存储Customer对象
        private ArrayList customerArray = new ArrayList();
        class Customer
        {
            protected string s;
            Order order;
            public Customer(string s)
            {
                order = new Order(s);
                this.s = s;
            }
            public Order CustomerOrders
            {
                get
                {
                    return order;
                }
                set
                {
                    order = value;
                }
            }
            public string CustomerName
            {
                get
                {
                    return s;
                }
            }
        }
        class Order : IEnumerable
        {
            string s;
            ArrayList alllist = new ArrayList();
            public Order(string s)
            {
                this.s = s;
            }
            public void Add(object order)
            {
                alllist.Add(order);
            }
            public string OrderID
            {
                get
                {
                    return s;
                }
            }
            public IEnumerator GetEnumerator()
            {
                return ((IEnumerable)alllist).GetEnumerator();
            }
        }
        private void FillMyTreeView()
        {
            //增加customers到ArrayList
            for (int x = 0; x < 1000; x++)
            {
                customerArray.Add(new Customer("Customer" + (x+1).ToString()));
            }
            //增加orders到Customer对象
            foreach(Customer customer1 in customerArray)
            {
                for(int y=0;y<15;y++)
                {
                    customer1.CustomerOrders.Add(new Order("Order" + (y+1).ToString()));
                }
            }
            //创建一个cursor，创建TreeNodes
            Cursor.Current = new Cursor(@"C:\Windows\Cursors\aero_helpsel_xl.cur");
            //重画TreeView
          //  treeView1.BeginUpdate();
          //  treeView1.Nodes.Clear();
            foreach (Customer customer2 in customerArray)
            {
                treeView1.Nodes.Add(new TreeNode(customer2.CustomerName));
                //增加为在当前Customer对象中每个Order对象TreeNode
                foreach (Order order1 in customer2.CustomerOrders)
                {
                    treeView1.Nodes[customerArray.IndexOf(customer2)].Nodes.Add(new TreeNode(customer2.CustomerName + "." + order1.OrderID));
                }
            }
            Cursor.Current = Cursors.Default;
        }
    }
}
