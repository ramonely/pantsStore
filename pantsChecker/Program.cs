using System;
using System.Collections.Generic;
using System.Text;

namespace pantsChecker
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            pantsLog All = new pantsLog();
            Console.WriteLine("Welcome to Devs Pants Store!\n");
            All.welcome();
        }
    }
}