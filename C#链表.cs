using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace CSharpConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Link<int> link = new Link<int>();
            link.Add(1);
            link.Add(2);
            link.Add(3);
            link.Add(4);
            link.Add(5);
            link.Add(6);
            link.ShowList();
        }
    }
    /// <summary>
    /// 链表结构类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class LinkNode<T>
    {
        /// <summary>
        /// 数据域
        /// </summary>
        public T data { get; set; }
        /// <summary>
        /// 指针域
        /// </summary>
        public LinkNode<T> next;
    }
    /// <summary>
    /// 对链表进行接口规范
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface ILinkNode<T>
    {
        /// <summary>
        /// 链表节点
        /// </summary>
        LinkNode<T> node { get; }
        /// <summary>
        /// 对链表进行添加元素，数据类型为T
        /// </summary>
        /// <param name="Data"></param>
        void Add(T Data);
    }
    /// <summary>
    /// 继承接口实现链表方法
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Link<T> : ILinkNode<T>
    {
        /// <summary>
        /// 继承接口重写结点
        /// </summary>
        public LinkNode<T> node { get; private set; }
        /// <summary>
        /// 重写增加元素方法
        /// </summary>
        /// <param name="Data"></param>
        public void Add(T Data)
        {
            //中间变量a，增加元素时，令a.data=Data
            LinkNode<T> a = new LinkNode<T>();
            //中间变量b，存在node节点
            LinkNode<T> b = new LinkNode<T>();
            a.data = Data;
            //当node为空时，证明里面什么都没有
            if (node == null) 
                node = a;
            else
            {
                //否则，就应该把node节点备份一下，使b=node
                b = node;
                //然后对b进行循环
                while(b!=null)
                {
                    //如果b.next下一节点不为null
                    if(b.next==null)
                    {
                        //b.next就应该等于a的当前值和下一节点
                        b.next = a;
                        //使b的整体等于b.next
                        b = b.next;
                    }
                    //否则还是使b=b.next，看下节点是否为空，为空才能增加元素，要不然就会覆盖原有的元素
                    b = b.next;
                }
            }
        }
    }
    static class LinkEx
    {
        /// <summary>
        /// 输出链表里的内容
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="link"></param>
        public static void ShowList<T>(this ILinkNode<T> link)
        {
            LinkNode<T> node = link.node;
            while (node!=null)
            {
                Console.WriteLine(node.data);
                node = node.next;
            }
        }
    }
}
