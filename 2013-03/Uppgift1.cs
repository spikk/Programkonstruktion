/// MARS 2013
using System;
using System.Collections.Generic;
using System.Collections;
namespace SYSAl4PK
{
    public class Temp
    {
        public delegate string MyDelegate(object x, bool b);
    }
    interface IVehicle
    {
        string Name
        {
            get;
            set;
        }
    }
    public abstract class Car : IVehicle
    {
        private string name = " a Vehicle";
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        virtual public void f() { Console.WriteLine(Name); }
        public void talk()
        {
            f();
        }
    }
    public class Volvo : Car
    {
        public Volvo(string name)
        {
            Name = name;
        }
        override public void f()
        {
            Console.WriteLine("Jag ar bast" + Name);
        }
    }
    public class Saab : Car
    {
        override public void f()
        {
            Console.WriteLine("Jag ar battre");
        }
    }
    public interface IMyInterfacel
    {
        object whoAreYou(IMyInterfacel imi);
    }
    public interface IMyInterface2
    {
        object whoAreYou(string str);
    }

    public class A
    {
        private string name = "SYSAI4";
        private ArrayList a = new ArrayList();
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public void Print(Person p)
        {
            Console.WriteLine(p.Name);
        }
    }
    public class Person : A, IMyInterfacel, IMyInterface2, IComparable, ICloneable
    {
        private string id;
        private string teacher;
        private string test = null;
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
        public new bool Equals(object obj)
        {
            return this == null;
        }
        public new void Print(Person p)
        {
            string s = "Mina studenter";
            string s2 = null;
            s = p.teacher;
            s2 += s;
            Console.WriteLine("Result =" + "\n" + s2 + "\n" + p.id + "\n");
        }
        public void Print(object o)
        {
            bool b = this == o as Person; ;
            Console.WriteLine(b);
        }
        public object whoAreYou(IMyInterfacel imi)
        {
            Console.WriteLine(imi.GetType());
            if (imi is Person)
                return imi as IMyInterfacel;
            else
                return imi as Person;
        }

        public object whoAreYou(string s)
        {
            return s.GetType();
        }
        public string f(object o, bool c)
        {
            test += "Kursen ar";
            return "Tenta trakigt";

        }
        public static Person operator *(Person pl, Person p2)
        {
            Temp t = new Temp();
            Person p = new Person("mats");
            Temp.MyDelegate d1 = new Temp.MyDelegate(p.f);
            Temp.MyDelegate d2 = new Temp.MyDelegate(p.f);
            d1 += d2;
            string s = d1(null, true);
            Console.WriteLine(new Person().test);
            p.Name = s;
            return p;
        }
        public int CompareTo(object obj)
        {
            throw new Exception("not implemented yet.");
        }
        public object Clone()
        {
            return null;
        }
        public object Klone()
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
            object o = p1.Clone() as Person; ;
            p1.Print(o);
            Person p2 = p1.Klone() as Person;
            Console.WriteLine("{O}", p1 == p2);
        }
        static void B()
        {
            Person p1 = new Person("l", "anna");
            Uppgift1 u = new Uppgift1();
            Console.WriteLine(Temp(p1) + "\n");
        }
        public static int Temp(object imi)
        {
            Person p = imi as Person;
            Person p2 = p;
            Console.WriteLine(p.Name.Equals(p2.Name));
            return p.Name.CompareTo(" ");
        }

        static void C()
        {
            Person p1 = new Person("l342", "data");
            IMyInterfacel imi = p1 as IMyInterfacel;
            Console.WriteLine(imi.whoAreYou(imi) + "\n");
        }
        static void D()
        {

            Person p1 = new Person("l", "anna");
            Person p2 = new Person("2", "data");
            Person p3 = p1 * p2;
            p3.Print(p3);
        }
        static void E()
        {
            Volvo volvo = new Volvo(" fin bil");
            Saab saab = new Saab();
            List<Car> cars = new List<Car>();
            cars.Add(volvo);
            cars.Add(saab);
            foreach (Car c in cars)
            {

                c.talk();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("a:——");
            A();
            Console.WriteLine("b:——");
            B();
            Console.WriteLine("c:——");
            C();
            Console.WriteLine("d:--");
            D();
            Console.WriteLine("e:-");
            E();
            Console.WriteLine("—~slut——");
            Console.Read();
        }
    } // Uppgiftl
}// sYsA14pK



