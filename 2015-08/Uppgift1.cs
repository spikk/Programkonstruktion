﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace _2015_08
{
    public delegate Person NiceDelegate(object x);
    public delegate void MyHandler(object source, EventArgs e);

    //////////////////////////////////////////////////////////////////////////////////////
    public class MyPublisher : List<String>
    {
        public MyHandler myHandler = null;
        public new void Add(String value)
        {
            base.Add(value);
            if (myHandler != null)
                myHandler(this, EventArgs.Empty);
        }
    }
    public class MySubscriber
    {
        private string teacher = "hata data och älskar dataspel";
        public MySubscriber() { }
        public MySubscriber(MyPublisher myList)
        {
            myList.myHandler += new MyHandler(NothingHappened);
        }
        public void NothingHappened(object source, EventArgs e)
        {
            List<string> list = source as List<string>;
            foreach (string s in list)
            {
                Console.WriteLine("hata " + s + " och " + teacher);
            }
        }
    } //Subscriber

    //////////////////////////////////////////////////////////////////////////////////////
    public static class Utils
    {
        public delegate Person MyDelegate(object x);
        public delegate void YourDelegate(object x);
        public delegate void ADelegate();
        public static void F1(object o)
        {
            Console.WriteLine("you are here, correct!\n");
            F3("SYSA14PK.MySubscriber");

        }
        public static void F2(object o)
        {
            Console.WriteLine("Are you sure ?\n");
            F3("SYSA14PK.NiceDelegate");
        }
        public static void F3(string s)
        {
            MethodInfo[] mi = Type.GetType(s).GetMethods();
            for (int i = 0; i < mi.Length; i++)
            {
                Console.WriteLine(" {0} ", mi[i].Name);
            }
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
            Utils.ADelegate d1 = new Utils.ADelegate(Utils.F4);
            Thread.Sleep(100);
            //d1();
        }
    }// Utils

    //////////////////////////////////////////////////////////////////////////////////////
    public class A
    {
        public static string name;
        private string address = "SYSA14PK";
        static A()
        {
            name = "SYSA14";
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string Name
        {

        get { return name; }
            set { name = value; }
        }
        public void print(object person)
        {
            Person p = person as Person;
            Console.WriteLine((p.Address.Substring(0, 3)).CompareTo(p.Address));
        }
    } //A

    //////////////////////////////////////////////////////////////////////////////////////
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
            Address = name;
            this.id = id;
            this.teacher = " Teacher studenter";
        }
        public new bool Equals(object obj)
        {
            Person p = obj as Person;
            p.Name = (this.Name);
            return this.Name == p.Name;
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
            string s1 = "Anna";
            string s2 = "Anna";
            for (int i = 0; i < 3; i++)

            {
                Thread.Sleep(1);
                Console.WriteLine(" {0}", s1.CompareTo(s2));
            }
        }
        public object Clone()
        {
            //return new List<string>(); //Den här ska va avkommenterad
            return new Person();
        }
    } // Person

    //////////////////////////////////////////////////////////////////////////////////////
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
    } // Car
    public class Volvo : Car
    {
        override public void f()
        {
            Console.WriteLine("Jag är bäst");
        }
        public void f2()
        {
            Utils.F3("SYSA14PK.Volvo");
        }
    } //Volvo
    public class Saab : Car
    {
        override public void f()
        {
            Console.WriteLine("Jag är bättre");
        }
    }//Saab

    //////////////////////////////////////////////////////////////////////////////////////


    public class Uppgift1
    {
        public string name = " hatar data och tenta";
        public static object Temp(ref Person[] pA)
        {
            foreach (Person person in pA)
            {
                // person.Name = Uppgift1.name;
                Console.WriteLine(person.Name);
            }
            pA = new Person[2];
            pA[0] = new Person("1", "Fatso");
            pA[1] = new Person("2", "Gertrud");
            return null;
        }
        static void A()
        {
            Person p1 = new Person("anna");
            Person p2 = p1.Clone() as Person;
            if (p2 == null)
                Console.WriteLine("Same object:{0} Name:{1} ",
                Object.ReferenceEquals(p1, p2), p2.Name); //System.NullReferenceException för Clone returnerar en List
            else
                Console.WriteLine("Ain't my type man!");
        }
        static void B()
        {
            Person p1 = new Person("1", "anna");
            Person p2 = new Person("2", "anna");
            Person[] pA = new Person[] { new Person("1", "anna"), new Person("2", "anna") };

            Console.WriteLine("Resultat: " + p2);
            Temp(ref pA);
            foreach (Person person in pA)
            {
                Console.WriteLine(person.Address);
            }
        }
        static void C()
        {
            Person p1 = new Person("1342", "data");
            Utils.YourDelegate d1 = new Utils.YourDelegate(Utils.F1);
            Delegate[] dList = d1.GetInvocationList();
            for (int i = 0; i < 1; i++)
            {
                d1 = dList[i] as Utils.YourDelegate;
                d1(p1);
            }
        }

        static void D()
        {
            List<Car> cars = new List<Car>();
            cars.Add(new Volvo());
            cars.Add(new Saab());
            Utils.F4();
        }
        static void E()
        {
            Person p1 = new Person();
            Person p2 = new Person();
            Thread[] tA = { new Thread(new ThreadStart(p1.CompareTo)),
 new Thread(new ThreadStart(p2.Print)) };
            for (int i = 0; i < 2; i++)
            {
                tA[i] = null;
                E();
            }
        }
        static void F()
        {
            MyPublisher mP = new MyPublisher();
            MySubscriber listener1 = new MySubscriber(mP);
            MySubscriber listener2 = new MySubscriber(mP);
            for (int i = 0; i < 1; i++)
                mP.Add("mats");
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
            Console.WriteLine("f:-");
            F();
            Console.WriteLine("--slut--");
            Console.Read();
        }
    } // Uppgift1
} // SYSA14PK