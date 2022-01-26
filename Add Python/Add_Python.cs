using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Add_Python
{
    class Add_Python
    {
        static bool lpz_found = false;
        private static List<string> Directory_Files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory).ToList();
        private static List<string> Python_Files = new List<string>();

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
                    lpz_found = true;
                    Console.WriteLine($"Enter \"y\"  to add the following files to {Path.GetFileName(crestron_file)}:");
                    Spacer(1);

                    foreach (string file in Python_Files)
                    {
                        Console.WriteLine(Path.GetFileName(file)); //lists python files in the directory
                    }
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        Spacer(2);

                        using (ZipFile zip = new ZipFile(crestron_file))
                        {
                            foreach (string file in Python_Files)
                            {
                                string python_file = Path.GetFileName(file);

                                if (zip.Info.Contains(python_file))
                                {
                                    Console.WriteLine($"{Path.GetFileName(crestron_file)} already contains {python_file}");
                                }
                                else
                                {
                                    try
                                    {
                                        zip.AddFile(file, "");
                                        Console.WriteLine($"{python_file} was added to {Path.GetFileName(crestron_file)}");
                                    }
                                    catch (Exception ex)
                                    {
                                        Spacer(1);
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                            }
                            zip.Save();
                        }
                    }
                    break; //breaks the loop to avoid complications in the event of multiple lpz files, code will only work with the first lpz file it finds
                }
            }
            Spacer(2);
            if(Python_Files.Count.Equals(0))
            {
                Spacer(1);
                Console.WriteLine("There are no python files in this folder...");
            }
            if(lpz_found == false)
            {
                Spacer(1);
                Console.WriteLine("There is no lpz file in this folder...");
            }
            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }

        static void Spacer (int num_spaces)
        {
            for(int i = 0; i < num_spaces; i++)
            {
                Console.WriteLine();
            }
        }
    }
}