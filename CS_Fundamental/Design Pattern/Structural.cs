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
        return 2.0;
    }
}

public abstract class CoffeeDecorator : ICoffee
{
    protected  ICoffee _decoratedCoffee;

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
        return _decoratedCoffee.GetCost() + 0.5;
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

