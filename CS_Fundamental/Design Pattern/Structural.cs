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