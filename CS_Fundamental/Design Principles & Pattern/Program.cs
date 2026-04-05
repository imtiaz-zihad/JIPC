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


// O - Open/Closed Principle (OCP) -> Software should be open for extension but closed for modification.


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

//////////////////////////////////////////////////////
// I - Interface Segregation Principle (ISP)

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

//////////////////////////////////////////////////////
// D - Dependency Inversion Principle (DIP)

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



//////////////////////////////////////////////////////
// ❓ Interview Questions & Answers
//////////////////////////////////////////////////////

/*
1. What is DRY Principle?
Answer: DRY (Don't Repeat Yourself) means avoiding code duplication by writing reusable functions or methods.

2. Why is DRY important?
Answer: It reduces redundancy, improves maintainability, and minimizes bugs.

3. What is KISS Principle?
Answer: KISS (Keep It Simple, Stupid) means writing simple and clear code instead of complex logic.

4. Why should we follow KISS?
Answer: Simple code is easier to understand, debug, and maintain.

5. What is YAGNI Principle?
Answer: YAGNI (You Aren’t Gonna Need It) means not adding functionality until it is necessary.

6. Why avoid unnecessary features?
Answer: It reduces complexity, saves time, and keeps the code clean.

7. What are SOLID principles?
Answer: SOLID is a set of 5 object-oriented design principles:
S - Single Responsibility Principle
O - Open/Closed Principle
L - Liskov Substitution Principle
I - Interface Segregation Principle
D - Dependency Inversion Principle

8. What is Single Responsibility Principle (SRP)?
Answer: A class should have only one responsibility or reason to change.

9. What is Open/Closed Principle (OCP)?
Answer: Software should be open for extension but closed for modification.

10. What is Dependency Inversion Principle (DIP)?
Answer: High-level modules should depend on abstractions, not concrete classes.

11. Difference between DRY and KISS?
Answer:
DRY → Avoid duplication
KISS → Keep logic simple

12. Real-life example of DRY?
Answer: Using a single function to print user info instead of repeating code multiple times.


//////////////////////////////////////////////////////
// ❓ More Interview Questions & Answers
//////////////////////////////////////////////////////


13. What is code maintainability?
Answer: It refers to how easily code can be modified, updated, or fixed in the future.

14. What is readability in code?
Answer: Readability means how easily other developers can understand the code.

15. What is reusability?
Answer: Writing code in a way that it can be reused in different parts of the application.

16. What is scalability?
Answer: The ability of a system to handle increased load or growth efficiently.

17. What is clean code?
Answer: Clean code is simple, readable, and easy to maintain.

18. Why is clean code important?
Answer: It improves collaboration, reduces bugs, and makes debugging easier.

19. What is tight coupling?
Answer: When classes depend heavily on each other, making changes difficult.

20. What is loose coupling?
Answer: When classes are independent and interact through abstractions.

21. What is cohesion?
Answer: Cohesion refers to how closely related the responsibilities of a class are.

22. High cohesion vs Low cohesion?
Answer:
High cohesion → focused responsibility (good)
Low cohesion → mixed responsibilities (bad)

23. What is abstraction?
Answer: Hiding implementation details and showing only essential features.

24. What is encapsulation?
Answer: Wrapping data and methods into a single unit (class).

25. What is polymorphism?
Answer: Same method behaving differently based on context.

26. What is inheritance?
Answer: One class acquiring properties of another class.

27. Why use interfaces?
Answer: To achieve abstraction and loose coupling.

28. What is overengineering?
Answer: Adding unnecessary complexity or features that are not needed.

29. When should you refactor code?
Answer: When code becomes complex, duplicated, or hard to maintain.

30. Difference between abstraction and encapsulation?
Answer:
Abstraction → hides implementation
Encapsulation → hides data

31. What is a design pattern?
Answer: A reusable solution to common software design problems.

32. Example of design patterns?
Answer: Singleton, Factory, Observer, MVC.

33. What is modular programming?
Answer: Breaking code into smaller independent modules.

34. Why is modularity important?
Answer: It improves readability, testing, and maintainability.

35. What is code smell?
Answer: A sign that something may be wrong in the code design.

36. Example of code smell?
Answer: Duplicate code, long methods, large classes.

37. What is refactoring?
Answer: Improving code structure without changing its functionality.

38. What is dependency?
Answer: When one class relies on another class.

39. Why avoid hardcoding?
Answer: It reduces flexibility and makes code harder to maintain.

40. What is best practice?
Answer: A standard or guideline that helps write better and cleaner code.
*/