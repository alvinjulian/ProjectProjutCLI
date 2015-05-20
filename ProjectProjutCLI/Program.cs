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
    class Program
    {

        [DllImport("kernel32.dll", ExactSpelling = true)]

        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int HIDE = 0;
        private const int MAXIMIZE = 3;
        private const int MINIMIZE = 6;
        private const int RESTORE = 9;

        public static void Main()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string filein = dir + @"\input.txt";
            if (!File.Exists(filein))
            {
                Sorting.sortingNIM();
                Sorting.sortingBookID();
            }
            bool kondisi;

            int pilih = 0;
            string pilihan;
                do{
                    printMenu();
                    Console.Write("Masukan pilihan anda : ");
                    pilihan = Console.ReadLine();
                    inputlog(pilihan);       
                    kondisi = int.TryParse(pilihan, out pilih);
                    if(kondisi==true && pilih >0 && pilih <5)
                    {
                        continue;
                    }
                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\tPilihan yang anda masukan salah!");
                    Console.WriteLine("\t\t\t\t\t\t\t\tTekan sembarang untuk memilih kembali...");
                    Console.ReadLine();
                }while(pilih <1 || pilih > 4);

                switch (pilih)
                {
                    case 1:
                        Murid.MainMurid();
                        break;
                    case 2:
                        Buku.MainBuku();
                        break;
                    case 3:
                        Peminjaman.MainPeminjaman();
                        break;
                    case 4:
			inputlog(pilihan);
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
        }

        static void printMenu()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t\t\tSistem Perpustakaan");
            Console.WriteLine("\t\t\t\t\t\t\t\t===================");
            Console.WriteLine("1. Menu Murid\n");
            Console.WriteLine("2. Menu Buku\n");
            Console.WriteLine("3. Menu Peminjaman\n");
            Console.WriteLine("4. Exit Program\n");
        }
        public static void inputlog(string input)
        {
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string filecp = dir + @"\input.txt";
            //StreamReader sr = new StreamReader(file);
            if (!File.Exists(filecp))
            {
                // Create a file to write to. kalau belom ada filenya 
                using (StreamWriter swnew = File.CreateText(filecp))
                {
                    swnew.WriteLine(input);
                }
            }
            //kalau ud ada file yang mau ditulis
            else
            {
                using (FileStream fs = new FileStream(filecp, FileMode.Append, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(input);
                }
            }
        }
    }
}
