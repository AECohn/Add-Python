using System;
using System.IO;

namespace Add_Python
{
    internal class Add_Python
    {
        static void Main(string[] args)
        {
            foreach(var file in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory))
            {
                Console.WriteLine(file);
            }
        }
    }
}
