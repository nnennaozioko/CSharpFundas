//ArrayList
using OpenQA.Selenium;
using System.Collections;

    ArrayList a = new ArrayList();
    a.Add("hello");
    a.Add("bye");
    a.Add("Nelly");
    a.Add("Apple");

    Console.WriteLine(a[1]);

    foreach (string item in a)
    {
        Console.WriteLine(item);
    }

    Console.WriteLine(a.Contains("Nelly"));
    Console.WriteLine("After Sorting");
    a.Sort();

    foreach (string item in a)
    {
        Console.WriteLine(item);
    }

