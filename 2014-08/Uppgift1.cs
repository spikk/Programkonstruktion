using System;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using System.Threading;
namespace SYSA14PK
{
    public static class Utils
    {
        public delegate Person MyDelegate(object x);
        public delegate void YourDelegate(object x);
        public delegate void ADelegate();
        public static void F1(object o)
        {
            Console.WriteLine("är tentan");
        }
        public static void F2(object o)
        {
            Console.WriteLine(" svår");
        }
        public static void F3()
        {
            MethodInfo[] mi = Type.GetType("SYSA14PK.A").GetMethods();
            for (int i = 0; i < mi.Length; i++)
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
            MethodInfo mi1 = t.GetMethod("f");
            mi1.Invoke(utils, null);
            Utils.ADelegate d1 = new Utils.ADelegate(Utils.F3);
            d1 -= d1;
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
            Console.WriteLine("Jag är bäst");
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
            Console.WriteLine("Jag är bättre");
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
        public static Person f(object x)
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
            return this.Equals(obj);
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
                Thread.Sleep(1000);
                Console.WriteLine("not implemented yet.");
            }
        }
        public object Clone()
        {
            return null;
        }
    } // 
    public class Uppgift1
    {
        private string name = "älskar data och tenta";
        static void A()
        {
            Person p1 = new Person("anna");
            Person p2 = p1.Clone() as Person;
            p1 = null;
            Console.WriteLine("{0}", p1.GetType());
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
            return p.Name;
        }
        static void C()
        {
            Person p1 = new Person("1342", "data");
            Person p = new Person();
            Utils.YourDelegate d1 = new Utils.YourDelegate(Utils.F1);
            Utils.YourDelegate d2 = new Utils.YourDelegate(Utils.F2);
            Utils.YourDelegate d3 = new Utils.YourDelegate(Utils.F1);
            d3 += d3;
            d3(p1);
            d3(Temp);
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
            t1.Abort();
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
}// SYSA14PK