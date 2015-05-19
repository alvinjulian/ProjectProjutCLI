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
            int pilihBukuMenu = 0;
            bool kondisi;
            string pilih;

            do
            {
                menuBuku();
                Console.Write("Masukan pilihan anda : ");
                //pilihBukuMenu = Convert.ToInt16(Console.ReadLine());
                pilih = Console.ReadLine();
                Program.inputlog(pilih);
                kondisi = int.TryParse(pilih, out pilihBukuMenu);
                if (kondisi==true && pilihBukuMenu > 0 && pilihBukuMenu < 7)
                {
                    continue;
                }
                Console.WriteLine("Pilihan yang anda masukan salah!");
                Console.WriteLine("Tekan sembarang untuk memilih kembali...");
                Console.ReadLine();
            } while (pilihBukuMenu < 1 || pilihBukuMenu > 6);

            switch (pilihBukuMenu)
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
                case 5:
                    masukBuku();
                    break;
                case 6:
                    Program.Main();
                    break;
            }
            
        }



        public static void menuBuku()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t\t\tMenu Buku");
            Console.WriteLine("\t\t\t\t\t\t\t\t=========\n");
            Console.WriteLine("1. Tampilkan semua buku\n");
            Console.WriteLine("2. Tampilkan buku yang dipinjam\n");
            Console.WriteLine("3. Tampilkan buku dengan judul tertentu\n");
            Console.WriteLine("4. Tampilan buku dengan pengarang tertentu\n");
            Console.WriteLine("5. Tambah Buku\n");
            Console.WriteLine("6. Kembali ke menu utama\n");
            
        }


        public static void tampilkanBukuS() //Tampilkan semua buku
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t\t\tList Buku");
            Console.WriteLine("\t\t\t\t\t\t\t\t=========\n");

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
            Console.WriteLine("\t\t\t\t\t\t\t\tList Buku berdasarkan judul");
            Console.WriteLine("\t\t\t\t\t\t\t\t===========================\n");
            
            do
            {
                Console.Write("Masukkan kata-kata judul buku:");
                keywordJudul = Console.ReadLine();
                Program.inputlog(keywordJudul);
                if(keywordJudul != "")
                {
                    continue;
                }
                Console.WriteLine("Kata kunci judul tidak valid!..");
                Console.WriteLine("Tekan sembarang untuk memasukan kata kunci....");
                Console.ReadLine();
            }
            while (keywordJudul == "");
            //Coding untuk search berdasarkan judul
            lookJudul(keywordJudul);
            Console.Write("Klik sembarang untuk kembali ke menu buku...");
            Console.ReadLine();
            MainBuku();
        }

        public static void tampilkanBukuPengarang() //Tampilkan buku pengarang tertentu
        {
            string keywordPengarang = "";
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t\t\tList Buku berdasarkan pengarang");
            Console.WriteLine("\t\t\t\t\t\t\t\t===============================\n");
            Console.Write("Masukkan nama pengarang:");
            do
            {
                keywordPengarang = Console.ReadLine();
                Program.inputlog(keywordPengarang);
                Console.WriteLine();
                if (keywordPengarang != "")
                {
                    continue;
                }
                Console.WriteLine("Kata kunci judul tidak valid!..");
                Console.WriteLine("Tekan sembarang untuk memasukan kata kunci....");
                Console.ReadLine();
            }
            while (keywordPengarang == "");
            lookPengarang(keywordPengarang);
            Console.Write("Klik sembarang untuk kembali ke menu buku...");
            Console.ReadLine();
            MainBuku();
        }
        
        public static void tampilkanBukuPinjam()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t\t\tList Buku yang dipinjam");
            Console.WriteLine("\t\t\t\t\t\t\t\t=======================\n");

            //codingan listing buku yang dipinjam
            lookPinjam();
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
                        Console.WriteLine("ID Buku\t\t:\t{0}", result[0]);
                        Console.WriteLine("Nama buku\t:\t{0}", result[1]);
                        Console.WriteLine("Pengarang buku\t:\t{0}", result[2]);
                        Console.WriteLine("Edisi buku\t:\t{0}", result[3]);
                        Console.WriteLine("Tanggal Kembali\t:\t{0}", result[4]);
                        Console.WriteLine("NIM Peminjam\t:\t{0}", result[5]);
                Console.WriteLine();
                //Console.Read();
                //Console.WriteLine(line);
                counter++;
            }

            Console.WriteLine("Total buku terdaftar : {0}", counter);

            sr.Close();
        }

        static void lookJudul(string s)
        {
            string line;
            int counter = 0;

            string pattern = @"\t+";

            Regex rgx = new Regex(pattern);

            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string file = dir + @"\book.txt";
            StreamReader sr = new StreamReader(file);

            while ((line = sr.ReadLine()) != null)
            {
                string[] result = rgx.Split(line);

                //string uji = result[0];

                    if (Regex.IsMatch(result[1], s, RegexOptions.IgnoreCase))
                    {
                        Console.WriteLine("ID Buku\t\t:\t{0}", result[0]);
                        Console.WriteLine("Nama buku\t:\t{0}", result[1]);
                        Console.WriteLine("Pengarang buku\t:\t{0}", result[2]);
                        Console.WriteLine("Edisi buku\t:\t{0}", result[3]);
                        Console.WriteLine("Tanggal Kembali\t:\t{0}", result[4]);
                        Console.WriteLine("NIM Peminjam\t:\t{0}", result[5]);
                        Console.WriteLine();
                        counter++;
                    }
            }
            if(counter == 0)
            {
                Console.WriteLine("Buku yang dimaksud tidak terdaftar!");
            }
            else
            {
                Console.WriteLine("Jumlah buku sesuai kata kunci : {0}", counter);
            }
            sr.Close();
        }

        static void lookPengarang(string s)
        {
            string line;
            int counter = 0;

            string pattern = @"\t+";

            Regex rgx = new Regex(pattern);

            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string file = dir + @"\book.txt";
            StreamReader sr = new StreamReader(file);

            while ((line = sr.ReadLine()) != null)
            {
                string[] result = rgx.Split(line);

                //string uji = result[0];

                if (Regex.IsMatch(result[2], s, RegexOptions.IgnoreCase))
                {
                    Console.WriteLine("ID Buku\t\t:\t{0}", result[0]);
                    Console.WriteLine("Nama buku\t:\t{0}", result[1]);
                    Console.WriteLine("Pengarang buku\t:\t{0}", result[2]);
                    Console.WriteLine("Edisi buku\t:\t{0}", result[3]);
                    //Console.WriteLine("Tanggal Kembali\t:\t{0}", result[4]);
                    //Console.WriteLine("NIM Peminjam\t:\t{0}", result[5]);
                    Console.WriteLine();
                    counter++;
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("Pengarang buku yang dimaksud tidak terdaftar!");
            }
            else
            {
                Console.WriteLine("Jumlah buku sesuai kata kunci : {0}", counter);
            }
			sr.Close();
        }

        static void lookPinjam()
        {
            string line;
            int counter = 0;

            //string s = "-";

            string pattern = @"\t+";

            Regex rgx = new Regex(pattern);

            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string file = dir + @"\book.txt";
            StreamReader sr = new StreamReader(file);

            while ((line = sr.ReadLine()) != null)
            {
                string[] result = rgx.Split(line);

                //string uji = result[0];

                //if (Regex.IsMatch(result[4], s, RegexOptions.IgnoreCase))
                if(result[4]!="-" && result[5]!="")
                {
                    Console.WriteLine("ID Buku\t\t:\t{0}", result[0]);
                    Console.WriteLine("Nama buku\t:\t{0}", result[1]);
                    Console.WriteLine("Pengarang buku\t:\t{0}", result[2]);
                    Console.WriteLine("Edisi buku\t:\t{0}", result[3]);
                    //Console.WriteLine("Tanggal Kembali\t:\t{0}", result[4]);
                    //Console.WriteLine("NIM Peminjam\t:\t{0}", result[5]);
                    Console.WriteLine();
                    counter++;
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("Tidak ada buku yang bisa dipinjam!");
            }
            else
            {
                Console.WriteLine("Jumlah buku yang bisa dipinjam : {0}", counter);
            }
			sr.Close();
        }
        static void cetakFile(string id, string nama, string pengarang, string edisi)
        {
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string file = dir + @"\book.txt";
            //StreamReader sr = new StreamReader(file);
            using (FileStream fs = new FileStream(file, FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(id + "\t" + nama + "\t\t" + pengarang + "\t" + edisi + "\t-\t-");
            }
        }
        public static void masukBuku()
        {

            int cekIDbuku=0;
            string id;
            string judul, pengarang, edisi;
            
            
            do
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t\t\t\t\tMemasukan Buku Baru");
                Console.WriteLine("\t\t\t\t\t\t\t\t=======================\n");
                Console.Write("Masukan ID buku: ");
                id = Console.ReadLine();
                Program.inputlog(id);
                if (cekID(id) == false && id!=""&&id!="\t")
                {
                    cekIDbuku = 1;
                    continue;
                }
                else
                {
                    Console.WriteLine("ID buku yang dimasukan sudah terdaftar atau tidak Valid!");
                    Console.ReadLine();
                }
            } while (cekIDbuku<=0);
            cekIDbuku=0;
            do
            {
                Console.Write("Masukkan judul buku: ");
                judul = Console.ReadLine();
                Program.inputlog(judul);
                if (judul != "" && judul != "\t")
                {
                    cekIDbuku = 1;
                }
                else
                {
                    Console.WriteLine("Judul buku yang dimasukan tidak valid!\n");
                }
            } while (cekIDbuku <= 0);

            cekIDbuku = 0;
            do
            {
                Console.Write("Masukkan pengarang buku: ");
                pengarang = Console.ReadLine();
                Program.inputlog(pengarang);
                if (pengarang != "" && pengarang != "\t")
                {
                    cekIDbuku = 1;
                }
                else
                {
                    Console.WriteLine("Pengarang buku yang dimasukan tidak valid!\n");
                }
            } while (cekIDbuku <= 0);

            cekIDbuku = 0;
            do
            {
                Console.Write("Masukkan edisi buku: ");
                edisi = Console.ReadLine();
                Program.inputlog(edisi);
                if (edisi != "" &&edisi!="\t")
                {
                    cekIDbuku = 1;
                }
                else
                {
                    Console.WriteLine("Pengarang buku yang dimasukan tidak valid!\n");
                }
            } while (cekIDbuku <= 0);

            cetakFile(id,judul,pengarang,edisi);

            Console.Write("Data Buku Berhasil Disimpan!\n");
            Console.Write("Klik sembarang untuk kembali ke menu buku...");
            Console.ReadLine();
            MainBuku();
        }
        public static bool cekID(string nim)
        {
           
            string line;

            string pattern = @"\t+";
            Regex rgx = new Regex(pattern);

            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string file = dir + @"\book.txt";
            StreamReader sr = new StreamReader(file);
            while ((line = sr.ReadLine()) != null)
            {
                string[] result = rgx.Split(line);
                //membuat baris list murid
                if (result[0] == nim)
                {
                    sr.Close();
                    return true;
                }

            }
            sr.Close();
            return false;
        }
    }
}
