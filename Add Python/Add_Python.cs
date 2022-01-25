using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Add_Python
{
    class Add_Python
    {
        static List<string> Directory_Files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory).ToList();
        static List<string> Python_Files = new List<string>();

        private static void Main(string[] args)
        {
            foreach (string python_file in Directory_Files)
            {
                if (Path.GetExtension(python_file) == ".py")
                {
                    Python_Files.Add(python_file);
                }
            }
            foreach (string crestron_file in Directory_Files)
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
                                string python_file = Path.GetFileName(path);

                                if (zip.Info.Contains(python_file))
                                {
                                    Console.WriteLine($"{python_file} was added to {Path.GetFileName(crestron_file)}");
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