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
        public static void MainBuku()
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
                    tampilkanBukuS();
                    break;
                case 2:
                    tampilkanBukuPinjam();
                    break;
                case 3:
                    tampilkanBukuJudul();
                    break;
                case 4:
                    tampilkanBukuPengarang();
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
            Console.Clear();
            Console.WriteLine("\t\t\t\tList Buku");
            Console.WriteLine("\t\t\t\t=========\n");

            //Codingan baca dari file atau ambil langsung dri function

            Console.WriteLine("Klik sembarang untuk kembali ke menu buku...");
            Console.ReadKey();
            MainBuku();
        }

        public static void tampilkanBukuJudul() //Tampilkan buku judul tertentu
        {
            string keywordJudul = "";
            Console.Clear();
            Console.WriteLine("\t\t\t\tList Buku berdasarkan judul");
            Console.WriteLine("\t\t\t\t===========================\n");
            Console.Write("Masukkan kata-kata judul buku:");
            do
            {
                keywordJudul = Console.ReadLine();
                if(keywordJudul != "")
                {
                    continue;
                }
            }
            while (keywordJudul == "");
            //Coding untuk search berdasarkan judul
        }

        public static void tampilkanBukuPengarang() //Tampilkan buku pengarang tertentu
        {
            string keywordPengarang = "";
            Console.Clear();
            Console.WriteLine("\t\t\t\tList Buku berdasarkan pengarang");
            Console.WriteLine("\t\t\t\t===============================\n");
            Console.Write("Masukkan nama pengarang:");
            do
            {
                keywordPengarang = Console.ReadLine();
                if (keywordPengarang != "")
                {
                    continue;
                }
            }
            while (keywordPengarang == "");
            //Coding untuk search berdasarkan pengarang
        }
        
        public static void tampilkanBukuPinjam()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\tList Buku yang dipinjam");
            Console.WriteLine("\t\t\t\t=======================\n");

            //codingan listing buku yang dipinjam

            Console.WriteLine("Klik sembarang untuk kembali ke menu buku...");
            Console.ReadKey();
            MainBuku();
        }
    }
}
