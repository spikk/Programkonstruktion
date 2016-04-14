// augusti 2012


using System;
using System.Collections.Generic;
using System.Reflection;
using System.Collections;

namespace SYSA14PK
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
        public new void f()
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
    } //A


    class Person : A, IMyInterface1, IMyInterface2, IComparable
    {
        private string id;
        private string teacher;
        public Person() { }
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
            s = p.Name;

            s = s + teacher.Insert(8, " älskar sina");
            Console.WriteLine("Result =" + "\n" + s + "\n" + p.id + "\n");


        }


        public void print()
        {
            bool b = this == null; ;
            Console.WriteLine(b);
        }

        public object whoAreYou(IMyInterface1 imi)
        {

            Console.WriteLine(imi);
            if (imi is Person)
                return imi.Name.GetType();
            else
                return null;
        }


        public object whoAreYou(string s)
        {
            return s.GetType();
        }


        public static Person operator *(Person p1, Person p2)
        {
            return new Person(p1.id + p2.Name, p1.Name);
        }


        public int CompareTo(object obj)
        {
            throw new Exception("not implemented yet.");
        }
    } ////Person




    class Uppgift1
    {
        private string name = "hatar data och tenta";

        static void A()
        {
            Person p1 = new Person("1", "anna");
            p1.print();
            object o = p1;
            A a = new A();
            a = p1;
            Console.WriteLine(a.GetType() + "\n");


        }



        static void B()
        {
            Person p1 = new Person("1", "anna");
            Uppgift1 u = new Uppgift1();
            Console.WriteLine(u.Temp(p1) + "\n");

        }


        public bool Temp(IMyInterface1 imi)
        {
            Person p = imi as Person;
            Person p2 = p;
            Console.WriteLine(p.Equals(this));
            return p.Equals(p2);
        }



        static void C()
        {
            Person p1 = new Person("1342", "data");
            IMyInterface1 imi = p1 as IMyInterface1;
            Console.WriteLine(imi.whoAreYou(imi) + "\n");


        }

        static bool f2()
        {
            Person p1 = new Person("1342", "anna");
            Console.WriteLine(p1.whoAreYou("eva"));
            return false;

        }



        static void D()
        {

            Person p1 = new Person("1", "anna");
            Person p2 = new Person("2", "data");
            Person p3 = p1 * p2;
            p3.print(p3);



        }
        
        static void E()
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
            A();
            Console.WriteLine("b:--");
            B();
            Console.WriteLine("c:--");
            C();
            Console.WriteLine("d:--");
            D();
            Console.WriteLine("e:-");
            E();
            Console.WriteLine("--slut--");
            Console.Read();
        }
    } // Uppgift1







}










