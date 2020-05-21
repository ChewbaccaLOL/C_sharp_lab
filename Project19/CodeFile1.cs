using System;
class Program
{
    static void Main(string[] args)
    {
        Guest g1 = new Guest(10, "guest10");
        g1.Create();
        LoggedUser l1 = new LoggedUser(11, "user007");
        l1.Create();
        Moderator m1 = new Moderator(12, "mod01");
        m1.Create();
        Admin a1 = new Admin(13, "adminushka2345");
        a1.Create();
        SuperUser su1 = new SuperUser(14, "owner0987");
        su1.Create();

        Facade facade1 = new Facade(new Article(), new Commentary());
        facade1.Operation1();
        facade1.Operation2();
        Console.ReadLine();
    }
}


abstract class Person
{
    public int Id { get; set; }
    public string Login { get; set; }
    public Person (int id, string l)
    {
        Id = id;
        Login = l;
    }
    abstract public Post Create();
    
}

class VisitingUser : Person
{
    public VisitingUser(int id, string l) : base(id, l)
    {

    }
    public override Post Create()
    {
        return new Commentary();
    }
}

class ModeratingUser : Person
{
    public ModeratingUser(int id, string l) : base(id, l)
    {

    }
    public override Post Create()
    {
        return new Article();
    }
}

class Guest : VisitingUser
{
    public Guest(int id, string l) : base(id, l)
    {

    }
    public override Post Create()
    {
        Console.WriteLine($"Guest {Login} wrote something...");
        return new Commentary();
    }
}

class LoggedUser : VisitingUser
{
    public LoggedUser(int id, string l) : base(id, l)
    {

    }
    public override Post Create()
    {
        Console.WriteLine($"Logged user {Login} wrote something...");
        return new Commentary();
    }
}

class Moderator : ModeratingUser
{
    public Moderator(int id, string l) : base(id, l)
    {

    }
    public override Post Create()
    {
        Console.WriteLine($"Moderator {Login} wrote something...");
        return new Article();
    }
}

class Admin : ModeratingUser
{
    public Admin(int id, string l) : base(id, l)
    {

    }
    public override Post Create()
    {
        Console.WriteLine($"Administrator {Login} wrote something...");
        return new Article();
    }
}


abstract public class Post
{

}

public class Article : Post
{
    public Article()
    {
        Console.WriteLine("Article creatrd!");
    }
    public void SomeAction()
    {
        Console.WriteLine("Something happened to Article...");
    }
}

public class Commentary : Post
{
    public Commentary()
    {
        Console.WriteLine("Commentary creatrd!");
    }
    public void SomeAction()
    {
        Console.WriteLine("Something happened to Commentary...");
    }
}

public class Facade
{
    Article a1;
    Commentary c1;
    public Facade(Article a, Commentary c)
    {
        a1 = a;
        c1 = c;
    }
    public void Operation1()
    {
        a1.SomeAction();
        c1.SomeAction();
    }
    public void Operation2()
    {
        c1.SomeAction();
    }
}

class SuperUser : Admin
{
    private static SuperUser instance;

    public SuperUser(int id, string l) : base(id, l)
    {

    }

    public static SuperUser getInstance(int id1, string l1)
    {
        if (instance == null)
            instance = new SuperUser(id1, l1);
        return instance;
    }

    public override Post Create()
    {
        Console.WriteLine($"Super user {Login} wrote something...");
        return new Article();
    }
}



