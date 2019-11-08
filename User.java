import java.awt.*;
import java.awt.event.*;
import java.util.*;
import javax.swing.*;
public class demo4 
{
	public static void main(String[] args) 
	{
		Form1 form=new Form1();
	}
}
class Form1 extends Form implements ActionListener
{
	public Form1()
	{
		InitializeComponent();
		button1.addActionListener(this);
		button2.addActionListener(this);
	}
	 public class User
     {
         private String userName;
         private String password;
         public void setUserName(String userName)
         {
             this.userName = userName;
         }
         public String getUserName()
         {
             return userName;
         }
         public void setPassword(String password)
         {
             this.password = password;
         }
         public String getPassword()
         {
             return password;
         }
     }
     public interface IAlert
     {
         void AlertNull();
         void AlertFailed();
         void AlertSuccess();
     }
     public interface IValidate
     {
         int Validate(User user);
     }
     public class UserValidator implements IValidate
     {
         public int Validate(User user)
         {
             String userName = user.getUserName();
             String password = user.getPassword();
             //均为空
             if ((userName.equals("")) && (password.equals("")))
             {
                 return 0;
             }
             //相等
             if (userName.equals("admin") && password.equals("admin"))
             {
                 return 1;
             }
             //用户名或者密码输入错误
             return -1;
         }
     }
     public class Alertor implements IAlert
     {

         public void AlertNull()
         {
             JOptionPane.showMessageDialog(null,"用户名和密码不能为空");
         }

         public void AlertFailed()
         {
        	 JOptionPane.showMessageDialog(null,"用户名或密码错误");
         }

         public void AlertSuccess()
         {
        	 JOptionPane.showMessageDialog(null,"登录成功");
         }
     }
     public void actionPerformed(ActionEvent e) 
     {
		if(e.getSource()==button1)
		{
            int flag;
            User u = new User();
            UserValidator user = new UserValidator();
            Alertor a = new Alertor();
            u.setUserName(textBox1.getText());
            u.setPassword(textBox2.getText());
            flag = user.Validate(u);
            switch (flag)
            {
                case 0:
                    a.AlertNull();
                    break;
                case 1:
                    a.AlertSuccess();
                    break;
                case -1:
                    textBox2.setText("");
                    a.AlertFailed();
                    break;
                default:
                    break;
            }
		}
		else if (e.getSource()==button2) 
		{
			//form.dispose();
			form.dispatchEvent(new WindowEvent(form,WindowEvent.WINDOW_CLOSING) );
		}
	 }
}
class Form
{
	protected JFrame form;
	protected JTextArea textBox1;
	protected JPasswordField textBox2;
	protected JLabel label1;
	protected JLabel label2;
	protected JLabel label3;
	protected JButton button1;
	protected JButton button2;
	void InitializeComponent()
	{
		textBox1=new JTextArea();
		textBox2=new JPasswordField();
		label1=new JLabel();
		label2=new JLabel();
		label3=new JLabel();
		button1=new JButton();
		button2=new JButton();
		
		//textBox1
		textBox1.setLocation(new Point(206,125));
		textBox1.setSize(187, 25);
		
		//textBox2
		textBox2.setLocation(new Point(206,235));
		textBox2.setSize(187, 25);
		
		//label1
		label1.setLocation(new Point(136,128));
		label1.setSize(52, 15);
		label1.setText("用户名");
		
		//label2
		label2.setLocation(new Point(136,238));
		label2.setSize(52, 15);
		label2.setText("密码");
		
		//label3
		label3.setFont(new Font("宋体", Font.PLAIN, 30));
		label3.setLocation(new Point(240,43));
		label3.setSize(196, 44);
		label3.setText("用户登录");
		
		//button1
		button1.setLocation(new Point(139,342));
		button1.setSize(75, 23);
		button1.setText("登录");
		
		//button2
		button2.setLocation(new Point(384,342));
		button2.setSize(75, 23);
		button2.setText("退出");
		
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
		form.add(textBox1);
		form.add(textBox2);
	}
}
