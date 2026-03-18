/*
Basic of Object-Oriented Programming (OOP) in C#
Reference links:
1. https://www.cpsacademy.io/blog/--c-sharp-programming-/introduction---c----
2. https://github.com/CPS-Academy/JIPC_Resources_Batch_2/blob/main/CS%20Fundamentals/Class01_CSharpBasics_FirstStepOfLearningOOP/Program.cs
*/

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // ================================
        // Hello World
        // ================================
        Console.WriteLine("Hello, World!");

        // ================================
        // Data Types and Variables
        // ================================
        int a = 10;
        double b = 3.14;
        char c = 'A';
        bool isTrue = true;

        Console.WriteLine($"Int: {a}, Double: {b}, Char: {c}, Bool: {isTrue}");

        // ================================
        // Conditions (if-else)
        // ================================
        if (a > 5)
        {
            Console.WriteLine("a is greater than 5");
        }
        else
        {
            Console.WriteLine("a is less or equal to 5");
        }

        // ================================
        // Loop (for loop)
        // ================================
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("For Loop: " + i);
        }

        // ================================
        // Loop (while loop)
        // ================================
        int j = 0;
        while (j < 3)
        {
            Console.WriteLine("While Loop: " + j);
            j++;
        }

        // ================================
        // Array
        // ================================
        int[] arr = { 5, 2, 8, 1, 3 };

        Console.WriteLine("Array:");
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();

        // ================================
        // Array Sort
        // ================================
        Array.Sort(arr);
        Console.WriteLine("Sorted Array:");
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();

        // ================================
        // 2D Array
        // ================================
        int[,] matrix = {
            {1, 2},
            {3, 4}
        };

        Console.WriteLine("2D Array:");
        for (int i = 0; i < 2; i++)
        {
            for (int k = 0; k < 2; k++)
            {
                Console.Write(matrix[i, k] + " ");
            }
            Console.WriteLine();
        }

        // ================================
        // List
        // ================================
        List<int> list = new List<int> { 10, 20, 30 };
        list.Add(40);

        Console.WriteLine("List:");
        foreach (int num in list)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();

        // ================================
        // String and Char Sort
        // ================================
        string str = "hello";
        char[] chars = str.ToCharArray();
        Array.Sort(chars);
        string sortedStr = new string(chars);

        Console.WriteLine("Sorted String: " + sortedStr);

        // ================================
        // Array of Strings
        // ================================
        string[] names = { "Zara", "Ali", "John" };
        Array.Sort(names);

        Console.WriteLine("Sorted String Array:");
        foreach (string name in names)
        {
            Console.WriteLine(name);
        }

        // ================================
        // 2D String Grid
        // ================================
        string[,] grid = {
            {"A", "B"},
            {"C", "D"}
        };

        Console.WriteLine("2D String Grid:");
        for (int i = 0; i < 2; i++)
        {
            for (int k = 0; k < 2; k++)
            {
                Console.Write(grid[i, k] + " ");
            }
            Console.WriteLine();
        }

        // ================================
        // String Compare
        // ================================
        string s1 = "apple";
        string s2 = "banana";

        if (s1.Equals(s2))
            Console.WriteLine("Strings are equal");
        else
            Console.WriteLine("Strings are not equal");

        // ================================
        // Reverse String
        // ================================
        string original = "hello";
        char[] rev = original.ToCharArray();
        Array.Reverse(rev);
        string reversed = new string(rev);

        Console.WriteLine("Reversed String: " + reversed);

        // ================================
        // Dictionary
        // ================================
        Dictionary<string, int> dict = new Dictionary<string, int>();

        // add
        dict.Add("A", 1);
        dict.Add("B", 2);

        // check contains
        if (dict.ContainsKey("A"))
        {
            Console.WriteLine("Key A exists");
        }

        // remove
        dict.Remove("B");

        Console.WriteLine("Dictionary:");
        foreach (var item in dict)
        {
            Console.WriteLine(item.Key + " -> " + item.Value);
        }

        // ================================
        // Function Call
        // ================================
        int sum = Add(5, 7);
        Console.WriteLine("Sum: " + sum);

        // ================================
        // Basic OOP
        // ================================
        Person p = new Person("Imtiaz", 22);
        p.Display();
    }

    // ================================
    // Function
    // ================================
    static int Add(int x, int y)
    {
        return x + y;
    }
}

// ================================
// Basic OOP Class
// ================================
class Person
{
    public string Name;
    public int Age;

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public void Display()
    {
        Console.WriteLine("Name: " + Name + ", Age: " + Age);
    }
}