// ------------ Structural Design Patterns --------------

// 1. Adapter Pattern → Converts the interface of a class into another interface clients expect.
/**
  Usecase: Integrating legacy systems, Third-party library integration, API adaptation, Cross-platform compatibility, Data format conversion.
  Advantages: Reusability, Flexibility, Simplified client code, Decoupling.
  Disadvantages: Increased complexity, Overhead, Maintenance challenges, Potential performance impact.
*/
public interface IDataProcessor
{
    void ProcessData(string processedData);
}

public class JsonDataProcessor : IDataProcessor
{
    public void ProcessData(string jsonData)
    {
        // Process JSON data
        Console.WriteLine($"Processing JSON data: {jsonData}");
    }
}

public class XMLDataProvider
{
    public string GetXMLData()
    {
        // Simulate fetching XML data
        XDocument xmlDoc = new XDocument(
            new XElement("User",
                new XElement("Name", "Imtiaz"),
                new XElement("Email", "mdimtiazzihad@gmail.com")
            )
        );
        return xmlDoc.ToString();
    }
}

public class XMLToJsonAdapter : IDataProcessor
{
    private readonly XMLDataProvider _xmlDataProvider;

    public XMLToJsonAdapter(XMLDataProvider xmlDataProvider)
    {
        _xmlDataProvider = xmlDataProvider;
    }

    public void ProcessData(string processedData)
    {
        string xmlData = _xmlDataProvider.GetXMLData();
        XMLDocument xmlDoc = new XMLDocument();
        xmlDoc.LoadXml(xmlData);
        string convertedJsonData = JsonConvert.SerializeXmlNode(xmlDoc);
        Console.WriteLine($"Processing adapted JSON data: {convertedJsonData}");
    }
}
class Program
{
    static void Main(string[] args)
    {
        IDataProcessor jsonProcessor = new JsonDataProcessor();
        jsonProcessor.ProcessData("{\"Name\":\"Imtiaz\",\"Email\":\"mdimtiazzihad@gmail.com\"}");

        IDataProcessor xmlToJsonAdapter = new XMLToJsonAdapter(new XMLDataProvider());
        xmlToJsonAdapter.ProcessData("");


    }
}



// 2. Decorator Pattern → Adds new functionality to existing objects dynamically.
/**
  Usecase: Adding new features to objects without modifying their structure, Implementing cross-cutting concerns, Creating flexible and maintainable code, Logging, Caching , Validation Mechanisms.
  Advantages:Follow OCP (Open/Closed Principle) & SRP (Single Responsibility Principle), Flexibility, Reusability, Simplified client code, Dynamic behavior modification.
  Disadvantages: Increased complexity, Potential performance impact, Difficult to manage and debug.
*/
public interface ICoffee
{
    string GetDescription();
    double GetCost();
}

public class SimpleCoffee : ICoffee
{
    public string GetDescription()
    {
        return "Simple Coffee";
    }

    public double GetCost()
    {
        return 200.0;
    }
}

public abstract class CoffeeDecorator : ICoffee
{
    protected ICoffee _decoratedCoffee;

    public CoffeeDecorator(ICoffee coffee)
    {
        _decoratedCoffee = coffee;
    }

    public virtual string GetDescription()
    {
        return _decoratedCoffee.GetDescription();
    }

    public virtual double GetCost()
    {
        return _decoratedCoffee.GetCost();
    }
}

public class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription()
    {
        return _decoratedCoffee.GetDescription() + ", Milk";
    }

    public override double GetCost()
    {
        return _decoratedCoffee.GetCost() + 150;
    }
}

public class SugarDecorator : CoffeeDecorator
{
    public SugarDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription()
    {
        return _decoratedCoffee.GetDescription() + ", Sugar";
    }

    public override double GetCost()
    {
        return _decoratedCoffee.GetCost() + 0.2;
    }
}


class Program2
{
    static void Main(string[] args)
    {
        ICoffee simpleCoffee = new SimpleCoffee();
        Console.WriteLine($"{simpleCoffee.GetDescription()} - Cost: {simpleCoffee.GetCost()}");

        ICoffee milkCoffee = new MilkDecorator(simpleCoffee);
        Console.WriteLine($"{milkCoffee.GetDescription()} - Cost: {milkCoffee.GetCost()}");

        ICoffee sugarMilkCoffee = new SugarDecorator(milkCoffee);
        Console.WriteLine($"{sugarMilkCoffee.GetDescription()} - Cost: {sugarMilkCoffee.GetCost()}");
    }
}


// 3. Proxy Pattern → Provides a surrogate or placeholder for another object to control access to it.

/**
  Usecase: Remote Proxy, Virtual Proxy, Protection Proxy, Caching Proxy, Logging and Monitoring.
  Advantages: Controlled access, Lazy initialization, Security and access control, Performance optimization.
  Disadvantages: Increased complexity, Potential performance overhead, Maintenance challenges.
*/

public interface IBankAccount
{
    void ShowBalance();
    void Withdraw(double amount);
}

public class BankAccount : IBankAccount
{
    private double _balance;

    public BankAccount(double balance)
    {
        _balance = balance;
    }

    public void ShowBalance()
    {
        Console.WriteLine($"Current Balance: {_balance}");
    }

    public void Withdraw(double amount)
    {
        _balance -= amount;
        Console.WriteLine($"Withdrawn: {amount}. New Balance: {_balance}");
    }
}

public class BankAccountproxy : IBankAccount
{
    private readonly BankAccount _bankAccount;
    private readonly string _userRole;

    public BankAccountProxy(double balance, string userRole)
    {
        _bankAccount = new BankAccount(balance);
        _userRole = userRole;
    }

    public void ShowBalance()
    {
        _bankAccount.ShowBalance();
    }

    public void Withdraw(double amount)
    {
        if (_userRole != "Admin")
        {
            Console.WriteLine("Access Denied: Only Admin can withdraw funds.");
            return;
        }
        _bankAccount.Withdraw(amount);
    }
}


class Program3
{
    static void Main()
    {
        IBankAccount adminAccount = new BankAccountProxy(1000, "Admin");
        adminAccount.ShowBalance();
        adminAccount.Withdraw(200);

        IBankAccount userAccount = new BankAccountProxy(1000, "User");
        userAccount.ShowBalance();
        userAccount.Withdraw(200);
    }
}

// 4. Bridge Pattern → Decouples an abstraction from its implementation so that the two can vary independently. 
/**
  Usecase: Cross-platform development, GUI frameworks, Device drivers, Remote services, Database abstraction.
  Advantages: Decoupling, Flexibility, Extensibility, Improved maintainability.
  Disadvantages: Increased complexity, Potential performance overhead, Learning curve.
*/


public interface IPaymentGateway
{
    void ProcessPayment(double amount);
}


// Implementations of the IPaymentGateway interface
public class PayPalPaymentGateway : IPaymentGateway
{
    public void ProcessPayment(double amount)
    {
        Console.WriteLine($"Processing payment of {amount} through PayPal.");
    }
}

public class StripePaymentGateway : IPaymentGateway
{
    public void ProcessPayment(double amount)
    {
        Console.WriteLine($"Processing payment of {amount} through Stripe.");
    }
}

// Abstraction 
public abstract class Payment
{
    protected IPaymentGateway _paymentGateway;

    public Payment(IPaymentGateway paymentGateway)
    {
        _paymentGateway = paymentGateway;
    }

    public abstract void MakePayment(double amount);
}

public class CardPayemnt : Payment
{
    public CardPayemnt(IPaymentGateway paymentGateway) : base(paymentGateway) { }

    public override void MakePayment(double amount)
    {
        Console.WriteLine("Card Payment initiated.");
        _paymentGateway.ProcessPayment(amount);
    }
}


public class UPIpayment : Payment
{
    public UPIpayment(IPaymentGateway paymentGateway) : base(paymentGateway) { }

    public override void MakePayment(double amount)
    {
        Console.WriteLine("UPI Payment initiated.");
        _paymentGateway.ProcessPayment(amount);
    }
}

class Program4
{
    static void Main()
    {
       Payment cardPayment = new CardPayemnt(new PayPalPaymentGateway());
        cardPayment.MakePayment(1000);

        Payment upiPayment = new UPIpayment(new StripePaymentGateway());
        upiPayment.MakePayment(500);
    }
}

// 5. Facade Pattern → Provides a simplified interface to a complex subsystem.

/**
  Usecase: Simplifying complex systems, Providing a unified interface, Hiding implementation details, Reducing dependencies, Improving code readability.
  Advantages: Simplified interface, Reduced complexity, Improved maintainability, Encapsulation.
  Disadvantages: Limited flexibility, Potential performance overhead, Maintenance challenges.
*/  

// Subsystem classes 1
class InventoryService
{
    public void CheckStock(string product)
    {
        Console.WriteLine($"Checking stock for {product}.");
        return true;
    }
}

// Subsystem classes 2
class PaymentService
{
    public void Pay(string user)
    {
        Console.WriteLine($"Processing payment for {user}.");
    }
}

// Subsystem classes 3
class ShippingService
{
    public void ShipProduct(string product)
    {
        Console.WriteLine($"Shipping {product}.");
    }
}

// Subsystem classes 4
class NotificationService
{
    public void SendNotification(string user)
    {
        Console.WriteLine($"Sending notification to {user}.");
    }
}


// Facade class
class OrderFacade
{
    private readonly InventoryService _inventoryService;
    private readonly PaymentService _paymentService;
    private readonly ShippingService _shippingService;
    private readonly NotificationService _notificationService;

    public OrderFacade()
    {
        _inventoryService = new InventoryService();
        _paymentService = new PaymentService();
        _shippingService = new ShippingService();
        _notificationService = new NotificationService();
    }

    public void PlaceOrder(string product, string user)
    {
        if (_inventoryService.CheckStock(product))
        {
            _paymentService.Pay(user);
            _shippingService.ShipProduct(product);
            _notificationService.SendNotification(user);
            Console.WriteLine("Order placed successfully.");
        }
        else
        {
            Console.WriteLine("Product is out of stock.");
        }
    }
}


class Program5
{
    static void Main()
    {
        OrderFacade orderFacade = new OrderFacade();
        orderFacade.PlaceOrder("Laptop", "Imtiaz");
    }
} 


// 6. Flyweight Pattern → Reduces the cost of creating and manipulating a large number of similar objects by sharing common data among them.
/**
  Usecase: Text rendering, Object pooling, Game development, Caching, Data compression.
  Advantages: Memory efficiency, Improved performance, Reduced object creation overhead, Simplified object management.
  Disadvantages: Increased complexity, Potential performance overhead, Maintenance challenges.
*/

class Tree
{
    private string type; // Intrinsic state (shared among multiple trees)

    public Tree(string type)
    {
        this.type = type;
    }
    public void Display(int x, int y) // Extrinsic state (unique for each tree)
    {
        Console.WriteLine($"Displaying {type} tree at coordinates ({x}, {y}).");
    }
}

class TreeFactory
{
    private static Dictionary<string, Tree> treePool = new Dictionary<string, Tree>();

    public Tree GetTree(string type)
    {
        if (!treePool.ContainsKey(type))
        {
            treePool[type] = new Tree(type);
            Console.WriteLine($"Creating new {type} tree.");
        }
        return treePool[type];
    }
}

class Program6
{
    static void Main()
    {
        TreeFactory treeFactory = new TreeFactory();

        Tree oakTree1 = treeFactory.GetTree("Oak");
        oakTree1.Display(10, 20);

        Tree oakTree2 = treeFactory.GetTree("Oak");
        oakTree2.Display(30, 40);

        Tree pineTree = treeFactory.GetTree("Pine");
        pineTree.Display(50, 60);
    }
}


// 7. Composite Pattern → Composes objects into tree structures to represent part-whole hierarchies.
/**
  Usecase: File systems, GUI components, Organizational structures, Graphics rendering, Hierarchical data representation.
  Advantages: Simplified client code, Flexibility, Reusability, Improved maintainability.
  Disadvantages: Increased complexity, Potential performance overhead, Maintenance challenges.
*/

public abstract class OrganizationUnit
{
    private string _name;
    public OrganizationUnit(string name)
    {
        _name = name;
    }

    public abstract int GetBudget();

    public virtual void AddUnit(OrganizationUnit unit)
    {
        Console.WriteLine($"Adding {unit}");
    }

    public virtual void RemoveUnit(OrganizationUnit unit)
    {
        Console.WriteLine($"Removing {unit}");
    }
}

public class Employee : OrganizationUnit
{
    private int _salary;
    private string _name;

    public Employee(string name, int salary) : base(name)
    {
        _salary = salary;
        _name = name;
    }

    public override int GetBudget()
    {
        Console.WriteLine($"Employee {_name} - Salary: {_salary}");
        return _salary;
    }
}

public class Department : OrganizationUnit
{
    private List<OrganizationUnit> _units = new List<OrganizationUnit>();
    public string _name;
    public Department(string name) : base(name)
    {
        _name = name;
    }
    public override void AddUnit(OrganizationUnit unit)
    {
        _units.Add(unit);
    }

    public override void RemoveUnit(OrganizationUnit unit)
    {
        _units.Remove(unit);
    }

    public override int GetBudget()
    {
        Console.WriteLine($" Department {_name} - Total Employee: {_units.Count}");
        int totalBudget = 0; //_units.Sum(unit => unit.GetBudget());
        foreach (var unit in _units)
        {
            totalBudget += unit.GetBudget();
        }
        Console.WriteLine($"Budget: {totalBudget}");
        return totalBudget;
    }
}

public class Program
{
    static void Main(string[] args)
    {
        var john = new Employee("John", 25000);
        var bob = new Employee("Bob", 30000);
        var alice = new Employee("Alice", 35000);
        var subhashis = new Employee("Subhashis", 40000);
        
        var devTeam =new Department("DevTeam");
        var qaTeam = new Department("QATeam");
        
        var companyTeam = new Department("CompanyTeam");
        
        devTeam.AddUnit(john);
        devTeam.AddUnit(bob);
        
        qaTeam.AddUnit(alice);
        
        companyTeam.AddUnit(subhashis);
        companyTeam.AddUnit(devTeam);
        companyTeam.AddUnit(qaTeam);
        
        //Console.WriteLine(companyTeam.GetBudget());
        //Console.WriteLine(devTeam.GetBudget());
        //Console.WriteLine(qaTeam.GetBudget());
        Console.WriteLine(subhashis.GetBudget());
    }
}

/*Company-
    Subhashis
    DevTeam
        - John
        - Bob 
    QATeam
        - Alice
    
*/