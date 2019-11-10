package Form;
import java.awt.*;
import javax.swing.*;

public class Form 
{

	protected JFrame form;
	protected JTextArea textBox1;
	protected JTextArea textBox2;
	protected JTextArea textBox3;
	protected JComboBox comboBox1;
	protected JLabel label1;
	protected JLabel label2;
	protected JLabel label3;
	protected JLabel label4;
	protected JLabel label5;
	protected JButton button1;
	protected JButton button2;
	protected JRadioButton radioButton1;
	protected JRadioButton radioButton2;
	protected ButtonGroup buttonGroup1;
	void InitializeComponent()
	{
		textBox1=new JTextArea();
		textBox2=new JTextArea();
		textBox3=new JTextArea();
		comboBox1=new JComboBox(new String[]{"","教授","副教授"});
		label1=new JLabel();
		label2=new JLabel();
		label3=new JLabel();
		label4=new JLabel();
		label5=new JLabel();
		button1=new JButton();
		button2=new JButton();
		radioButton1=new JRadioButton();
		radioButton2=new JRadioButton();
		buttonGroup1=new ButtonGroup();
		
		//textBox1
		textBox1.setLocation(new Point(148,179));
		textBox1.setSize(187, 25);
		
		//textBox2
		textBox2.setLocation(new Point(148,313));
		textBox2.setSize(187, 25);
		
		//textBox3
		textBox3.setLocation(new Point(148,370));
		textBox3.setEditable(false);
		textBox3.setSize(242, 25);
		
		//comboBox1
		comboBox1.setEditable(false);
		comboBox1.setLocation(new Point(148,250));
		comboBox1.setSize(121,23);
		
		//label1
		label1.setFont(new Font("宋体",Font.PLAIN,45));
		label1.setLocation(new Point(70,63));
		label1.setSize(460, 43);
		label1.setText("高校工资管理模拟程序");
		
		//label2
		label2.setLocation(new Point(83,189));
		label2.setSize(37, 15);
		label2.setText("姓名");
		
		//label3
		label3.setLocation(new Point(83,258));
		label3.setSize(37, 15);
		label3.setText("职位");
		
		//label4
		label4.setLocation(new Point(83,323));
		label4.setSize(37,15);
		label4.setText("课时");
		
		//label5
		label5.setLocation(new Point(83,380));
		label5.setSize(37,15);
		label5.setText("工资");
		
		//button1
		button1.setLocation(new Point(415,370));
		button1.setSize(80, 29);
		button1.setText("确定");
		
		//button2
		button2.setLocation(new Point(415,410));
		button2.setSize(80, 29);
		button2.setText("退出");
		
		//radioButton1
		radioButton1.setLocation(new Point(332,179));
		radioButton1.setSize(58,19);
		radioButton1.setText("全职");
		
		//radioButton2
		radioButton2.setLocation(new Point(332,205));
		radioButton2.setSize(58,19);
		radioButton2.setText("兼职");
		
		//Form1
		form=new JFrame("Form1");
		form.setBounds(200,100,618,497);
		form.setLayout(null);
		form.setVisible(true);
		form.add(button1);
		form.add(button2);
		form.add(label1);
		form.add(label2);
		form.add(label3);
		form.add(label4);
		form.add(label5);
		form.add(textBox1);
		form.add(textBox2);
		form.add(textBox3);
		form.add(comboBox1);
		form.add(radioButton1);
		form.add(radioButton2);
		buttonGroup1.add(radioButton1);
		buttonGroup1.add(radioButton2);
	}
}
