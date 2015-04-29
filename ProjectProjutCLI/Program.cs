using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectProjutCLI
{
    class Program
    {

        public static Byte pilihan = 0;

        static void Main(string[] args)
        {
            for (; ; )
            {
                Console.WriteLine("\t\t\t\tSistem Perpustakaan");
                Console.WriteLine("\t\t\t\t===================");
                Console.WriteLine("1. Menu Murid\n");
                Console.WriteLine("2. Menu Buku\n");
                Console.WriteLine("3. Menu Peminjaman\n");
                Console.WriteLine("4. Exit Program\n");
                Console.Write("Masukan pilihan anda : ");
                pilihan = byte.Parse(Console.ReadLine());
                switch (pilihan)
                {
                    case 1:
                        buku.menuBuku();
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Perintah yang anda masukan salah!");
                        break;
                }
            }
        }
    }


    class buku
    {
        public static void menuBuku()
        {
            for(;;)
            {
                Console.WriteLine("\t\t\t\tMenu Buku");
                Console.WriteLine("\t\t\t\t=========");
            }
        }
    }

    class murid
    {
        public static void menuMurid()
        {

        }
    }

    class peminjaman
    {
        public static void menuPeminjaman()
        {

        }
    }
}
