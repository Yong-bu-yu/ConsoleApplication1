using System;
using System.Collections;
using System.IO;
using System.Threading;
namespace 实验
{
    class Program
    {
        class RWDemo 
        {
            ReaderWriterLock rwlock;
            int value;
            byte[] buf = new byte[1];
            MemoryStream stream;
            public RWDemo()
            {
                //创建一个读写锁
                rwlock = new ReaderWriterLock();
                value = 4;
                //创建一个内存流
                stream = new MemoryStream();
            }
            public void WriteSome()
            {
                //设置保护锁
                rwlock.AcquireWriterLock(-1);
                //使线程睡眠1秒钟
                Thread.Sleep(1000);
                buf[0] = (byte)value;
                stream.Position = 0;
                //向流中写入0
                stream.Write(buf, 0, buf.Length);
                Console.WriteLine("Vaule written was {0}", value);
                //释放写保护锁
                rwlock.ReleaseWriterLock();
            }
            public void ReadSome()
            {
                //使线程睡眠1秒钟
                Thread.Sleep(1000);
                //设置读保护锁
                rwlock.AcquireReaderLock(-1);
                stream.Position = 0;
                Console.WriteLine("Value read was {0}", stream.ReadByte());
                //释放读保护锁
                rwlock.ReleaseReaderLock();
            }
        }
        public static void Main(string[] args)
        {
            RWDemo demo = new RWDemo();
            //创建线程one并与demo.ReadSome相绑定
            Thread one = new Thread(new ThreadStart(demo.ReadSome));
            //创建线程two并与demo.ReadSome相绑定
            Thread two = new Thread(new ThreadStart(demo.ReadSome));
            //创建线程three并与demo.WriteSome相绑定
            Thread three = new Thread(new ThreadStart(demo.WriteSome));
            //启动3个线程
            one.Start();
            two.Start();
            three.Start();
        }
    }
}
