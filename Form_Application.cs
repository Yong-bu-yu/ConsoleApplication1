private void button1_Click(object sender, EventArgs e)
        {
            //利用for循环输出1到3
            int i = 3;
            for (int j = 1; j <=i; j++)
            {
                listBox1.Items.Add("自动运行了" + j + "次");
            }
            //用户选择是否退出
            while (MessageBox.Show("Exit application?","",MessageBoxButtons.YesNo)==DialogResult.No)
            {
                //增加计算器的值
                i++;
                listBox1.Items.Add("用户单击运行了" + i + "次");
            }
            //用户选择退出时执行
            Application.Exit();
        }
