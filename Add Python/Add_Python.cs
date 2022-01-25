using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;

namespace Add_Python
{
    class Add_Python
    {
        private static void Main(string[] args)
        {
            List<string> Python_Files = new List<string>();
            //string python_location = "";
            //string crestron_Location;

            foreach (string python_file in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory))
            {
                if (Path.GetExtension(python_file) == ".py")
                {
                    Python_Files.Add(python_file);
                }
            }
            foreach (string crestron_file in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory))
            {
                if (Path.GetExtension(crestron_file) == ".lpz")
                {
                    using (ZipFile zip = new ZipFile(crestron_file))
                    {
                        try
                        {
                            zip.AddFiles(Python_Files, "");
                            zip.Save();

                            foreach (string path in Python_Files)
                            {
                                if (zip.Info.Contains(Path.GetFileName(path)))
                                {
                                    Console.WriteLine($"{Path.GetFileName(path)} was added to {Path.GetFileName(crestron_file)}");
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