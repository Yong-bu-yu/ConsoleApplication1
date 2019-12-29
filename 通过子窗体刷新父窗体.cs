using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
            SqlConnection sqlConnection = new SqlConnection("Data Source=(localdb)\\ProjectsV13;Initial Catalog=SQL_1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from dbo.Table1", sqlConnection);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "dbo.Table1");
            dataGridView1.DataSource = dataSet.Tables["dbo.Table1"].DefaultView;
            foreach (DataRow dataRow in dataSet.Tables["dbo.Table1"].Rows)
            {
                comboBox1.Items.Add(dataRow[0].ToString());
            }

            Text = "通过子窗口刷新父窗口";
            编辑ToolStripMenuItem.Click += 编辑ToolStripMenuItem_Click;
            退出ToolStripMenuItem.Click += 退出ToolStripMenuItem_Click;
            form.Size = new Size(227, 351);
            form.MinimumSize = form.Size;
            form.MaximumSize = form.Size;
            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
            button3.Click += Button3_Click;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            base.OnLoad(e);
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            form.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                SqlConnection sqlConnection = new SqlConnection("Data Source=(localdb)\\ProjectsV13;Initial Catalog=SQL_1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from dbo.Table1", sqlConnection);

                SqlCommand sqlCommand = new SqlCommand("delete from dbo.Table1 where 编号 = @number", sqlConnection);
                sqlCommand.Parameters.Add("@number", SqlDbType.Int).Value = comboBox1.Text;
                sqlCommand.ExecuteNonQuery();

                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "dbo.Table1");
                dataGridView1.DataSource = dataSet.Tables["dbo.Table1"].DefaultView;
                comboBox1.Items.Remove(comboBox1.Text);
                comboBox1.Text = null;
            }
            else
                MessageBox.Show("编号为空");
        }

        FlowLayoutPanel panel = new FlowLayoutPanel();
        Label label1 = new Label(), label2 = new Label(), label3 = new Label(), label4 = new Label(), label5 = new Label(), label6 = new Label(), label7 = new Label();
        Button button1 = new Button(), button2 = new Button(), button3 = new Button();
        TextBox textBox1 = new TextBox(), textBox2 = new TextBox(), textBox3 = new TextBox(), textBox4 = new TextBox();
        ComboBox comboBox1 = new ComboBox();
        Form form = new Form();
        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form.Text = "子窗口页面";
            label1.Text = "个人信息";
            label2.Text = "编号：";
            label3.Text = "姓名：";
            label4.Text = "电话：";
            label5.Text = "住址：";
            label6.Text = "删除信息";
            label7.Text = "编号：";
            button1.Text = "提交";
            button2.Text = "取消";
            button3.Text = "删除";
            panel.Dock = DockStyle.Fill;
            panel.Size = new Size(100, 100);
            panel.Controls.Add(label1);
            panel.Controls.Add(label2);
            panel.Controls.Add(textBox1);
            panel.Controls.Add(button1);
            panel.Controls.Add(label3);
            panel.Controls.Add(textBox2);
            panel.Controls.Add(label4);
            panel.Controls.Add(textBox3);
            panel.Controls.Add(button2);
            panel.Controls.Add(label5);
            panel.Controls.Add(textBox4);
            panel.Controls.Add(label6);
            panel.Controls.Add(label7);
            panel.Controls.Add(comboBox1);
            panel.Controls.Add(button3);
            form.Controls.Add(panel);
            form.ShowDialog();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            bool flag = true;
            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                if (comboBox1.Items[i].ToString()==textBox1.Text)
                {
                    flag = false;
                }
            }
            if (flag)
            {
                try
                {
                    SqlConnection sqlConnection = new SqlConnection("Data Source=(localdb)\\ProjectsV13;Initial Catalog=SQL_1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    sqlConnection.Open();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from dbo.Table1", sqlConnection);

                    SqlCommand sqlCommand = new SqlCommand("insert into dbo.Table1(编号,姓名,电话,住址) values(@number,@name,@telephone,@address)", sqlConnection);
                    sqlCommand.Parameters.Add("@number", SqlDbType.Int).Value = textBox1.Text;
                    sqlCommand.Parameters.Add("@name", SqlDbType.NChar, 12).Value = textBox2.Text;
                    sqlCommand.Parameters.Add("@telephone", SqlDbType.BigInt).Value = textBox3.Text;
                    sqlCommand.Parameters.Add("@address", SqlDbType.NChar, 12).Value = textBox4.Text;
                    sqlCommand.ExecuteNonQuery();

                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet, "dbo.Table1");
                    dataGridView1.DataSource = dataSet.Tables["dbo.Table1"].DefaultView;
                    comboBox1.Items.Add(textBox1.Text);
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
            else
                MessageBox.Show("编号重复");
        }
    }
}
