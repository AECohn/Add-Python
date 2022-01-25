using Ionic.Zip;
using System;
using System.IO;

namespace Add_Python
{
    internal class Add_Python
    {
        private static void Main(string[] args)
        {
            string python_location = "";
            string crestron_Location;

            foreach (var file in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory))
            {
                if (Path.GetExtension(file) == ".py")
                {
                    python_location = file;
                    //Console.WriteLine($"{python_location} is a python file!");
                    Console.WriteLine(Path.GetFullPath(python_location));
                }
            }
            foreach (var file in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory))
            {
                if (Path.GetExtension(file) == ".lpz")
                {
                    crestron_Location = file;
                    Console.WriteLine($"{crestron_Location} is a crestron file!");

                    using (ZipFile zip = new ZipFile(crestron_Location))
                    {
                        zip.AddFile(Path.GetFullPath(python_location), "");
                        //Console.WriteLine(zip.Info);
                        zip.Save();
                    }
                }
            }
        }
    }
}