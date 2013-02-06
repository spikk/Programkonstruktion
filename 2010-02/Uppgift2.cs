using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2010_02
{
    public delegate void MyDelegate();

    class Count
    {
        private string id;
        private int antal;

        public int Antal
        {
            get { return antal; }
            set { antal = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public Count(string id, int antal)
        {
            this.id = id;
            this.antal = antal;
        }

        public override bool Equals(object obj)
        {
            Count c = (Count)obj;
            return (this.id == c.id);
        }

        public static Count operator +(Count a1, Count a2)
        {
            return new Count(("data" + "hata"), a2.antal);
        }

        public override int GetHashCode()
        {
            return 30;
        }

        public void inc()
        {
            for (int i = 0; i < antal; i++)
            {
                Console.WriteLine("Tråd: {0} {1}", id, i);
                Thread.Sleep(5);
            }
        }

    }

    public class B : List<string>
    {

    }

    class Run
    {
        static void Main(string[] args)
        {
            a();
            b();
            c();
            Console.Read();
        }

        public static void a()
        {
            Count c1 = new Count("Count1", 5);
            Count c2 = new Count("Count2", 5);

            MyDelegate md = new MyDelegate(c1.inc);
            System.Threading.Thread t1, t2;
            t1 = new Thread(new ThreadStart(md));
            t2 = new Thread(new ThreadStart(md));

            t1.Start();
            t2.Start();

           
        }

        public static void b()
        {
            //nedanstående rad saknade namespace i originalversionen, då funkar det inte!
            MethodInfo[] mi = Type.GetType("_2010_02.B").GetMethods();
            for (int i = 0; i < mi.Length; i++)
                Console.WriteLine(" {0} ", mi[i].Name);
        }

        public static void c()
        {
            Count c1 = new Count("Count1", 5);
            Count c2 = new Count("Count1", 5);
            Console.WriteLine(c1.Equals(c2));
            Count c3 = c1 + c2;
            Console.WriteLine(c3.Id);
        }
    }


}
