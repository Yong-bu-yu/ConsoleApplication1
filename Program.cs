using System;
using System.Reflection;

namespace ConsoleApp1
{
    class Program
    {
        public class Myproperty
        {
            //设置默认名称
            private string caption = "A Default caption";
            //定义获取名称的公共方法
            public string Caption
            {
                get
                {
                    return caption;
                }
                set
                {
                    if (caption != value)
                    {
                        caption = value;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("\nReflection.PropertInfo");
            //定义一个Myproperty类对象
            Myproperty myproperty = new Myproperty();
            //定义MyType获取Myproperty的类型
            Type Mytype = Type.GetType("Myproperty");
            //定义一个PropertyInfo类对象，获取MyType的Caption值
            PropertyInfo MypropertyInfo = Mytype.GetProperty("Caption");
            Console.Write("\nGetValue - " + MypropertyInfo.GetValue(myproperty, null));
            //重新设置Myproperty的Caption值
            MypropertyInfo.SetValue(myproperty, "This caption has been changed", null);
            Console.Write("\n" + Mytype.FullName + "." + MypropertyInfo.Name + " has a PropertyType of " + MypropertyInfo.PropertyType);
            Console.Write("\nGetValue - " + MypropertyInfo.GetValue(myproperty, null));
            MethodInfo MygetmethodInfo = MypropertyInfo.GetSetMethod();
            Console.Write("\nSetAccessor for " + MypropertyInfo.Name+" return a "+MygetmethodInfo.ReturnType);
            Console.Write("\n\n" + Mytype.FullName + "." + MypropertyInfo.Name + " GetSetMethod - " + MypropertyInfo.GetSetMethod());
        }
    }
}
