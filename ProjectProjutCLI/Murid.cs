using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectProjutCLI
{
    class Murid
    {
        public static void Main()
        {
            int pilihan = 0;
            do {
                menuMurid();
                pilihan = int.Parse(Console.ReadLine());
                if (pilihan > 0 && pilihan <6)
                {
                    continue;
                }
                Console.WriteLine("Pilihan yang anda masukan salah!");
            }while(pilihan < 1 && pilihan >5);

            switch(pilihan)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    Program.Main();
                    break;
            }
        }

        static void menuMurid()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\tMenu Murid");
            Console.WriteLine("\t\t\t\t==========\n");
            Console.WriteLine("1. Tampilkan semua murid\n");
            Console.WriteLine("2. Tampilkan murid laki-laki\n");
            Console.WriteLine("3. Tampilkan murid perempuan\n");
            Console.WriteLine("4. Tambah murid\n");
            Console.WriteLine("5. Kembali ke menu utama");
        }

        static void menuTambahmurid()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\tMenu Murid");
            Console.WriteLine("\t\t\t\t==========\n");
            Console.WriteLine("1. Masukan data murid\n");
            Console.WriteLine("2. Kembali ke menu utama\n");
        }

        static void menuMasukanmurid()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\tMasukan Data Murid");
            Console.WriteLine("\t\t\t\t==================\n");

        }
    }
}
