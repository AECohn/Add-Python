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
                            zip.AddFile(Path.GetFullPath(python_location), "");
                            zip.Save();

                            if (zip.Info.Contains(Path.GetFileName(python_location)))
                            {
                                Console.WriteLine($"{Path.GetFileName(python_location)} was added to {Path.GetFileName(crestron_Location)}");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        
                    }
                }
            }
        }
    }
}