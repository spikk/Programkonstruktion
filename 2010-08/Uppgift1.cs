using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2010_08
{

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

    interface IMyInterface2
    {
        object f(string str);
    }

    class Person : A, IMyInterface, IMyInterface2, ICloneable, IComparable
    {
        private string id;
        private string name;

        public Person() { }
        public Person(string id, string name)
        {
            Name = name;
            this.id = id;
        }

        public object Clone()
        {
            return new Person();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public new void print()
        {
            IMyInterface im = this;
            Console.WriteLine(im.f("hata") + Name);
        }

        public object f(string str)
        {
            return str + "tenta";
        }

        object IMyInterface2.f(string str)
        {
            return str.GetType();
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Person)) throw new ArgumentException("inte Person");
            Person p = obj as Person;
            return this.Name.CompareTo(p.Name);
        }

        public static IComparable vad(IComparable val1, IComparable val2)
        {
            if (val1.CompareTo(val2) < 0) return val1;
            if (val1.CompareTo(val2) > 0) return val2;
            if (val1.CompareTo(val2) == 0) return val1;
            return null;
        }

    }

    class Temp
    {
        public delegate int MyDelegate(object x, object y);
    }

    class Uppgift1
    {
        private string name = "tenta";

        static void a()
        {
            Person p = new Person("1", "anna");
            Person p2 = (Person)p.Clone();
            p2.print();
        }

        static void b()
        {
            Person p1 = new Person("1", "data");
            p1 = new Uppgift1().bTemp(p1);
            IMyInterface2 imi = p1 as IMyInterface2;
            Console.WriteLine(imi);
        }

        Person bTemp(IMyInterface2 imi)
        {
            Person p = imi as Person;
            p.Name = "Hata" + this.name;
            return p;
        }

        static void c()
        {
            A a;
            Person p1 = new Person("1342", "anna");
            a = p1 as A;
            Console.WriteLine((p1.f(p1.Name)).Equals("anna"));

        }

        static int f(object a, object b)
        {
            return 31;
        }

        static void d()
        {
            Temp.MyDelegate d1 = new Temp.MyDelegate(f);
            Temp.MyDelegate d2 = new Temp.MyDelegate(f);
            Person p1 = new Person("1342", "anna");
            IMyInterface imi = p1;
            Console.WriteLine(d1(p1, imi));


        }

        static void e()
        {
            Person p1 = new Person("1", "data");
            Person p2 = new Person("2", "hata");
            IComparable ic = Person.vad(p1, p2);
            Person p = ic as Person;
            Console.WriteLine("{0} {1}", p.Name, "\n");

        }
        static void Main(string[] args)
        {
            a();
            b();
            c();
            d();
            e();
            Console.Read();
        }
    }
}
