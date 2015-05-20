//Made by :
//  Alvin Julian
//  David A. Soborono
//  Kelvin Kristianto
// HCI 2014, Sistem Perpustakaan
using System;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Reflection;
namespace ProjectProjutCLI
{
    class Sorting
    {
        public static void sortingNIM()
        {
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string file = dir + @"\student.txt";
            string filecp = dir + @"\studentcp.txt";
            string[] scores = File.ReadAllLines(file);
            var orderedScores = scores.OrderBy(x => int.Parse(x.Split('\t')[0]));

            foreach (var score in orderedScores)
            {
                if (!File.Exists(file))
                    {
                        // Create a file to write to. kalau belom ada filenya 
                        using (StreamWriter swnew = File.CreateText(filecp))
                        {
                            swnew.WriteLine(score);
                        }
                    }
                    //kalau ud ada file yang mau ditulis
                    else
                    {
                        using (FileStream fs = new FileStream(filecp, FileMode.Append, FileAccess.Write))
                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            sw.WriteLine(score);
                        }
                    }
            }
            string target = dir + @"\student.txt";
            //copy file di folder yg sama.. hati2 penamaanya yaa
            System.IO.File.Copy(filecp, target, true);

            //delete cp nya sekarang
            File.Delete(filecp);
        }

        public static void sortingBookID()
        {
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string file = dir + @"\book.txt";
            string filecp = dir + @"\bookcp.txt";
            string[] scores = File.ReadAllLines(file);
            var orderedScores = scores.OrderBy(x =>(x.Split('\t')[1]));

            foreach (var score in orderedScores)
            {
                if (!File.Exists(file))
                {
                    // Create a file to write to. kalau belom ada filenya 
                    using (StreamWriter swnew = File.CreateText(filecp))
                    {
                        swnew.WriteLine(score);
                    }
                }
                //kalau ud ada file yang mau ditulis
                else
                {
                    using (FileStream fs = new FileStream(filecp, FileMode.Append, FileAccess.Write))
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(score);
                    }
                }
            }
            string target = dir + @"\book.txt";
            //copy file di folder yg sama.. hati2 penamaanya yaa
            System.IO.File.Copy(filecp, target, true);

            //delete cp nya sekarang
            File.Delete(filecp);
        }
    }
}
