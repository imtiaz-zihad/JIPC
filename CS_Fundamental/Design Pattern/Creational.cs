// -----------Creational Design Pattern-----------

// 1.Singleton Pattern → Ensures only one object of a class exists and provides global access.
public class Singleton
{
    private static Singleton _instance;

    private Singleton() { }

    public static Singleton GetInstance()
    {
        if (_instance == null)
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

/*
4.Abstract Factory Pattern → Creates families of related objects without defining concrete classes.

Usecase: Cross-platform UI toolkit, Database access layer, Theme factory, Vehicle factory, Furniture factory.
Advantages: Encapsulation, Flexibility, Reusability, Separation of concerns, Testability.
Disadvantages: Increased complexity, Overhead, Learning curve, Not suitable for simple object creation.
*/

public interface IFactory
{
    IButton CreateButton();
    ICheckbox CreateCheckbox();
}

public interface IButton
{
    void Render();
}

public interface ICheckbox
{
    void Check();
}

public class windowsButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Rendering Windows Button");
    }
}
public class macButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Rendering Mac Button");
    }
}

public class windowsCheckbox : ICheckbox
{
    public void Check()
    {
        Console.WriteLine("Check Windows Checkbox");
    }
}
public class macCheckbox : ICheckbox
{
    public void Check()
    {
        Console.WriteLine("Check Mac Checkbox");
    }
}


public class WindowsFactory : IFactory
{
    public IButton CreateButton() =>  new windowsButton();
    public ICheckbox CreateCheckbox() => new windowsCheckbox();
}

public class MacFactory : IFactory
{
    public IButton CreateButton() => new macButton();
    public ICheckbox CreateCheckbox() => new macCheckbox();
}


public class Program
{
    static void Main(string[] args)
    {
        IFactory factory = new WindowsFactory();
        IButton button = factory.CreateButton();
        ICheckbox checkbox = factory.CreateCheckbox();

        button.Render();
        checkbox.Check();

        factory = new MacFactory();
        button = factory.CreateButton();
        checkbox = factory.CreateCheckbox();

        button.Render();
        checkbox.Check();
    }
}

/*
5.Prototype Pattern → Creates new objects by copying existing ones.

Usecase: Object cloning, Performance optimization, Object configuration, Test data generation, Complex object creation.
Advantages: Performance, Flexibility, Reusability, Separation of concerns, Testability.
Disadvantages: Increased complexity, Overhead, Learning curve, Not suitable for simple object creation.


*/
public abstract class Shape
{
    public string Color { get; set; }
    public abstract Shape Clone();
}

public class Circle : Shape
{
    public int Radius { get; set; }

    public override Shape Clone()
    {
        return (Shape)this.MemberwiseClone();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Circle originalCircle = new Circle { Color = "Red", Radius = 5 };
        Circle clonedCircle = (Circle)originalCircle.Clone();

        Console.WriteLine($"Original Circle: Color={originalCircle.Color}, Radius={originalCircle.Radius}");
        Console.WriteLine($"Cloned Circle: Color={clonedCircle.Color}, Radius={clonedCircle.Radius}");
    }
}

