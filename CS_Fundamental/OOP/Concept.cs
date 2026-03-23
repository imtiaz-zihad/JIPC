/*
====================================
🚀 C# OOP (Object Oriented Programming)
====================================

OOP = Object দিয়ে programming করা

👉 Main Concepts:
- Class
- Object
- Property (Field)
- Method
- Constructor
- Inheritance
- Abstraction
- Encapsulation

------------------------------------
🏗️ Class & Object
------------------------------------
*/

public class Car
{
    public string Brand; // property (field)
    public int Speed;    // property (field)

    // Default Constructor
    public Car() {}

    // Constructor with 1 parameter
    public Car(int speed)
    {
        Speed = speed;
    }

    // Constructor with multiple parameters
    public Car(string brand, int Speed)
    {
        this.Brand = brand;
        this.Speed = Speed;
    }

    // Method
    public void Drive()
    {
        Console.WriteLine("Car is Driving");
    }

    public int GetSpeed()
    {
        return Speed;
    }
}

/*
👉 Class = Blueprint
👉 Object = Class এর instance

Example:
Car car1 = new Car();

------------------------------------
🔐 Access Modifiers
------------------------------------

public      → everywhere access
private     → only inside class
protected   → class + derived class

------------------------------------
👨‍👦 Inheritance
------------------------------------
*/

public class Person
{
    protected string Name;
    public string email;
    public string phoneNumber;
}

public class Teacher : Person
{
    // inherits Person
}

public class Student : Person
{
    public int RollNumber;

    public Student(string name)
    {
        this.Name = name; // protected → accessible
    }
}

/*
👉 Inheritance = Code reuse
👉 "is-a" relationship

Student is-a Person
Teacher is-a Person

------------------------------------
🎭 Abstraction (Abstract Class)
------------------------------------
*/

public abstract class AbstractAnimal
{
    public abstract void MakeSound(); // must override

    public void Eat()
    {
        Console.WriteLine("Animal is eating");
    }
}

public class Dog : AbstractAnimal
{
    public override void MakeSound()
    {
        Console.WriteLine("Dog barks");
    }
}

/*
👉 abstract class = incomplete class
👉 abstract method = must implement in child class

------------------------------------
🔒 Sealed Class
------------------------------------
*/

public sealed class SealedClass
{
    public void Test()
    {
        Console.WriteLine("Sealed class method");
    }
}

/*
👉 sealed class = cannot inherit

class A : SealedClass ❌ ERROR

------------------------------------
🎯 Main Program
------------------------------------
*/

class Program
{
    static void Main()
    {
        // Constructor examples
        Car car1 = new Car();
        Car car2 = new Car(100);
        Car car3 = new Car("BMW", 200);

        Console.WriteLine(car3.Brand);
        Console.WriteLine(car3.Speed);

        // Method call
        car3.Drive();

        // Inheritance example
        Student s = new Student("Imtiaz");
        s.email = "test@gmail.com";

        // Abstract class example
        Dog dog = new Dog();
        dog.MakeSound(); // Dog barks
        dog.Eat();       // Animal is eating
    }
}

/*
------------------------------------
🧾 Cheatsheet
------------------------------------

Class           → Blueprint
Object          → Instance
Property        → Variable inside class
Method          → Function inside class
Constructor     → Special method (object create time)

Inheritance     → reuse code
Abstract        → hide implementation
Sealed          → stop inheritance

------------------------------------
🔥 Interview Tips
------------------------------------

Q: Difference between abstract and normal class?

✔ Abstract:
- Cannot create object
- Can have abstract method

✔ Normal:
- Object create possible

------------------------------------
💡 Final কথা
------------------------------------

👉 OOP = real world modeling
👉 Code clean + reusable + scalable
*/