using Ionic.Zip;
using System;
using System.IO;
using System.Collections.Generic;

namespace Add_Python
{
    class Add_Python
    {
         static void Main(string[] args)
        {
            List<string> Python_Files = new List<string>();
            string python_location = "";
            string crestron_Location;

            foreach (var file in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory))
            {
                if (Path.GetExtension(file) == ".py")
                {
                    python_location = file;
                    Python_Files.Add(file);
                }
            }
            foreach (var file in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory))
            {
                if (Path.GetExtension(file) == ".lpz")
                {
                    crestron_Location = file;
                    using (ZipFile zip = new ZipFile(crestron_Location))
                    {
                        try
                        {
                            zip.AddFiles(Python_Files, "");
                            zip.Save();

                            foreach (string path in Python_Files)
                            {
                                if (zip.Info.Contains(Path.GetFileName(path)))
                                {
                                    Console.WriteLine($"{Path.GetFileName(path)} was added to {Path.GetFileName(crestron_Location)}");
                                }
                            }
                           
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }
    }
}