using System;
using System.IO;
using System.IO.Compression;

namespace Add_Python
{
    internal class Add_Python
    {
        static void Main(string[] args)
        {
            foreach(var file in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory))
            {
                Console.WriteLine(file);
                if(Path.GetExtension(file) == ".py")
                {
                    Console.WriteLine($"{file} is a python file!" );
                }
            }
        }
    }
}
