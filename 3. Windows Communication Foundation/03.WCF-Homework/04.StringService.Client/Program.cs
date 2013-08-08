using _04.StringService.Client.StringServiceReference;
using System;

namespace _04.StringService.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //CTRL+F5 project 5 Server
           
            Console.Write("Master string: ");
            string masterString = Console.ReadLine();
            Console.WriteLine("Child string: ");
            string childString = Console.ReadLine();

            StringServiceClient stringService = new StringServiceClient();

            int result = stringService.GetStringOccurences(masterString, childString);

            Console.WriteLine("{0} contains {1} - {2} times", masterString, childString, result);
        }
    }
}
