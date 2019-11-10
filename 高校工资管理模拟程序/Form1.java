package Form;
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
public class Form1 extends Form implements ActionListener
{
	public Form1()
	{
		InitializeComponent();
		button1.addActionListener(this);
		button2.addActionListener(this);
	}

    public abstract class Employee
    {
        private String name;
        private String title;
        private float wage;
        public abstract void calculateWage();
        public float getWage()
        { return wage; }
        public void setName(String name)
        { this.name = name; }
        public String getName()
        { return name; }
        public void setTitle(String title)
        { this.title = title; }
        public String getTitle()
        { return title; }
        protected void setWage(float wage)
        { this.wage = wage; }
    }
    public class FulltimeTeacher extends Employee
    {
        private float basicwage;
        private float extraclasshour;
        public void calculateWage()
        {
            if (this.getTitle().equals("副教授"))
                this.setWage(this.extraclasshour * 80 + 4000);
            if (this.getTitle().equals("教授"))
                this.setWage(this.extraclasshour * 100 + 5000);
        }
        public void setBasicwage(float basicwage)
        { this.basicwage = basicwage; }
        public float getBasicwage()
        { return basicwage; }
        public void setExtraclasshour(float extraclasshour)
        { this.extraclasshour = extraclasshour; }
        public float getExtraclasshour()
        { return extraclasshour; }
    }
    public class ParttimeTeacher extends Employee
    {
        private float classhour;
        public void calculateWage()
        {
            if (this.getTitle().equals("副教授"))
                this.setWage(this.getClasshour() * 100);
            if (this.getTitle().equals("教授"))
                this.setWage(this.getClasshour() * 150);
        }
        public void setClasshour(float classhour)
        { this.classhour = classhour; }
        public float getClasshour()
        { return classhour; }
    }
     public void actionPerformed(ActionEvent e) 
     {
		if(e.getSource()==button1)
		{
			for(Component component : form.getContentPane().getComponents())
			{
				if("javax.swing.JTextArea".equals(component.getClass().getName()))
				{
					if(!component.equals(textBox3)&&textBox1.getText().equals("")||textBox2.getText().equals(""))
					{
						JOptionPane.showMessageDialog(null, "输入不为空");
						textBox3.setText("");
						break;
					}
				}
				if("javax.swing.JComboBox".equals(component.getClass().getName()))
				{
					if(comboBox1.getSelectedItem()=="")
					{
						JOptionPane.showMessageDialog(null, "请选择职业");
						break;
					}
				}
				if("javax.swing.JRadioButton".equals(component.getClass().getName()))
				{
					if(radioButton1.isSelected()==false&&radioButton2.isSelected()==false)
					{
						JOptionPane.showMessageDialog(null, "请选择全职/兼职");
						break;
					}
				}
			}
			if(radioButton1.isSelected()&&textBox2.getText()!="")
			{
				FulltimeTeacher fullTeacher=new FulltimeTeacher();
				fullTeacher.setName(textBox1.getText());
				fullTeacher.setTitle(comboBox1.getSelectedItem().toString());
				try 
				{
					fullTeacher.setExtraclasshour(Float.parseFloat(textBox2.getText()));
				} 
				catch (Exception e2) 
				{
					JOptionPane.showMessageDialog(null, "输入错误");
				}
				fullTeacher.calculateWage();
				textBox3.setText(fullTeacher.getName()+"的工资为："+fullTeacher.getWage());
			}
			if(radioButton2.isSelected()&&textBox2.getText()!="")
			{
				ParttimeTeacher partTeacher=new ParttimeTeacher();
				partTeacher.setName(textBox1.getText());
				partTeacher.setTitle(comboBox1.getSelectedItem().toString());
				try 
				{
					partTeacher.setClasshour(Float.parseFloat(textBox2.getText()));
				} 
				catch (Exception e2) 
				{
					JOptionPane.showMessageDialog(null, "输入错误");
				}
				partTeacher.calculateWage();
				textBox3.setText(partTeacher.getName()+"的工资为："+partTeacher.getWage());
			}
		}
		else if (e.getSource()==button2) 
		{
			//form.dispose();
			form.dispatchEvent(new WindowEvent(form,WindowEvent.WINDOW_CLOSING) );
		}
	 }
}
