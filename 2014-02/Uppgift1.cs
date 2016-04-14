
using System;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
namespace SYSA14PK
{
    public static class Utils
    {
        public delegate Person MyDe1egate(object x);
        public delegate void YourDelegate(object x);
        public static void f1(object o)
        {
            Console.Write("§r tentan");
        }
        public static void f2(object o)
        {
            Console.WriteLine(" svér");
        }
        public static void f3()
        {
            MethodInfo[] mi = Type.GetType("SYSA14PK.Utils").GetMethods();
            for (int i = 9; i < mi.Length; i++)
                Console.WriteLine(" {6} ", mi[i].Name);
        }
        public static void f4(List<Car> v)
        {
            foreach (Car c in v)
            {
                c.talk();
            }
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
        virtual public void f() { Console.WriteLine("just a car"); }
        public void talk() { f(); }
    }

    public class Volvo : Car
    {
        override public void f()
        {
            Console.WriteLine("3ag ar bast");
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
        public override bool Equals(object obj)
        {
            Person p = obj as Person;
            return p.Name == this.Name;
        }
        public void print(object o)
        {
            Console.WriteLine(o);
            bool b = this == o as Person; ;
            Console.WriteLine(b);
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

    public class Uppgiftl
    {
        private string name = "Älskar data och tenta";
        static void A()
        {
            Person p1 = new Person("anna");
            Person p2 = p1.Clone() as Person;
            Console.WriteLine("{0}", p1 == p2);
            object o = p2;
            p1.print(0);
        }
        static void B()
        {
            Person p1 = new Person("1", "anna");
            Console.WriteLine(Temp(p1) + "\n");
        }
        public static bool Temp(Person imi)
        {
            Person p2 = imi;
            Console.WriteLine(imi.Equals(new Person("3", "anna")));
            return object.ReferenceEquals(p2, imi);
        }
        static void C()
        {
            Person p1 = new Person("1342", "data");
            IMyInterface1 imi = p1 as IMyInterface1;
            Person p = new Person();
            Utils.YourDelegate d1 = new Utils.YourDelegate(Utils.f1);
            Utils.YourDelegate d2 = new Utils.YourDelegate(Utils.f2);
            Utils.YourDelegate d3 = new Utils.YourDelegate(Utils.f1);
            d3 = d1 + d2;
            d3(p1);
        }
        static void D()
        {
            Utils.f3();
        }
        static void E()
        {
            Volvo volvo = new Volvo();
            Saab saab = new Saab();
            List<Car> cars = new List<Car>(); ;
            cars.Add(volvo);
            cars.Add(saab);
            Utils.f4(cars);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("a:——");
            A();
            Console.WriteLine("b:——");
            B();
            Console.WriteLine("c:——");
            C();
            Console.WriteLine("d: -—");
            D();
            Console.WriteLine("e:—");
            E();
            Console.WriteLine("—-slut--");
            Console.Read();
        }
    } // Uppgitti
}// svsA14m<


