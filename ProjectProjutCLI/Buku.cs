using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectProjutCLI
{
    class Buku
    {
        public static void Main()
        {
            int pilihan = 0;
            do{
                menuBuku();
                pilihan = int.Parse(Console.ReadLine());
                if(pilihan > 0 && pilihan < 6)
                {
                    continue;
                }
                Console.WriteLine("Pilihan yang anda masukan salah!");
            }while(pilihan <1 && pilihan >5);
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
                case 5 :
                    Program.Main();
                    break;
            }
            
        }

        public static void menuBuku()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\tMenu Buku");
            Console.WriteLine("\t\t\t\t=========\n");
            Console.WriteLine("1. Tampilkan semua buku\n");
            Console.WriteLine("2. Tampilkan buku yang dipinjam\n");
            Console.WriteLine("3. Tampilkan buku dengan judul tertentu\n");
            Console.WriteLine("4. Tampilan buku dengan pengarang tertentu\n");
            Console.WriteLine("5. Kembali ke menu utama\n");
            Console.Write("Masukan pilihan anda : ");
        }

        public static void tampilkanBukuS() //Tampilkan semua buku
        {

        }

        public static void tampilkanBukuJudul() //Tampilkan buku judul tertentu
        {

        }

        public static void tampilkanBukuPengarang() //Tampilkan buku pengarang tertentu
        {

        }
    }
}
