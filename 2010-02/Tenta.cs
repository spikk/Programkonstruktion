using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2010_02
{
    class Temp
    {
        public delegate bool MyDelegate(object x, object y);
    }

    class A
    {
        public void print()
        {
            Console.WriteLine("Hej A");
        }

    }

    interface IMyInterface
    {
        object f(string str);
    }

    class Person : A, IMyInterface
    {
        private string id;
        private string name;
        public Person() { }
        public Person(string id, string name)
        {
            Name = name;
            this.id = id;
        }

        public string Name { get { return name; } set { name = value; } }

        public new void print()
        {
            base.print();
            Console.WriteLine(Name);
        }

        public object f(string str)
        {
            return str.GetType();
        }


    }



    class Test
    {
        private string name = "tenta";
        static void a()
        {
            Person p = new Person("1", "anna");
            p.print();
        }

        static void b()
        {
            Person p1 = new Person("1", "data");
            new Test().bTemp(p1);
            p1.print();
        }

        void bTemp(IMyInterface imi)
        {
            Person p = imi as Person;
            p.Name = "Hata " + this.name;
        }

        static void c()
        {
            A a;
            Person p1 = new Person("1342", "anna");
            a = p1;
            p1 = a as Person;
            Console.WriteLine(p1.f(p1.Name));
        }

        static bool f(object a, object b)
        {
            return (a.GetType() == b.GetType());
        }

        static void d()
        {
            Temp.MyDelegate d = new Temp.MyDelegate(f);
            Person p1 = new Person("1342", "anna");
            IMyInterface imi = p1;
            bool b = d(new Person(), imi);
            Console.WriteLine(b);

        }

        static void e()
        {
            Person p1 = new Person("1342", "anna");
            object p2 = new Person("1562", "fatso");
            p2 = p1;
            Console.WriteLine(p1 == p2);
        }

/*
        static void Main(string[] args)
        {
            a();
            b();
            c();
            d();
            e();
            Console.Read();
        }*/
    }
}
