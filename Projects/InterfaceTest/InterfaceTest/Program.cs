using System;

namespace InterfaceTest
{
    interface IInfo
    {
        string GetName();
        string GetAge();
    }
    class CA : IInfo
    {   // declare that CA implements the interface
        public string Name;
        public int Age;
        // implement the two interface methods:
        public string GetName() { return Name; }
        public string GetAge() { return Age.ToString(); }
    }
    class CB : IInfo
    {   // declare that CB implements the interface
        public string First;
        public string Last;
        public double PersonsAge;
        public string GetName() { return First + " " + Last; }
        public string GetAge() { return PersonsAge.ToString(); }
    }
    class Program
    {
        static void PrintInfo(IInfo item) // pass objects as references to the interface
        {
            Console.WriteLine("Name: {0}     Age: {1}", item.GetName(), item.GetAge());
        }
        static void Main()
        {
            // instantiate using object initialization syntax
            CA a = new CA() { Name = "John Doe", Age = 35 };
            CB b = new CB() { First = "Jane", Last = "Smith", PersonsAge = 44.0 };
            // references to the objects are automatically converted to references
            // to the interfaces they implement (in the code below)
            PrintInfo(a);
            PrintInfo(b);

            Console.WriteLine("\npress any key to exit the process...");
            Console.ReadKey();

        }
    }
}
