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

/*
# 🔥 Creational Design Patterns — Cheat Sheet

| # | Pattern                 | Core Idea                        | কখন ব্যবহার করব?                                              | Keyword    |
| - | ----------------------- | -------------------------------- | ------------------------------------------------------------- | ---------- |
| 1 | 🧍 **Singleton**        | Only one object                  | পুরো application-এ একটি মাত্র instance দরকার হলে              | **ONE**    |
| 2 | 🏗️ **Builder**         | Step-by-step object creation     | Complex object অনেক ধাপে তৈরি করতে হলে                        | **BUILD**  |
| 3 | 🏭 **Factory Method**   | Object creation hide করে         | কোন concrete class-এর object লাগবে তা runtime-এ decide হলে    | **CREATE** |
| 4 | 🏢 **Abstract Factory** | Related objects-এর family create | Related objects একসাথে তৈরি করতে হলে                          | **FAMILY** |
| 5 | 🧬 **Prototype**        | Existing object clone            | নতুন object শুরু থেকে না বানিয়ে existing object copy করতে হলে | **CLONE**  |

---

## 🧠 One-Line Memory Trick

```text id="0fpg0k"
Singleton        → ONE
Builder          → BUILD
Factory Method   → CREATE
Abstract Factory → FAMILY
Prototype        → CLONE
```

---

# 1. 🧍 Singleton

### Question:

> **"এই class-এর শুধু একটা object দরকার?"**

```text id="tq8l1g"
Class
 ↓
ONE Object
```

**Example:**

* Configuration
* Logger
* Application settings

```csharp
var a = Singleton.GetInstance();
var b = Singleton.GetInstance();

a == b  // True
```

### Keyword:

**ONE**

---

# 2. 🏗️ Builder

### Question:

> **"একটা complex object step-by-step তৈরি করতে হবে?"**

```text id="k4u4r5"
Builder
 ↓
CPU
 ↓
RAM
 ↓
Storage
 ↓
GPU
 ↓
Object
```

**Example:**

* Computer
* API Request
* Configuration
* Complex form

### Keyword:

**BUILD**

---

# 3. 🏭 Factory Method

### Question:

> **"কোন object তৈরি হবে সেটা hide/decide করতে চাই?"**

```text id="s8c2u3"
Client
 ↓
Factory
 ↓
 ┌──────┬──────┐
 ↓      ↓
Email  SMS
```

Client-কে লিখতে হচ্ছে না:

```csharp
new EmailNotification()
```

বরং:

```csharp
Factory.CreateNotification("Email");
```

**Example:**

* Notification
* Logger
* Database connection
* Payment provider

### Keyword:

**CREATE**

---

# 4. 🏢 Abstract Factory

### Question:

> **"একসাথে related objects-এর একটা family তৈরি করতে হবে?"**

```text id="9qz0s2"
        Factory
       /       \
   Windows      Mac
      │           │
   Button      Button
   Checkbox    Checkbox
```

Windows factory দিলে:

```text id="5nq3kd"
Windows Button
Windows Checkbox
```

Mac factory দিলে:

```text id="2a8t0m"
Mac Button
Mac Checkbox
```

**Example:**

* Windows UI / Mac UI
* Light Theme / Dark Theme
* Database families

### Keyword:

**FAMILY**

---

# 5. 🧬 Prototype

### Question:

> **"Existing object copy করে নতুন object বানাতে চাই?"**

```text id="5q7j6m"
Original
   ↓
 Clone
   ↓
New Object
```

**Example:**

* Complex object cloning
* Game characters
* Test data
* Pre-configured objects

```csharp
var clone = original.Clone();
```

### Keyword:

**CLONE**

---

# ⚔️ Most Confusing Ones

### Factory Method vs Abstract Factory

**Factory Method:**

```text id="1y2s9c"
One product
     ↓
Factory
 ↓       ↓
Email   SMS
```

👉 **এক ধরনের object তৈরি।**

**Abstract Factory:**

```text id="8r0g4k"
Factory
 ↓
Product Family
 ├── Button
 ├── Checkbox
 └── TextBox
```

👉 **Related products-এর family তৈরি।**

### মনে রাখো:

> **Factory = One product type**

> **Abstract Factory = Product family**

---

### Builder vs Factory

**Builder:**

> Object **কীভাবে step-by-step তৈরি হবে**

```text id="n8k2f0"
CPU → RAM → GPU → Storage
```

**Factory:**

> **কোন object তৈরি হবে**

```text id="x5q1a7"
Email OR SMS?
```

### মনে রাখো:

> **Builder = HOW to build**

> **Factory = WHICH object**

---

### Prototype vs Builder

**Builder:**

```text id="1h3s7k"
Start empty
 ↓
Build step-by-step
 ↓
Object
```

**Prototype:**

```text id="4p8v2d"
Existing Object
 ↓
Clone
 ↓
New Object
```

> **Builder = BUILD**

> **Prototype = COPY**

---

# 🎯 Interview Trigger Words

```text id="q6w8n2"
"Only one instance"
        ↓
    SINGLETON

"Step-by-step construction"
        ↓
      BUILDER

"Which object should I create?"
        ↓
 FACTORY METHOD

"Family of related objects"
        ↓
 ABSTRACT FACTORY

"Copy existing object"
        ↓
    PROTOTYPE
```

---

# 🏆 Final Memory

──────── CREATIONAL ────────

Singleton        → ONE
Builder          → BUILD
Factory Method   → CREATE
Abstract Factory → FAMILY
Prototype        → CLONE



*/