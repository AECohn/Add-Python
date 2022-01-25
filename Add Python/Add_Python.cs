using System;
using System.IO;
using Ionic.Zip;
 

namespace Add_Python
{
    internal class Add_Python
    {
        static void Main(string[] args)
        {
            string python_location = "";
            string crestron_Location;

            foreach (var file in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory))
            {
                if (Path.GetExtension(file) == ".py")
                {
                    python_location = file;
                    Console.WriteLine($"{file} is a python file!");
                }
                if (Path.GetExtension(file) == ".lpz")
                {
                    crestron_Location = file;
                    Console.WriteLine($"{file} is a crestron file!");

                    using (ZipFile zip = new ZipFile(crestron_Location))
                    {
                        //zip.AddFile(python_location);
                        Console.WriteLine(zip.Info);
                    }
                   
            }
                
            };
        }
                
            }
        }
    

