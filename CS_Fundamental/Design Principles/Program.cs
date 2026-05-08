/*
Design Principle is a fundamental concept in software development that guides developers in writing clean, maintainable, and efficient code. These principles help in creating software that is easy to understand, modify, and extend over time.

Design principle use for : 
1. Code Maintainability 
2. Readability 
3. Reusability 
4. Scalability 
5. Reduce Bug
6. Team Collaboration
*/

// =========== DRY =================// 
//DRY - Don't Repeat Yourself(It means avoid code duplication by creating reusable functions or methods)


// Bad Code Example -> Violation of DRY Principle 
public class BadManager
{
    public void PrintAdmin()
    {
        Console.WriteLine("Name: Imtiaz");
        Console.WriteLine("Email: imtiaz@example.com");
        Console.WriteLine("Role: Admin");
    }

    public void PrintUser()
    {
        Console.WriteLine("Name: John Doe");
        Console.WriteLine("Email: john@example.com");
        Console.WriteLine("Role: User");
    }
}

// Good Code Example -> Adherence to DRY Principle
public class GoodManager
{
    public void PrintUserInfo(string name, string email, string role)
    {
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Email: {email}");
        Console.WriteLine($"Role: {role}");
    }
}


// =========== KISS =================// 

// KISS - Keep It Simple, Stupid(It means write simple and clear code instead of complex logic)


// Bad Code Example -> Violation of KISS Principle
public class BadKiss
{
    public bool IsEven(int n)
    {
        if (n % 2 == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

// Good Code Example -> Adherence to KISS Principle
public class GoodKiss
{
    public bool IsEven(int n)
    {
        return n % 2 == 0;
    }
}

// =========== YAGNI =================// 


// YAGNI - You Aren't Gonna Need It(It means don't add functionality until it is necessary)


// Bad Code Example -> Violation of YAGNI Principle
public class BadOrderService
{
    public void PlaceOrder() { }

    public void CancelOrder() { }

    public void FutureAIRecommendation() { } // Not needed ❌
}

// Good Code Example -> Adherence to YAGNI Principle
public class OrderService
{
    public void PlaceOrder() { }

    public void CancelOrder() { }
}

//=================== SOLID Principles  ======================//

/* SOLID is a set of 5 object-oriented design principles that help developers create maintainable and scalable software. It mainly helps 
1) improve code maintainability, 
2) enhance readability, 
3) promote reusability, 
4) reduce bugs. 

The SOLID principles are:
S= Single Responsibility Principle(SRP)
O= Open/Closed Principle(OCP)
L= Liskov Substitution Principle(LSP)
I= Interface Segregation Principle(ISP)
D= Dependency Inversion Principle(DIP)

*/


// S - Single Responsibility Principle (SRP) -> A class should have only one responsibility or reason to change.

// Bad Example ❌
public class Report
{
    public void GenerateReport() { }

    public void PrintReport() { }

    public void SaveToFile() { }
}

// Good Example ✅
public class ReportGenerator
{
    public void GenerateReport() { }
}

public class ReportPrinter
{
    public void PrintReport() { }
}

public class ReportSaver
{
    public void SaveToFile() { }
}


// O - Open/Closed Principle (OCP) -> Software should be open for extension but closed for modification.It is use for multiple behavior without changing existing code.
/*
Advantages:
1. Flexibility: New features can be added without modifying existing code.
2. Maintainability: Existing code remains stable and easier to maintain since it is not altered.
3. Scalability: The system can grow and evolve without requiring significant changes to existing code.

*/

// Bad Example ❌
public class Discount
{
    public double GetDiscount(string type)
    {
        if (type == "Student") return 15;
        else if (type == "Regular") return 5;
        return 0;
    }
}

// Good Example ✅
public abstract class DiscountBase
{
    public abstract double GetDiscount();
}

public class StudentDiscount : DiscountBase
{
    public override double GetDiscount() => 15;
}

public class RegularDiscount : DiscountBase
{
    public override double GetDiscount() => 5;
}



// L - Liskov Substitution Principle (LSP) -> Subtypes must be substitutable for their base types without altering the correctness of the program.

// Bad Example ❌
public class Bird
{
    public virtual void Fly() { }
}

public class Ostrich : Bird
{
    public override void Fly()
    {
        throw new Exception("Ostrich can't fly"); // ❌ violation
    }
}

// Good Example ✅
public class BirdBase { }

public class FlyingBird : BirdBase
{
    public virtual void Fly() { }
}

public class Sparrow : FlyingBird
{
    public override void Fly() { }
}

public class OstrichFixed : BirdBase
{
    // no Fly method
}


// I - Interface Segregation Principle (ISP) -> Clients should not be forced to depend on interfaces they do not use. It is use for creating specific interfaces for different clients instead of one general interface.

// Bad Example ❌
public interface IWorker
{
    void Work();
    void Eat();
} 

public class Robot : IWorker
{
    public void Work() { }

    public void Eat()
    {
        throw new Exception(); // ❌ not needed
    }
}

// Good Example ✅
public interface IWork
{
    void Work();
}

public interface IEat
{
    void Eat();
}

public class Human : IWork, IEat
{
    public void Work() { }
    public void Eat() { }
}

public class RobotFixed : IWork
{
    public void Work() { }
}


// D - Dependency Inversion Principle (DIP) --> High-level modules should depend on abstractions, not concrete classes. It is use for reducing coupling between classes and making code more flexible and testable.

// Bad Example ❌
public class LightBulb
{
    public void TurnOn() { }
}

public class Switch
{
    private LightBulb bulb = new LightBulb();

    public void Operate()
    {
        bulb.TurnOn();
    }
}

// Good Example ✅
public interface ISwitchable
{
    void TurnOn();
}

public class LightBulbFixed : ISwitchable
{
    public void TurnOn() { }
}

public class SwitchFixed
{
    private ISwitchable device;

    public SwitchFixed(ISwitchable device)
    {
        this.device = device;
    }

    public void Operate()
    {
        device.TurnOn();
    }
}


