/// 2013 FEB
using System;
using System.Collections.Generic;
using System.Collections;

namespace SYSA14PK
{
    public class Temp
    {
        public delegate Person MyDelegate(object x);
    }
    public abstract class Vehicle
    {
        private string name = " a Vehicle";
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
    public abstract class Car : Vehicle
    {
        virtual public void f() { Console.WriteLine("3ust a car"); }
        public void talk() { f(); }
    }
    public class Volvo : Car
    {
        override public void f()
        {
            Console.WriteLine("3ag ar bast" + Name);
        }
    }
    public class Saab : Car
    {
        override public void f()
        {
            Console.WriteLine("Jag ar battre");

        }
    }
    public interface IMyInterface1
    {
        object whoAreYou(IMyInterface1 imi);
    }
    public interface IMyInterface2
    {
        object whoAreYou(string str);
    }


    public class A
    {
        private string name = "5YSA14";
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
    public class Person : A, IMyInterface1, IMyInterface2, IComparable, ICloneable
    {
        private string id;
        private string teacher;
        public Person() { }
        public Person(string teacher)
        {
            this.teacher = teacher;
        }
        public static Person f(object x)
        {
            return new Person("Informatik");
        }
        public Person(string id, string name)
        {
            Name = name;
            this.id = id;
            this.teacher = " Teacher studenter";
        }
        public override bool Equals(Object obj)
        {
            return 1 > 2;
        }
        public new void print(Person p)
        {
            string s = "Mina studenter ";
            string s2 = null;
            s = p.teacher;
            s2 = s + ' ' + Name;
            Console.WriteLine("Result =" + "\n" + s2 + "\n" + p.id + "\n");
        }
        public void print(object o)
        {
            bool b = this == o as Person; ;
            Console.WriteLine(b);
        }

        public object whoAreYou(IMyInterface1 imi)
        {
            Console.WriteLine(imi.Equals(imi));
            if (imi is Person)
                return imi as IMyInterface1;
            else
                return imi as Person;
        }
        public object whoAreYou(string s)
        {
            return s.GetType();
        }
        public static Person operator *(Person pl, Person p2)
        {
            Temp t = new Temp();
            Temp.MyDelegate d = new Temp.MyDelegate(f);
            Person p = d(new Person());
            return p;
        }
        public int CompareTo(object obj)
        {
            throw new Exception("not implemented yet.");
        }
        public object Clone()
        {
            return new Person();
        }
    } // Person
    class Uppgift1
    {
        private string name = "alskar data och tenta";
        static void A()
        {
            Person p1 = new Person("anna");
            object o = p1;
            p1.print(o);
            Person p2 = p1.Clone() as Person;
            A a = new A();
            Console.WriteLine("{0}", p1 == p2);
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
            return object.ReferenceEquals(p2, p);
        }
        static void C()
        {
            Person p1 = new Person("1342", "data");
            IMyInterface1 imi = p1 as IMyInterface1;
            Console.WriteLine(imi.whoAreYou(imi) + "\n");
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
            Volvo volvo = new Volvo();
            Saab audi = new Saab();
            List<Car> cars = new List<Car>();
            cars.Add(new Volvo());
            cars.Add(new Saab());
            foreach (Car c in cars)
            {
                c.talk();
            }
            List<Car> vl = new List<Car>();
            vl.Add(new Car());
        }
        static void Main(string[] args)
        {
            Console.WriteLine("a:——");
            A();
            Console.WriteLine("b: ——");
            B();
            Console.WriteLine("c:-—");
            C();
            Console.WriteLine("d:——");
            D();
            Console.WriteLine("e:—");
            E();
            Console.WriteLine("--slut——");
            Console.Read();
        }
    } // Up¤gi¥t1
}// svsaiapx