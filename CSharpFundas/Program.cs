//using OpenQA.Selenium.DevTools.V110.Database;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundas
{
    class Program : Program4
    {

        string name;
        string lastName;

        //method default constructor

        public Program(string name)
        {
            this.name = name;
        }


        public Program(string firstName, string lastName)
        {
            this.lastName = lastName;
        }

        public void getName()
        {
            Console.WriteLine( "My name is" + this.name );
        }

        public void getData()
        {

            Console.WriteLine("I am inside the method");
        }
      
        static void Main(string[] args)
        {
            Program p = new Program("Nelly"); // object of a class
            Program p1 = new Program("Nelly", "Ozioko");
            p.getData(); //child 
            p.getName();
            p.setData(); // parent


            Console.WriteLine("Hello World");
            //Debug.WriteLine("Hello World");
            int a = 4;
            //double c = 3.12;
            Console.WriteLine("name is" + a);

            string name = "Nelly";
            Console.WriteLine("name is" + name);
            Console.WriteLine($"name is {name}");

            //var is dynamic data type while string, int etc are static data type

            var age = 23;
            Console.WriteLine("Age is" + age);
            //age = "hello";

            dynamic height = 13.2;
            Console.WriteLine($"height is {height}");

            height ="hello";
            Console.WriteLine($"height is {height}");

        }




    }
}
