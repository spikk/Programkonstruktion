////MARS 2014 03 2014 MARS
using System;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using System.Threading;
namespace SYSA14PK
{
    public static class Utils
    {
        public delegate Person MyDe1egate(object x);
        public delegate void YourDelegate(object x);
        public delegate void ADelegate();
        public static void F1(object o)
        {
            Console.WriteLine("§r tentan");
        }
        public static void F2(object o)
        {
            Console.WriteLine(" svar");
        }
        public static void F3()
        {
            MethodInfo[] mi = Type.GetType("SYSA14PK.A").GetMethods();
            for (int i = 9; i < mi.Length; i++)
                Console.WriteLine(" {0} ", mi[i].Name);
        }
        public static void F4(List<Car> v)
        {
            foreach (Car c in v)
            {
                c.talk();
            }
        }
        public static void F4()
        {
            Type t = Type.GetType("SYSA14PK.Volvo");
            object utils = Activator.CreateInstance(t);
            MethodInfo mi1 = t.GetMethod("f2");
            mi1.Invoke(utils, null);
            Utils.ADelegate d1 = new Utils.ADelegate(Utils.F3);
            d1();
        }
    }// Utils
    public class A
    {
        private string name = "SYSA14";
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
        virtual public void f() { Console.WriteLine("Just a car"); }
        public void talk() { f(); }
    }
    public class Volvo : Car
    {
        override public void f()
        {
            Console.WriteLine("Jag ar bast");
        }
        public void f2()
        {
            Console.WriteLine("kompileringsfel");
        }
    }
    public class Saab : Car
    {
        override public void f()
        {
            Console.WriteLine("Jag ar b§ttre");
        }
    }

    public class Person : A, ICloneable
    {
        private string id;
        private string teacher;
        public Person() { }
        public Person(string teacher)
        {
            this.teacher = teacher;
        }
        public static Person F(object x)
        {
            return null;
        }
        public Person(string id, string name)
        {
            Name = name;
            this.id = id;
            this.teacher = " Teacher studenter";
        }
        public new bool Equals(object obj)
        {
            Person p = obj as Person;
            p.Name = this.Name;
            return base.Equals(obj);
        }
        public void Print(object o)
        {
            Console.WriteLine(o);
            bool b = this == o as Person; ;
            Console.WriteLine(b);
        }
        public void Print()
        {
            Console.WriteLine(this == null);
        }
        public void CompareTo()
        {
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(1);
                Console.WriteLine("n¤t implemented yet.");
            }
        }
        public object Clone()
        {
            return null;
        }
    } // Person

    public class Uppgiftl
    {
        private string name = "alskar data och tenta";
        static void A()
        {
            Person p1 = new Person("anna");
            Person p2 = p1.Clone() as Person;
            p1 = null;
            Console.WriteLine("{0}", Object.ReferenceEquals(p1, p2));
            p1.print(new Person());
        }
        static void B()
        {
            Person p1 = new Person("1", "anna");
            Console.WriteLine("Resultat: {0}", Temp(p1));
        }
        public static object Temp(Person p)
        {
            Console.WriteLine(p.Equals(new Person("3", "anna")));
            return p.Name.Clone();
        }
        static void C()
        {
            Person p1 = new Person("1342", "data");
            Person p = new Person();
            Utils.YourDelegate dl = new Utils.YourDelegate(Utils.F1);
            Utils.YourDelegate d2 = new Utils.YourDelegate(Utils.F2);
            Utils.YourDelegate d3 = new Utils.YourDelegate(Utils.F1);
            d3 += d2;
            d3(p1);
            d3 -= d3;
            d3(p1);
        }
        static void D()
        {
            Utils.F4();
        }
        static void E()
        {
            Person p1 = new Person();
            Person p2 = new Person();
            System.Threading.Thread t1, t2;
            t1 = new Thread(new ThreadStart(p1.CompareTo));
            t2 = new Thread(new ThreadStart(p2.Print));
            t1.Start();
            t2.Start();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("a:-—");
            A();
            Console.WriteLine("b:--");
            B();
            Console.WriteLine("c:--");
            C();
            Console.WriteLine("d:—-");
            D();
            Console.WriteLine("e:—");
            E();
            Console.WriteLine("-—slut——");
            Console.Read();
        }
    } // Uppgiftl
}// SYSA14PK


