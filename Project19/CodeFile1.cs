using System;
class Program
{
    static void Main(string[] args)
    {
        //Factory
        Guest g1 = new Guest(10, "guest10");
        g1.Create();
        LoggedUser l1 = new LoggedUser(11, "user007");
        l1.Create();
        Moderator m1 = new Moderator(12, "mod01");
        m1.Create();
        Admin a1 = new Admin(13, "adminushka2345");
        a1.Create();
        //Singleton
        SuperUser su1 = new SuperUser(14, "owner0987");
        su1.Create();
        //Facade
        Facade facade1 = new Facade(new Article(), new Commentary());
        facade1.Operation1();
        facade1.Operation2();
        //Command
        Commentary cmntr1 = new Commentary();
        Article artcl = new Article();
        su1.SetCommand(new ArticleOnCommand(artcl));
        su1.DoSomething();
        su1.UndoSomething();
        su1.SetCommand(new CommentaryOnCommand(cmntr1));
        su1.DoSomething();
        su1.UndoSomething();
        //Mediator
        ManagerMediator mediator = new ManagerMediator();
        SystemUser customer = new CustomerSystemUser(mediator);
        SystemUser moder = new ModeratingSystemUser(mediator);
        mediator.Customer = customer;
        mediator.Moder = moder;
        customer.Send("Please, add article on this topic...");
        moder.Send("Okay, here it is...");

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
    public void WriteArticle()
    {
        Console.WriteLine("Article is written :)");

    }
    public void DeleteArticle()
    {
        Console.WriteLine("Article is deleted :(");

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
    public void WriteCommentary()
    {
        Console.WriteLine("Commentary is written :)");

    }
    public void DeleteCommentary()
    {
        Console.WriteLine("Commentary is deleted :(");

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

interface ICommand
{
    void Execute();
    void Undo();
}

class CommentaryOnCommand : ICommand
{
    Commentary cm;
    public CommentaryOnCommand(Commentary cmSet)
    {
        cm = cmSet;
    }
    public void Execute()
    {
        cm.WriteCommentary();
    }
    public void Undo()
    {
        cm.DeleteCommentary();
    }
}

class ArticleOnCommand : ICommand
{
    Article artcl;
    public ArticleOnCommand(Article artclSet)
    {
        artcl = artclSet;
    }
    public void Execute()
    {
        artcl.WriteArticle();
    }
    public void Undo()
    {
        artcl.DeleteArticle();
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

    ICommand command;
    public void SetCommand(ICommand com)
    {
        command = com;
    }
    public void DoSomething()
    {
        command.Execute();
    }
    public void UndoSomething()
    {
        command.Undo();
    }

}




abstract class Mediator
{
    public abstract void Send(string msg, SystemUser colleague);
}
abstract class SystemUser
{
    protected Mediator mediator;

    public SystemUser(Mediator mediator)
    {
        this.mediator = mediator;
    }

    public virtual void Send(string message)
    {
        mediator.Send(message, this);
    }
    public abstract void Notify(string message);
}
//Customer
class CustomerSystemUser : SystemUser
{
    public CustomerSystemUser(Mediator mediator)
        : base(mediator)
    { }

    public override void Notify(string message)
    {
        Console.WriteLine("Message to customers: " + message);
    }
}
// Moder
class ModeratingSystemUser : SystemUser
{
    public ModeratingSystemUser(Mediator mediator)
        : base(mediator)
    { }

    public override void Notify(string message)
    {
        Console.WriteLine("Message to moderators: " + message);
    }
}


class ManagerMediator : Mediator
{
    public SystemUser Customer { get; set; }
    public SystemUser Moder { get; set; }
    public override void Send(string msg, SystemUser sysuser)
    {
        if (Customer == sysuser)
            Moder.Notify(msg);
        else if (Moder == sysuser)
            Customer.Notify(msg);
    }
}