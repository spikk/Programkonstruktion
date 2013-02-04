using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public delegate bool MyDelegate(object x, object y);

class B
{
    public delegate bool MyDelegate();
}

class A
{
    private string name = "SYSA04";

    public virtual string Name
    {
        get { return name; }
        set { name = value; }
    }

    public void print(Person p)
    {
        Console.WriteLine(p.Name);
    }

}

interface IMyInterface1
{
    object whoAreYou(IMyInterface1 imi);
}

interface IMyInterface2
{
    object whoAreYou(object str);
}

[Serializable]
class Person : A, IMyInterface1, IMyInterface2, ICloneable
{
    private string id;
    public Person() { }
    public Person(string id, string name)
    {
        Name = name;
        this.id = id;
    }

    public override string ToString()
    {
        return "Hata Data";
    }

    public override bool Equals(object obj)
    {
        return 1 > 2;
    }

    public void print()
    {
        string s = (string)Name.Clone();
        Console.WriteLine(s);
    }

    public object whoAreYou(IMyInterface1 imi)
    {
        Console.WriteLine(imi);
        return imi.GetType();
    }

    public object whoAreYou(object s)
    {
        return s.GetType();
    }

    public object Clone()
    {
        return this;
    }

}


class Uppgift1
{
    private string name = "tenta";

    static void a()
    {
        Person p = new Person("1", "anna");
        object p2 = p.Clone();
        Console.WriteLine(p2.Equals(new Person("1", "anna")) + "\n");
    }

    static void b()
    {
        Person p1 = new Person("1", "anna");
        Console.WriteLine(new Uppgift1().bTemp(p1) + "\n");
    }

    public bool bTemp(IMyInterface2 imi)
    {
        Person p = imi as Person;
        Person p2 = p;
        Console.WriteLine(p.Equals(p2));
        return p2.Equals(p2);

    }

    static void c()
    {
        IMyInterface1 imi = null;
        Person p1 = new Person("1342", "anna");
        Console.WriteLine(p1.whoAreYou(p1) + "\n");
    }

    static bool f(object a, object b)
    {
        return (Object.ReferenceEquals(a, b));
    }

    static bool f2(Person a, Person b)
    {
        return (Object.ReferenceEquals(a, b));
    }

    static bool f2()
    {
        Person p1 = new Person("1432", "anna");
        Console.WriteLine(p1.whoAreYou(p1));
        return false;
    }

    static bool f2(int i)
    {
        Person p1 = new Person("1342", "anna");
        Console.WriteLine(p1.whoAreYou("eva"));
        return true;
    }

    static void d()
    {
        MyDelegate d = new MyDelegate(f);
        Person p1 = new Person("1342", "anna");
        Person p2 = null;
        p1 = p2;
        bool b = d(p1, p2);
        Console.WriteLine(b + "\n");
    }

    static void e()
    {
        B.MyDelegate d = new B.MyDelegate(f2);
        Person p1 = new Person("1342", "anna");
        Person p2 = new Person("1342", "anna");
        p1 = p2;
        bool b = d();
        Console.WriteLine(b);
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