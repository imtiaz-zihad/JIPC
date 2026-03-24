/*
Importnt link: 
1.https://www.linkedin.com/pulse/4-pillars-object-oriented-programming-pushkar-kumar
2.https://codersathi.com/four-pillars-of-object-oriented-programming/
3.https://osgoodgunawan.medium.com/the-four-pillars-of-object-oriented-programming-95757afeeeee
4.https://www.youtube.com/live/b3GccK5_KSQ
*/

/*
=========================================
🚀 The 4 Pillars of OOP (Easy + Interview)
=========================================

👉 OOP = Object Oriented Programming

4 Pillars:
1. Abstraction
2. Encapsulation
3. Inheritance
4. Polymorphism

-----------------------------------------
🧠 1. Abstraction (Hide complexity)
-----------------------------------------

Definition:
👉 Only show necessary things, hide internal details

Real Life:
👉 TV remote → শুধু button দেখি, ভিতরের circuit না

Code:
*/

abstract class Vehicle
{
    public abstract void Start(); // no implementation
}

class Car : Vehicle
{
    public override void Start()
    {
        Console.WriteLine("Car starts with key");
    }
}

/*
👉 Key Point:
- Focus on "WHAT to do"
- Hide "HOW it works"

-----------------------------------------
🔐 2. Encapsulation (Data hiding)
-----------------------------------------

Definition:
👉 Data + Method একসাথে wrap করা (class)
👉 private দিয়ে data hide করা

Real Life:
👉 ATM → balance direct access করা যায় না

Code:
*/

class BankAccount
{
    private double balance;

    public void Deposit(double amount)
    {
        if (amount > 0)
            balance += amount;
    }

    public double GetBalance()
    {
        return balance;
    }
}

/*
👉 Key Point:
- Data protected
- Controlled access (getter/setter)

-----------------------------------------
👨‍👦 3. Inheritance (Reuse code)
-----------------------------------------

Definition:
👉 One class another class এর property use করে

Real Life:
👉 Child inherits parents traits

Code:
*/

class Animal
{
    public void Eat()
    {
        Console.WriteLine("Eating...");
    }
}

class Dog : Animal
{
    public void Bark()
    {
        Console.WriteLine("Dog barks");
    }
}

/*
👉 Key Point:
- Code reuse
- "is-a" relationship
  Dog is-a Animal

-----------------------------------------
🎭 4. Polymorphism (Many forms)
-----------------------------------------

Definition:
👉 Same method, different behavior

Types:
1. Compile-time → Overloading --> Same method name, different parameters
2. Runtime → Overriding -->Same method name, same parameters, but different behavior in child class

Code (Overriding):
*/

class Shape
{
    public virtual void Draw()
    {
        Console.WriteLine("Drawing shape");
    }
}

class Circle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Drawing circle");
    }
}

/*
Usage:
Shape s = new Circle();
s.Draw(); // circle

👉 Key Point:
- Same function name
- Different output

-----------------------------------------
🔗 How They Work Together
-----------------------------------------

Encapsulation + Abstraction → Hide data + logic
Inheritance + Polymorphism → Reuse + flexibility

-----------------------------------------
⚠️ Common Mistakes
-----------------------------------------

❌ Abstraction = Encapsulation → WRONG
✔ Abstraction = hide complexity
✔ Encapsulation = hide data

❌ Polymorphism = Overloading only → WRONG
✔ Also includes overriding

-----------------------------------------
🧾 Real-Life Analogy
-----------------------------------------

Encapsulation → Capsule medicine 💊
Inheritance   → Family tree 👨‍👦
Polymorphism  → Power button 🔘
Abstraction   → Driving car 🚗

-----------------------------------------
🎯 Interview Questions (IMPORTANT)
-----------------------------------------

Q1: What are the 4 pillars of OOP?
👉 Abstraction, Encapsulation, Inheritance, Polymorphism

---

Q2: Difference between Abstraction & Encapsulation?

👉 Abstraction:
- Hide complexity
- Focus on WHAT

👉 Encapsulation:
- Hide data
- Protect variables using private

---

Q3: What is Inheritance?

👉 Reusing properties of parent class

Example:
Dog inherits Animal

---

Q4: What is Polymorphism?

👉 One method, many forms

Types:
- Overloading (compile-time)
- Overriding (runtime)

---

Q5: Why Encapsulation important?

👉 Data security
👉 Control access
👉 Maintainable code

---

Q6: Can we create object of abstract class?

👉 ❌ No

---

Q7: What is method overriding?

👉 Child class changes parent method behavior

---

Q8: What is real-life example of polymorphism?

👉 Same button → different device response

---

Q9: What is "is-a" relationship?

👉 Inheritance
Dog is-a Animal

---

Q10: What is advantage of OOP?

👉 Reusable
👉 Scalable
👉 Clean code

-----------------------------------------
🔥 Final Summary (1 line each)
-----------------------------------------

Abstraction   → Hide complexity
Encapsulation → Hide data
Inheritance   → Reuse code
Polymorphism  → Many forms

-----------------------------------------
💡 Interview Tip
-----------------------------------------

👉 Always give:
1. Definition
2. Real-life example
3. Small code example

🔥 This = Full marks answer
*/