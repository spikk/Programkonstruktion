using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2010_03
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
            return null;
        }

        public string Name { get { return name; } set { name = value; } }

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
            if (!(obj is Person)) throw new ArgumentException("inte person");
            Person p = obj as Person;
            int i = this.Name.CompareTo(p.Name);
            return i;
        }

        public static IComparable max(IComparable val1, IComparable val2)
        {
            if (val1.CompareTo(val2) > 0) return val1; //val1 > val2
            if (val1.CompareTo(val2) < 0) return val2;
            if (val1.CompareTo(val2) == 0) return val1;
            return null;
        }



    }

    class Temp
    {
        public delegate bool MyDelegate(object x, object y);
    }

    class Test
    {
        private string name = "tenta";

        static void a()
        {
            Person p = new Person("1", "anna");
            Person p2 = (Person)p.Clone();
            //Nedan ger null reference fel, kan inte köra .print på null.
            //p2.print();
            //kan istället skriva:
            p.print();
        }

        static void b()
        {
            Person p1 = new Person("1", "data");
            p1 = new Test().bTemp(p1);
            IMyInterface2 imi = p1 as IMyInterface2;
            //Här, om man hade skrivit (p1.f("yes")) istället, så hade den använt den andra metoden f, mindre specifik
            Console.WriteLine(imi.f("yes"));
        }

        Person bTemp(IMyInterface2 imi)
        {
            Person p = imi as Person;
            p.Name = "Hata " + this.name;
            return p;
        }

        static bool f(object a, object b)
        {
            return (a.GetType() == b.GetType());
        }

        static bool f2(object a, object b)
        {
            return (a.GetType() == b.GetType());
        }

        static void c()
        {
            A a;
            Person p1 = new Person("1342", "anna");
            a = p1;
            p1 = a as Person;
            Console.WriteLine((p1.f(p1.Name)).Equals("anna"));

        }

        static void d()
        {
            Temp.MyDelegate d1 = new Temp.MyDelegate(f);
            Temp.MyDelegate d2 = new Temp.MyDelegate(f);
            Person p1 = new Person("1342", "anna");
            IMyInterface imi = p1;
            Console.WriteLine(d1(p1, imi) == d1(p1, imi));

        }

        static void e()
        {
            Person p1 = new Person("1", "data");
            Person p2 = new Person("2", "hata");
            IComparable ic = Person.max(p1, p2);
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
