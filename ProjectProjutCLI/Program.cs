using System;
using System.Data;
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
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Int16 pilih = 0;
                
                do{
                    printMenu();
                    Console.Write("Masukan pilihan anda : ");
                    pilih = Convert.ToInt16(Console.ReadLine());
                    if(pilih >0 && pilih <5)
                    {
                        continue;
                    }
                    Console.WriteLine("Pilihan yang anda masukan salah!");
                    Console.WriteLine("Tekan sembarang untuk memilih kembali...");
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

        public DataTable dt = new DataTable();
    }
}
