using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Threading.Tasks;

namespace ProjectProjutCLI
{
    class Buku
    {
        
        public static void MainBuku()
        {
            int pilih = 0;
            menuBuku();
            do{
                Console.Write("Masukan pilihan anda : ");
                pilih = Convert.ToInt32(Console.ReadLine());
                if(pilih > 0 && pilih < 6)
                {
                    continue;
                }
                Console.WriteLine("Pilihan yang anda masukan salah!");
                Console.WriteLine("Tekan sembarang untuk memilih kembali...");
                Console.ReadLine();
            }while(pilih <1 || pilih >5);
            switch(pilih)
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
            
        }

        public static void tampilkanBukuS() //Tampilkan semua buku
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\tList Buku");
            Console.WriteLine("\t\t\t\t=========\n");

            //Codingan baca dari file atau ambil langsung dri function
            readFilebuku();

            Console.Write("Klik sembarang untuk kembali ke menu buku...");
            Console.ReadLine();
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
            lookJudul(keywordJudul);
            MainBuku();
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

            Console.Write("Klik sembarang untuk kembali ke menu buku...");
            Console.ReadLine();
            MainBuku();
        }

        static void readFilebuku()
        {
            int counter = 0;
            string line;

            string pattern = @"\t+";
            Regex rgx = new Regex(pattern);

            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string file = dir + @"\book.txt";
            StreamReader sr = new StreamReader(file);
            while ((line = sr.ReadLine()) != null)
            {
                string[] result = rgx.Split(line);
                    //Console.WriteLine("{0}", result[ctr]);
                    Console.WriteLine("Nama buku\t:\t{0}", result[0]);
                    Console.WriteLine("Pengarang buku\t:\t{0}", result[1]);
                    Console.WriteLine("Edisi buku\t:\t{0}", result[2]);
                    Console.WriteLine("Tanggal Kembali\t:\t{0}", result[3]);
                    Console.WriteLine("NIM Peminjam\t:\t{0}", result[4]);
                Console.WriteLine();
                //Console.Read();
                //Console.WriteLine(line);
                counter++;
            }
            sr.Close();
        }

        static string lookJudul(string s)
        {
            string line;
            string pattern;

            pattern = s;

            return s;
        }
    }
}
