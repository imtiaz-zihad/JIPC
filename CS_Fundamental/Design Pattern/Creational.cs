// -----------Creational Design Pattern-----------

// 1.Singleton Pattern → Ensures only one object of a class exists and provides global access.
public class Singleton
{
    private static Singleton _instance;

    private Singleton() { }

    public static Singleton GetInstance()
    {
        if(_instance == null)
        {
            _instance = new Singleton();
        }
        return _instance;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var singleton1 = Singleton.GetInstance();
        var singleton2 = Singleton.GetInstance();

        Console.WriteLine(singleton1 == singleton2); // Output: True
    }
}


/*
 2.Builder Pattern → Separates object construction from its representation.

  Usecase: Complex object creation , UI Form Builder , API Request Builder, Configuration Object Builder, Test Data Builder, Fluent Interface Builder.
  Advantages: Separation of concerns, Improved readability, Flexibility, Reusability, Encapsulation.
  Disadvantages: Increased complexity, Overhead, Learning curve, Not suitable for simple objects.
*/

public class Computer
{
    public string CPU { get; set; }
    public string RAM { get; set; }
    public string Storage { get; set; }
    public string GPU { get; set; }

    public void Show()
    {
        Console.WriteLine($"CPU: {CPU}, RAM: {RAM}, Storage: {Storage}, GPU: {GPU}");
    }
}

public interface IComputerBuilder
{
    void BuildCPU();
    void BuildRAM();
    void BuildStorage();
    void BuildGPU();
    Computer GetComputer();
}

public class GamingComputerBuilder : IComputerBuilder
{
    private Computer _computer = new Computer();

    public void BuildCPU()
    {
        _computer.CPU = "Intel Core i9";
    }

    public void BuildRAM()
    {
        _computer.RAM = "32GB DDR4";
    }

    public void BuildStorage()
    {
        _computer.Storage = "1TB NVMe SSD";
    }

    public void BuildGPU()
    {
        _computer.GPU = "NVIDIA GeForce RTX 3080";
    }

    public Computer GetComputer()
    {
        return _computer;
    }
}

class User
{
    public void BuildComputer(IComputerBuilder builder)
    {
        builder.BuildCPU();
        builder.BuildRAM();
        builder.BuildStorage();
        builder.BuildGPU();
    }
}

class Program
{
    static void Main(string[] args)
    {
        User user = new User();

        IComputerBuilder builder = new GamingComputerBuilder();

        user.BuildComputer(builder);

        Computer gamingComputer = builder.GetComputer();

        gamingComputer.Show();
    }
}


/*
 3.Factory Method Pattern → Creates objects without specifying the exact class.

  Usecase: Object creation with common interface, Plugin architecture, Database connection factory, Logger factory, Notification system.
  Advantages: Encapsulation, Flexibility, Reusability, Separation of concerns, Testability.
  Disadvantages: Increased complexity, Overhead, Learning curve, Not suitable for simple object creation.
*/

public interface INotification
{
    void Send(string message);
}

public class EmailNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Email sent: {message}");
    }
}

public class SMSNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"SMS sent: {message}");
    }
}
public class NotificationFactory
{
    public static INotification CreateNotification(string type)
    {
        return type switch
        {
            "Email" => new EmailNotification(),
            "SMS" => new SMSNotification(),
            _ => throw new ArgumentException("Invalid notification type")
        };   
    }
}

class Program
{
    static void Main(string[] args)
    {
        INotification notification = NotificationFactory.CreateNotification("Email");
        notification.Send("Hello, this is a factory method pattern example!");
        notification = NotificationFactory.CreateNotification("SMS");
        notification.Send("Hello, this is a factory method pattern example!");
    }
}

 
 