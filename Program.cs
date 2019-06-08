using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 实验
{
    class Program
    {
        public class ShortStringDictionary:DictionaryBase
        {
            //定义一组获取类的属性值的get方法
            public String this[String key]
            {
                get
                {
                    return ((String)Dictionary[key]);
                }
                set
                {
                    Dictionary[key] = value;
                }
            }
            public ICollection Keys
            {
                get
                {
                    return (Dictionary.Keys);
                }
            }
            public ICollection Values
            {
                get
                {
                    return (Dictionary.Values);
                }
            }
            //定义增加一个对象的方法
            public void Add(String key,String value)
            {
                Dictionary.Add(key, value);
            }
            //超越插入对象的方法
            protected override void OnInsert(object key, object value)
            {
                if (key.GetType() != Type.GetType("System.String"))
                    throw new ArgumentException("key must be ofTypeString.", "key");
                else
                {
                    string strKey = (String)key;
                    if (strKey.Length > 5)
                        throw new ArgumentException("key must be no more than 5 characters", "key");
                }
                if (value.GetType() != Type.GetType("System String"))
                    throw new ArgumentException("value must be ofTypeString.", "value");
                else
                {
                    string strValue = (String)value;
                    if (strValue.Length > 5)
                        throw new ArgumentException("value must be no more than 5 characters", "value");
                }
            }
        }
        public static void PrintKeysAndValues(ShortStringDictionary myCol)
        {
            DictionaryEntry myDE;
            IEnumerator myEnumerator = myCol.GetEnumerator();
            while(myEnumerator.MoveNext())
            if(myEnumerator.Current!=null)
            {
                myDE = (DictionaryEntry)myEnumerator.Current;
                Console.WriteLine("  {0,-5} : {1}", myDE.Key, myDE.Value);
            }
            Console.WriteLine();
        }
        public class SamplesDictionaryBase
        {
            static void Main(string[] args)
            {
                //Creates and initializes a new Diction aryBase.
                ShortStringDictionary mySSC = new ShortStringDictionary();
                //Adds elements to the collection.
                mySSC.Add("One", "a");
                //增加更多的项目到集合中
                Console.WriteLine("Initial contents of the collection :");
                PrintKeysAndValues(mySSC);
            }
        }
    }
}
