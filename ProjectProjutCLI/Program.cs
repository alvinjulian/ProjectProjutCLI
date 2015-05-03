using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectProjutCLI
{
    class Program
    {   
        public static void Main()
        {
                printMenu();
                Int16 pilih = 0;
                Console.Write("Masukan pilihan anda : ");
                pilih = Convert.ToInt16(Console.ReadLine());
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
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
        }

        static void printMenu()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\tSistem Perpustakaan");
            Console.WriteLine("\t\t\t\t===================");
            Console.WriteLine("1. Menu Murid\n");
            Console.WriteLine("2. Menu Buku\n");
            Console.WriteLine("3. Menu Peminjaman\n");
            Console.WriteLine("4. Exit Program\n");
        }
    }
}
