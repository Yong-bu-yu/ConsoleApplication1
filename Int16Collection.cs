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
        public class Int16Collection : CollectionBase
        {
            public Int16 this[int index]
            {
                get 
                {
                    return ((Int16)List[index]);
                }
                set 
                {
                    List[index] = value;
                }
            }
            //定义一个加入Int数据的方法
            public int Add(Int16 value)
            {
                return (List.Add(value));
            }
            //定义一个检索每个数据的位置的方法
            public int IndexOf(Int16 value)
            {
                return (List.IndexOf(value));
            }
            //定义在某个位置插入数据的方法
            public void Insert(int index,Int16 value)
            {
                List.Insert(index, value);
            }
            //定义一个删除某个数据的方法
            public void Remove(Int16 value)
            {
                List.Remove(value);
            }
            //测试某个数据是否存在的方法
            public bool Contains(Int16 value)
            {
                return (List.Contains(value));
            }
            //超越基类的OnInsert
            protected override void OnInsert(int index, object value)
            {
                if (value.GetType() != Type.GetType("System.Int16"))
                    throw new ArgumentException("value must be ofTypeint16.", "value");
            }
            //超越基类的OnRemove方法
            protected override void OnRemove(int index, object value)
            {
                if (value.GetType() != Type.GetType("System.Int16"))
                    throw new ArgumentException("value must be ofTypeint16.", "value");
            }
            //超越基类的OnSet方法
            protected override void OnSet(int index, object oldValue, object newValue)
            {
                if (newValue.GetType() != Type.GetType("System.Int16"))
                    throw new ArgumentException("value must be ofTypeint16.", "newValue");
            }
            //超越基类的OnValidate方法
            protected override void OnValidate(object value)
            {
                if (value.GetType() != Type.GetType("System.Int16"))
                    throw new ArgumentException("value must be ofTypeint 16");
            }
        }
        public static void PrintIndexAndValues(Int16Collection myCol)
        {
            int i = 0;
            IEnumerator myEnumerator = myCol.GetEnumerator();
            while (myEnumerator.MoveNext())
                Console.WriteLine(" [{0}]: {1}", i++, myEnumerator.Current);
            Console.WriteLine();
            
        }
        static void Main(string[] args)
        {
            Int16Collection myI16 = new Int16Collection();
            myI16.Add((Int16)1);
            //加入2,3,5,7作为元素
            Console.WriteLine("Initial contents of the collection:");
            PrintIndexAndValues(myI16);
            Console.WriteLine("Contains 3:{0}", myI16.Contains(3));
            Console.WriteLine("2 is at index {0}.", myI16.IndexOf(2));
            Console.WriteLine();
            myI16.Insert(3, (Int16)13);
            Console.WriteLine("Contents of the collection after inserting at index 3:");
            PrintIndexAndValues(myI16);
            myI16[4] = 123;
            Console.WriteLine("Contents of the collection after setting the element at index 4 to 123:");
            PrintIndexAndValues(myI16);
            myI16.Remove((Int16)2);
            Console.WriteLine("Contents of the collection after removing the element 2:");
            for (int i = 0; i < myI16.Count; i++)
                Console.WriteLine(" [{0}]: {1}", myI16[i]);
        }
    }
}
