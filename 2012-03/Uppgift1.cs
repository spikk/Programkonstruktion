using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012_03
{
    public class Car
    {
        virtual public void f() { Console.WriteLine("Just a car"); }
        public void talk() { f(); }
    }

    public class Volvo : Car
    {
        public override void f()
        {
            Console.WriteLine("Jag är bäst");
        }
    }
    class Audi : Car
    {
        public override void f()
        {
            Console.WriteLine("Ich bin wunderbar");
        }
    }

    interface IMyInterface1
    {
        object whoAreYou(IMyInterface1 imi);
    }

    interface IMyInterface2
    {
        object whoAreYou(string str);
    }

    class A
    {
        private string name = "SYSA14";
        private ArrayList a = new ArrayList();

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public void print(Person p)
        {
            Console.WriteLine(p.Name);
        }
    }

    class Person : A, IMyInterface1, IMyInterface2, IComparable
    {
        private string id;
        private string teacher;

        public Person(){}
        public Person(string teacher)
        {
            this.teacher = "Teacher studenter";
        }

        public Person(string id, string name)
        {
            Name = name;
            this.id = id;
            this.teacher = " Teacher studenter";
        }

        public new void print(Person p)
        {
            string s = "Mina studenter ";
            s += p.Name;
            s += teacher.Insert(8, " älskar sina");
            Console.WriteLine("Result =" + "\n" + s + "\n" + p.id + "\n");
        }
        public void print()
        {
            bool b = 1 > 2;
            Console.WriteLine(b);
        }
        public object whoAreYou(IMyInterface1 imi)
        {
            Console.WriteLine(imi);
            Person p = imi as Person;
            return p.Name.GetType();
        }

        public object whoAreYou(string s)
        {
            return s.GetType();
        }

        public static Person operator *(Person p1, Person p2)
        {
            return new Person(p1.id + p2.id, "hatar tenta");
        }

        public int CompareTo(object obj)
        {
            throw new Exception("not  implemented yet.");
        }
    }

    class Uppgift1
    {
        private string name = "älskar data och tenta";

        static void a()
        {
            Person p1 = new Person("1", "anna");
            Person p2 = p1;
            p2.print();
            object o = p2;
            Console.WriteLine(o.GetType() + "\n");
        }
        static void b()
        {
            Person p1 = new Person("1", "anna");
            Uppgift1 u = new Uppgift1();
            Console.WriteLine(u.Temp(p1) + "\n");
        }
        public bool Temp(IMyInterface1 imi)
        {
            Person p = imi as Person;
            Person p2 = p;
            Console.WriteLine(p.Equals(p2));
            Console.WriteLine(this);
            return this.Equals(p2);
        }

        static void c()
        {
            IMyInterface1 imi;
            Person p1 = new Person("1342", "data");
            imi = p1 as IMyInterface1;
            Console.WriteLine(imi.whoAreYou(imi) + "\n");

        }

        static bool f2()
        {
            Person p1 = new Person("1342", "anna");
            Console.WriteLine(p1.whoAreYou("eva"));
            return false;
        }


        static void d()
        {
            Person p1 = new Person("1", "anna");
            Person p2 = new Person("2", "data");
            Person p3 = p1 * p2;
            p3.print(p3);
        }

        static void e()
        {
            Car car = new Car();
            Volvo volvo = new Volvo();
            Audi audi = new Audi();

            ArrayList cars = new ArrayList();
            cars.Add(new Volvo());
            cars.Add(new Audi());

            foreach (Car c in cars)
            {
                c.talk();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("a:--");
            a();

            Console.WriteLine("b:--");
            b();

            Console.WriteLine("c:--");
            c();

            Console.WriteLine("d:--");
            d();

            Console.WriteLine("e:--");
            e();

            Console.WriteLine("--slut--");




        }

    }

}
