using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Add_Python
{
    class Add_Python
    {
        static bool _lpzFound;
        private static List<string> Directory_Files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory).ToList();
        private static List<string> Python_Files = new List<string>();

        private static void Main()
        {
            foreach (string pythonFile in Directory_Files)
            {
                if (Path.GetExtension(pythonFile) == ".py")
                {
                    Python_Files.Add(pythonFile);
                }
            }
            foreach (string crestronFile in Directory_Files)
            {
                if (Path.GetExtension(crestronFile) == ".lpz")
                {
                    _lpzFound = true;
                    Console.WriteLine($"Enter \"y\"  to add the following files to {Path.GetFileName(crestronFile)}:");
                    Spacer(1);

                    foreach (string file in Python_Files)
                    {
                        Console.WriteLine(Path.GetFileName(file)); //lists python files in the directory
                    }
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        Spacer(2);

                        using (ZipFile zip = new ZipFile(crestronFile))
                        {
                            foreach (string file in Python_Files)
                            {
                                string pythonFile = Path.GetFileName(file);

                                if (zip.Info.Contains(pythonFile))
                                {
                                    Console.WriteLine($"{Path.GetFileName(crestronFile)} already contains {pythonFile}");
                                }
                                else
                                {
                                    try
                                    {
                                        zip.AddFile(file, "");
                                        Console.WriteLine($"{pythonFile} was added to {Path.GetFileName(crestronFile)}");
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
            if(_lpzFound == false)
            {
                Spacer(1);
                Console.WriteLine("There is no lpz file in this folder...");
            }
            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }

        static void Spacer (int numspaces)
        {
            for(int i = 0; i < numspaces; i++)
            {
                Console.WriteLine();
            }
        }
    }
}