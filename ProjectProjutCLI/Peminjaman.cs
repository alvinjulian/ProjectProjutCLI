﻿//Made by :
//  Alvin Julian
//  David A. Soborono
//  Kelvin Kristianto
// HCI 2014, Sistem Perpustakaan
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Reflection;
namespace ProjectProjutCLI
{
    class Peminjaman
    {
        public static void MainPeminjaman()
        {
            string pilihPinjamMenu;
            do
            {
                printmenuPeminjaman();
                pilihPinjamMenu = Console.ReadLine();
                Program.inputlog(pilihPinjamMenu);
                //if (pilihPinjamMenu > 0 && pilihPinjamMenu < 7)
                //{
                //    continue;
                //}

                //} while (pilihPinjamMenu < 1 || pilihPinjamMenu > 6);

                switch (pilihPinjamMenu)
                {
                    case "1":
                        pinjamBuku();
                        break;
                    case "2":
                        lihatOverdue();
                        break;
                    case "3":
                        tagihOverdue();
                        break;
                    case "4":
                        tagihMahasiswa();
                        break;
                    case "5":
                        kembaliBuku();
                        break;
                    case "6":
                        Program.Main();
                        break;
                    default:
                        Console.WriteLine("Pilihan yang anda masukan salah!");
                        Console.WriteLine("Tekan sembarang untuk memilih kembali...");
                        Console.ReadLine();
                        break;
                }
            } while (true);
            
        }
        static void printmenuPeminjaman()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t\t\tMenu Peminjaman");
            Console.WriteLine("\t\t\t\t\t\t\t\t===============\n");
            Console.WriteLine("1. Pinjam buku\n");
            Console.WriteLine("2. Lihat buku yang overdue\n");
            Console.WriteLine("3. Tagih buku yang overdue\n");
            Console.WriteLine("4. Tagih mahasiswa tertentu\n");
            Console.WriteLine("5. Kembali buku\n");
            Console.WriteLine("6. Kembali ke menu utama\n");
            Console.Write("Masukan pilihan anda : ");
        }

        static void pinjamBuku()
        {
            int nim;
            string idbuku;
            //string judul;
            //string edisi;
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t\t\tMenu Pinjam Buku");
            Console.WriteLine("\t\t\t\t\t\t\t\t================\n");
            Console.Write("Masukan id buku : ");
            idbuku = Console.ReadLine();
            Program.inputlog(idbuku);
            //mengecek buku bisa dipinjam atau tidak
            if (cekBuku(idbuku) == false)
            {
                Console.WriteLine("Apakah buku ini ingin dipinjam? Y/N ");
                switch (char.ToUpper(Console.ReadKey().KeyChar))
                {
                    case 'Y':
                        Program.inputlog("Y");
                        break;
                    default :
                        // selain Y dianggap N
                        Program.inputlog("N");
                        Console.WriteLine("\nTekan sembarang untuk kembali ke menu peminjaman");
                        Console.ReadLine();
                        MainPeminjaman();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Tekan sembarang untuk kembali ke menu peminjaman");
                Console.ReadLine();
                MainPeminjaman();

            }
            Console.ReadLine();
            //jika buku available       
            do
            {
                Console.Write("\n\nMasukan NIM mahasiswa : ");
                nim = int.Parse(Console.ReadLine());
                Program.inputlog(nim.ToString());
                //dirubah jadi bentuk int diantara 1 jt hinga 999999
                if (nim >= 100000 && nim < 1000000)
                {
                    if (cekNIM2(nim) == true)
                    {
                        continue;
                    }
                    else
                    {
                        //jika nim tidak valid atau sudah pinjam lebih dari 5 buku
                        nim = 0;
                    }

                }
                else
                {
                    //jika nim tidak valid
                    Console.WriteLine("Tidak ada mahaiswa dengan NIM tersebut!\n");
                    nim = 0;
                }

            } while (nim <= 100000 || nim >= 1000000);
            //cek apakah dia ada telat mengembalikan buku atau tidak..
            if(cektanggal(nim)==false)
            {
                Console.Write("\nTekan sembarang untuk kembali ke menu...");
                Console.Read();
                MainPeminjaman();
            }
                //masukin data peminjaman ke dalam file
                DateTime duedate = (DateTime.Today).AddDays(21);
                string due = duedate.ToString("dd/MM/yyyy");
                BookEdit(idbuku,due,nim.ToString(),0);
                copyfile();
                // laporan
                laporanPeminjaman(idbuku);

                Console.WriteLine("\nPeminjaman berhasil!!\n");
                Console.Write("Tekan sembarang untuk kembali ke menu...");
                Console.Read();
                MainPeminjaman();
        }

        static void lihatOverdue()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t\t\tLihat Pinjaman Overdue");
            Console.WriteLine("\t\t\t\t\t\t\t\t======================\n\n");
            lookOverDue();
            

            Console.Write("Tekan sembarang untuk kembali ke menu...");
            Console.Read();
            MainPeminjaman();
        }

        static void tagihOverdue()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t\t\tTagih Pinjaman Overdue");
            Console.WriteLine("\t\t\t\t\t\t\t\t======================\n");
            Console.WriteLine("Apakah semua buku overdue ingin ditagih? Y/N ");
            switch (char.ToUpper(Console.ReadKey().KeyChar))
            {
                case 'Y':
                    Program.inputlog("Y");
                    Console.ReadLine();
                    break;
                default:
                    // selain Y dianggap N
                    Program.inputlog("N");
                    Console.WriteLine("\nPenagihan buku dibatalkan");
                    Console.WriteLine("\nTekan sembarang untuk kembali ke menu peminjaman");
                    Console.ReadLine();
                    MainPeminjaman();
                    break;
            }
            //kode menulis buku yg overdue menjadi dianggap dikembalikan result[4] && result[5]=="-"
            tagihsemua();
            Console.WriteLine("\nPenagihan buku berhasil");
            Console.WriteLine("\nTekan sembarang untuk kembali ke menu peminjaman");
            Console.ReadLine();
            MainPeminjaman();
 
        }

        static void tagihMahasiswa()
        {
            string tagihNIM = "";
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t\t\tTagih Pinjaman Mahasiswa Tertentu");
            Console.WriteLine("\t\t\t\t\t\t\t\t======================\n");
            Console.WriteLine("Masukan NIM Mahasiswa yang ingin ditagih, \nNIM Mahasiswa:");
            tagihNIM = Console.ReadLine();
            Program.inputlog(tagihNIM);
            if (BacaList(tagihNIM) == true)
            {
                Console.WriteLine("Apakah buku ini ingin dikembalikan? Y/N ");
                switch (char.ToUpper(Console.ReadKey().KeyChar))
                {
                    case 'Y':
                        Program.inputlog("Y");
                        Console.ReadLine();
                        break;
                    default:
                        Program.inputlog("N");
                        // selain Y dianggap N
                        Console.WriteLine("\nPengembalian buku dibatalkan");
                        Console.WriteLine("\nTekan sembarang untuk kembali ke menu peminjaman");
                        Console.ReadLine();
                        MainPeminjaman();
                        break;
                }
                //nulis ke file bahwa peminjaman berhasil
                BookEdit(tagihNIM, "-", "-", 5);
                copyfile();

                Console.WriteLine("Pengembalian Buku Berhasil!\n");
            }
            Console.Write("Klik sembarang untuk kembali ke menu peminjaman...");
            Console.ReadLine();
            MainPeminjaman();
        }

        static void kembaliBuku()
        {
            string idbuku;
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t\t\tMenu Kembali Buku");
            Console.WriteLine("\t\t\t\t\t\t\t\t================\n");
            Console.Write("Masukan id buku : ");
            idbuku = Console.ReadLine();
            Program.inputlog(idbuku);
            if (cekBuku2(idbuku) == false)
            {
                Console.WriteLine("Apakah buku ini ingin dikembalikan? Y/N ");
                switch (char.ToUpper(Console.ReadKey().KeyChar))
                {
                    case 'Y':
                        Program.inputlog("Y");
                        Console.ReadLine();
                        break;
                    default:
                        // selain Y dianggap N
                        Program.inputlog("N");
                        Console.WriteLine("\nPengembalian buku dibatalkan");
                        Console.WriteLine("\nTekan sembarang untuk kembali ke menu peminjaman");
                        Console.ReadLine();
                        MainPeminjaman();
                        break;
                }
                /////// koding mengganti tanggal peminjam  menjadi "-",
                BookEdit(idbuku,"-","-",0);
                copyfile();

                Console.WriteLine("Pengembalian Buku Berhasil!\n");
                Console.WriteLine("\nTekan sembarang untuk kembali ke menu peminjaman");
                Console.ReadLine();
                MainPeminjaman();
            }
            Console.WriteLine("\nTekan sembarang untuk kembali ke menu peminjaman");
            Console.ReadLine();
            MainPeminjaman();
        }

        static bool BacaList(string s)
        {
            string line;
            int counter = 0;
            int dendahari = 3000;//denda apabila telat per hari
            double dendatotal=0.0;
            string pattern = @"\t+";
            Regex rgx = new Regex(pattern);
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string file = dir + @"\book.txt";
            string file1 = dir + @"\student.txt";
            StreamReader sr1 = new StreamReader(file1);
            
            while ((line = sr1.ReadLine()) != null) //buka file student, baca perbaris
            {
                string[] result1 = rgx.Split(line);
                if(result1[0]==s) /// cek apakah nim uda sama dengan yg diminta,kalau ktmu  // kalau gk ada dianggap gk pinjem buku
                {
                    StreamReader sr = new StreamReader(file);
                    while ((line = sr.ReadLine()) != null) ///buka file buku
                    {
                        string[] result = rgx.Split(line);
                        if (Regex.IsMatch(result[5], s, RegexOptions.IgnoreCase)) //kalau ada si peminjam dengan nim itu
                        {
                            //Nama Murid  Email  Buku yang dipinjam            Jumlah denda
                            Console.WriteLine("Nama Murid\t:\t{0}", result1[1]);
                            Console.WriteLine("Email \t\t:\t{0}", result1[3]);
                            Console.WriteLine("ID Buku\t\t:\t{0}", result[0]);
                            Console.WriteLine("Nama buku\t:\t{0}", result[1]);
                            DateTime duedate = Convert.ToDateTime(result[4]);
                            DateTime today = DateTime.Today;
                            //perhitungan denda
                            double denda;
                            denda = (-1 * ((duedate - today).TotalDays)) * dendahari;
                            if (denda <= 0)
                            {
                                denda = 0;
                            }
                            Console.WriteLine("Jumlah Denda\t:\tRp.{0}\n", denda);
                            dendatotal = dendatotal + denda;
                            Console.WriteLine();
                            counter++;
                        }
                    } 
                    sr.Close();
                }
                
            }
            
            if (counter == 0)
            {
                Console.WriteLine("NIM yang dimaksud tidak meminjam buku!");
                
                sr1.Close();
                return false;

            }
            else
            {
                Console.WriteLine("Total Denda\t\t:\tRp.{0}\n", dendatotal);
                Console.WriteLine("Jumlah buku yang dipinjam : {0}", counter);
                
                sr1.Close();
                return true;
            }
            
        }

        public static bool cekBuku(string id) //cek buku apakah sudah ada yg pinjam atau tidak, buad menu pinjam buku
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
                //mengecek apakah idbuku benar
                if (result[0] == id)
                {
                    counter++;
                    //mengecek apakah ada yang pinjam
                    if (result[4] != "-" && result[5] != "-")
                    {
                        Console.WriteLine("Buku sudah ada yang pinjam!\n");
                        sr.Close();
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Judul Buku\t:\t{0}\n", result[1]);
                        Console.WriteLine("Edisi Buku\t:\t{0}\n\n", result[3]);
                    }
                }
            }
            if (counter <= 0)
            {
                Console.WriteLine("Id Buku tidak terdaftar!\n");
                sr.Close();
                return true;
            }
            else
            {
                sr.Close();
                return false;
            }
        }

        public static bool cekNIM2(int nimcek) //cek kketersedian nim yg mau pinjam
        {
            string nim;
            nim = nimcek.ToString();
            string line;
            string pattern = @"\t+";
            Regex rgx = new Regex(pattern);
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string file = dir + @"\student.txt";
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
            //kalau nim tak terdaftar
            Console.WriteLine("Tidak ada mahaiswa dengan NIM tersebut!\n");
            sr.Close();
            return false;
        }
        public static bool cektanggal(int nimcek) //cek nim, apakahh nim tersebut ada overdue peminjaman buku
        {
            string nim;
            nim = nimcek.ToString();
            
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
                //mengecek apakah nim pernah pinjam buku atau tidak
                if (result[5] == nim)
                {
                    counter++;
                    DateTime duedate= Convert.ToDateTime(result[4]);
                    DateTime today= DateTime.Today;
                    if ((duedate - today).TotalDays < 0)
                    {
                        //kalau lewad due
                        Console.WriteLine("Maaf, mahasiswa ini ada buku yang sudah overdue belum dikembalikan");
                        sr.Close();
                        return false;
                    }
                }
            }
            if (counter >= 5)
            {
                //kalau pinjam lebih dari 5 buku

                Console.WriteLine("Maaf mahasiswa ini sudah meminjam 5 buku");
                sr.Close();
                return false;
            }
            else
            {
                sr.Close();
                return true;
            }
        }

        static void lookOverDue() // membaca dan melihat buku yang overdue dan dibuat list
        {
            string line;
            int counter = 0;
            string pattern = @"\t+";
            int dendahari = 3000;//denda apabila telat per hari
            Regex rgx = new Regex(pattern);
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string file = dir + @"\book.txt";
            string file1 = dir + @"\student.txt";
            StreamReader sr = new StreamReader(file);
            while ((line = sr.ReadLine()) != null)
            {
                string[] result = rgx.Split(line);
                if (result[4] != "-")
                {
                    DateTime duedate = Convert.ToDateTime(result[4]);
                    DateTime today = DateTime.Today;
                    if ((duedate - today).TotalDays < 0)
                    {
                        StreamReader sr1 = new StreamReader(file1);
                        while ((line = sr1.ReadLine()) != null) //buka file student, baca perbaris
                        {
                            string[] result1 = rgx.Split(line);
                            if (result[5] == result1[0])
                            {
                                Console.WriteLine("Nama Murid\t:\t{0}", result1[1]);
                                Console.WriteLine("Email \t\t:\t{0}", result1[3]);
                                Console.WriteLine("ID Buku\t\t:\t{0}", result[0]);
                                Console.WriteLine("Nama buku\t:\t{0}", result[1]);
                                //perhitungan denda
                                double denda;
                                denda = (-1 * ((duedate - today).TotalDays)) * dendahari;
                                Console.WriteLine("Jumlah Denda\t:\tRp.{0}\n", denda);
                                Console.WriteLine();
                                counter++;
                            }
                        }
                        sr1.Close();
                    }
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("Tidak ada buku yang overdue!");
            }
            else
            {
                Console.WriteLine("Jumlah buku yang overdue : {0}", counter);
            }
            sr.Close();
            
        }

        public static bool cekBuku2(string id) //cek buku apakah sudah ada yg pinjam, untuk dikembalikan
        {
            string line;
            int counter = 0;
            string pattern = @"\t+";
            Regex rgx = new Regex(pattern);
            int dendahari = 3000;//denda apabila telat per hari
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string file = dir + @"\book.txt";
            StreamReader sr = new StreamReader(file);
            while ((line = sr.ReadLine()) != null)
            {
                string[] result = rgx.Split(line);
                //mengecek apakah idbuku benar
                if (result[0] == id)
                {
                    counter++;
                    //mengecek apakah ada yang pinjam
                    if (result[4] != "-" && result[5] != "-")
                    {
                        DateTime duedate = Convert.ToDateTime(result[4]);
                        DateTime today = DateTime.Today;
                        //perhitungan denda
                        double denda;
                        denda = (-1 * ((duedate - today).TotalDays)) * dendahari;

                        Console.WriteLine("Judul Buku\t:\t{0}\n", result[1]);
                        Console.WriteLine("Edisi Buku\t:\t{0}\n", result[3]);
                        Console.WriteLine("Peminjam \t:\t{0}\n", result[5]);
                        if(denda<=0)
                        {
                            denda = 0;
                        }
                        Console.WriteLine("Denda\t\t:\tRp.{0}\n\n", denda);
                        sr.Close();
                        return false;
                    }
                }
            }
            if (counter <= 0)
            {
                Console.WriteLine("Id Buku tidak terdaftar!\n");
                sr.Close();
                return true;
            }
            else
            {
                sr.Close();
                Console.WriteLine("Buku tak ada yang pinjam!\n");
                return true;
            }
        }

        static void copyfile() //untuk copy isi file dan delete
        {
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string file = dir + @"\bookcp.txt";
            string target = dir + @"\book.txt";
            //copy file di folder yg sama.. hati2 penamaanya yaa
            System.IO.File.Copy(file, target, true);

            //delete cp nya sekarang
            File.Delete(file);
            // Keep console window open in debug mode.
            //Console.WriteLine("Press any key to exit.");
            //Console.ReadKey();
        }

        static void BookEdit(string idbuku,string tanggal,string nimpinjam,int check) //mengganti tanggal dan nim peminjam
        {
            string line;
            string pattern = @"\t+";
            Regex rgx = new Regex(pattern);
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string file = dir + @"\book.txt";
            string filecp = dir + @"\bookcp.txt";
            StreamReader sr = new StreamReader(file);
            while ((line = sr.ReadLine()) != null)
            {
                string[] result = rgx.Split(line);
                //mengecek apakah idbuku benar, lalu duedate dan nim peminjam jadi "-" lalu masukin ke file
                if (result[check] == idbuku)
                {
                   result[4]=tanggal;
                   result[5]=nimpinjam;
                   if (!File.Exists(filecp))
                   {
                       // Create a file to write to. kalau belom ada filenya 
                       using (StreamWriter swnew = File.CreateText(filecp))
                       {
                           swnew.WriteLine(result[0] + "\t" + result[1] + "\t" + result[2] + "\t" + result[3] + "\t" + result[4] + "\t" + result[5]);
                       }
                   }
                   //kalau ud ada file yang mau ditulis
                   else
                   {
                       using (FileStream fs = new FileStream(filecp, FileMode.Append, FileAccess.Write))
                       using (StreamWriter sw = new StreamWriter(fs))
                       {
                           sw.WriteLine(result[0] + "\t" + result[1] + "\t" + result[2] + "\t" + result[3] + "\t" + result[4] + "\t" + result[5]);
                       }
                   } 
                }
                else
                {
                    if (!File.Exists(filecp))
                    {
                        // Create a file to write to. kalau belom ada filenya 
                        using (StreamWriter swnew = File.CreateText(filecp))
                        {
                            swnew.WriteLine(result[0] + "\t" + result[1] + "\t" + result[2] + "\t" + result[3] + "\t" + result[4] + "\t" + result[5]);
                        }
                    }
                    //kalau ud ada file yang mau ditulis
                    else
                    {
                        using (FileStream fs = new FileStream(filecp, FileMode.Append, FileAccess.Write))
                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            sw.WriteLine(result[0] + "\t" + result[1] + "\t" + result[2] + "\t" + result[3] + "\t" + result[4] + "\t" + result[5]);
                        }
                    }
                }
             }
            sr.Close();
            
          }

        static void laporanPeminjaman(string s)
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

                //string uji = result[0];

                if (Regex.IsMatch(result[0], s, RegexOptions.IgnoreCase))
                {
                    Console.WriteLine("ID Buku\t\t:\t{0}", result[0]);
                    Console.WriteLine("Nama buku\t:\t{0}", result[1]);
                    Console.WriteLine("Pengarang buku\t:\t{0}", result[2]);
                    Console.WriteLine("Edisi buku\t:\t{0}", result[3]);
                    Console.WriteLine("Tanggal Kembali\t:\t{0}", result[4]);
                    Console.WriteLine("NIM Peminjam\t:\t{0}", result[5]);
                   
                }
            }
            sr.Close();
        }

        static void tagihsemua()
        {
            string line;
            int counter = 0;
            string pattern = @"\t+";
            Regex rgx = new Regex(pattern);
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string file = dir + @"\book.txt";
            string file1 = dir + @"\student.txt";
            StreamReader sr = new StreamReader(file);
            while ((line = sr.ReadLine()) != null)
            {
                string[] result = rgx.Split(line);
                if (result[4] != "-")
                {
                    DateTime duedate = Convert.ToDateTime(result[4]);
                    DateTime today = DateTime.Today;
                    if ((duedate - today).TotalDays < 0)
                    {
                        StreamReader sr1 = new StreamReader(file1);
                        while ((line = sr1.ReadLine()) != null) //buka file student, baca perbaris
                        {
                            string[] result1 = rgx.Split(line);
                            if (result[5] == result1[0])
                            {
                                //nulis ke file bahwa sudah dikembalikan
                                BookEdit(result[0], "-", "-", 0);
                                sr.Close();
                                //dicopy dan delete yg bookcp.txt
                                copyfile();
                                sr = new StreamReader(file);
                                counter++;
                            }
                        }
                        sr1.Close();
                    }
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("Tidak ada buku yang overdue!");
            }
            else
            {
                Console.WriteLine("Jumlah buku yang overdue yang dikembalikan : {0}", counter);

            }
            sr.Close();
        }
    
    }

}
