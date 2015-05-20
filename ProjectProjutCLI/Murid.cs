//Made by :
//  Alvin Julian
//  David A. Soborono
//  Kelvin Kristianto
// HCI 2014, Sistem Perpustakaan
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectProjutCLI
{
    class Murid
    {
        public static void MainMurid()
        {
            string pilihMuridMenu;

            do
            {
                printmenuMurid();
                pilihMuridMenu = Console.ReadLine();
                Program.inputlog(pilihMuridMenu);
                Program.inputlog(pilihMuridMenu);
                switch (pilihMuridMenu)
                {
                    case "1":
                        tampilkanMurids();
                        break;
                    case "2":
                        tampilkanMuridL();
                        break;
                    case "3":
                        tampilkanMuridP();
                        break;
                    case "4":
                        menuTambahmurid();
                        break;
                    case "5":
                        Program.Main();
                        break;
                    default :
                        Console.WriteLine("Pilihan yang anda masukan salah!");
                        Console.WriteLine("Tekan sembarang untuk memilih kembali...");
                        Console.ReadLine();
                        break;
                }
            } while (true);
        }

        static void printmenuMurid()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t\t\tMenu Murid");
            Console.WriteLine("\t\t\t\t\t\t\t\t==========\n");
            Console.WriteLine("1. Tampilkan semua murid\n");
            Console.WriteLine("2. Tampilkan murid laki-laki\n");
            Console.WriteLine("3. Tampilkan murid perempuan\n");
            Console.WriteLine("4. Tambah murid\n");
            Console.WriteLine("5. Kembali ke menu utama\n");
            Console.Write("Masukan pilihan anda : ");
        }

        static void menuTambahmurid()
        {
            string pilihan;
            do
            {
                printmenuTambahmurid();
                pilihan = Console.ReadLine();
                Program.inputlog(pilihan);
                switch (pilihan)
                {
                    case "1":
                        menuMasukanmurid();
                        break;
                    case "2":
                        MainMurid();
                        break;
                    default:
                        Console.WriteLine("Pilihan yang anda masukan salah!");
                        Console.WriteLine("Tekan sembarang untuk memilih kembali...");
                        Console.ReadLine();
                        break;
                }
            } while (true);
        }

        static void printmenuTambahmurid()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t\tMenu Murid");
            Console.WriteLine("\t\t\t\t\t\t\t==========\n");
            Console.WriteLine("1. Masukan data murid\n");
            Console.WriteLine("2. Kembali ke menu utama\n");
            Console.Write("Masukan pilihan anda : ");
        }

        static void menuMasukanmurid()
        {
            //ud ada struct diatas
            int nim;
            string nama;
            char jenisK;
            string email;
            string inputnim;
            bool kondisiNIM;
            do
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t\t\t\tMasukan Data Murid");
                Console.WriteLine("\t\t\t\t\t\t\t==================\n");            
                Console.Write("Masukan NIM : ");
                inputnim = Console.ReadLine();
                Program.inputlog(inputnim);
                kondisiNIM = int.TryParse(inputnim, out nim);
                //dirubah jadi bentuk int diantara 1 jt hingga 999999
                if (kondisiNIM == true && nim >= 100000 && nim < 1000000)
                {
                    if (cekNIM(nim) == false)
                    {
                        continue;
                    }
                    else 
                    {
                        Console.WriteLine("NIM sudah terdaftar!\n");
                        //untuk membuat mengulang memasukan NIM lagi
                        nim = 0;
                    }

                }
                else
                {
                    Console.WriteLine("NIM harus 6 digit angka!\n");
                }
                Console.ReadLine();
            } while (nim <= 100000 || nim >= 1000000);
            int namabatas = 0;
            do
            {
                Console.Write("Masukan Nama : ");
                nama = Console.ReadLine();
                Program.inputlog(nama);
                if (IsDigitsOnly(nama) == true && nama!="" && nama.Length<=55)
                {
                    namabatas = 1;
                    continue;
                }
                Console.WriteLine("Nama tidak valid!");
            } while (namabatas<=0 );
            ///memasukan jenis kelamin 
            do
            {
                Console.Write("Masukan Jenis Kelamin (L/P) : ");
                jenisK = Console.ReadKey().KeyChar;
                Program.inputlog(jenisK.ToString());
                jenisK = char.ToUpper(jenisK);
                Console.WriteLine();
                switch (jenisK)
                {
                    case 'L':
                        continue;

                    case 'P':
                        continue;

                    default:
                        jenisK = ' ';
                        break;
                }
            } while (jenisK == ' ');

            do
            {
                Console.Write("Masukan Email : ");
                email = Console.ReadLine();
                Program.inputlog(email);
                if (emailIsValid(email) == true)
                {
                    continue;
                }
                Console.WriteLine("Email Tidak Valid!\n");
            } while (emailIsValid(email) == false);

            //codingan nulis ke file
            cetakData(nim, nama, jenisK, email);
            // langsung disorting
            Sorting.sortingNIM();

            Console.WriteLine("\n\nData berhasil disimpan! Tekan sembarang tombol untuk kembali....");
            Console.ReadLine();
            MainMurid();
        }

        public static bool emailIsValid(string email)
        {
            string expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static bool IsDigitsOnly(string str)
        {
            {
                return Regex.IsMatch(str, @"^[a-zA-Z]+$");
            }
        }

        static void tampilkanMurids()
        {
            //method untuk tampilkan semua murid
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t\tList Murid");
            Console.WriteLine("\t\t\t\t\t\t\t=========\n");
            Console.WriteLine("\t\t\tNo.\tNIM\tNama\t\t\t\t\t\t\tGender\tEmail\n\n");
            //Codingan baca dari file atau ambil langsung dri function
            //readFilemurid();
            splitString();

            Console.Write("\n\n\t\t\t\t\t\t\tKlik sembarang untuk kembali ke menu murid...");
            Console.ReadLine();
            MainMurid();
        }

        static void tampilkanMuridL()
        {
                       
            Console.Clear();
            string Kelamin = "L";
            Console.WriteLine("\t\t\t\t\t\t\tList Murid Laki-Laki");
            Console.WriteLine("\t\t\t\t\t\t\t====================\n");
            Console.WriteLine("\t\t\tNo.\tNIM\tNama\t\t\t\t\t\t\tGender\tEmail\n\n");
            //method untuk tampilkan murid laki
            filterKelamin(Kelamin);
            Console.Write("\n\n\t\t\t\t\t\t\tKlik sembarang untuk kembali ke menu murid...");
            Console.ReadLine();
            MainMurid();
        }

        static void tampilkanMuridP()
        {
            
            Console.Clear();
            string Kelamin = "P";
            Console.WriteLine("\t\t\t\t\t\t\tList Murid Perempuan");
            Console.WriteLine("\t\t\t\t\t\t\t====================\n");
            Console.WriteLine("\t\t\tNo.\tNIM\tNama\t\t\t\t\t\t\tGender\tEmail\n\n");
            //method untuk tampilakn murid perempuan
            filterKelamin(Kelamin);
            Console.Write("\n\n\t\t\t\t\t\t\tKlik sembarang untuk kembali ke menu murid...");
            Console.ReadLine();
            MainMurid();
        }

        static void splitString()
        {
            int counter = 0;
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
                if (result[1].Length < 8)
                {
                    Console.WriteLine("\t\t\t{0}.\t{1}\t{2}\t\t\t\t\t\t\t{3}\t\t{4}", counter + 1, result[0], result[1], result[2], result[3]);
                }
                else if (result[1].Length < 16)
                {
                    Console.WriteLine("\t\t\t{0}.\t{1}\t{2}\t\t\t\t\t\t{3}\t\t{4}", counter + 1, result[0], result[1], result[2], result[3]);
                }
                else if (result[1].Length < 24)
                {
                    Console.WriteLine("\t\t\t{0}.\t{1}\t{2}\t\t\t\t\t{3}\t\t{4}", counter + 1, result[0], result[1], result[2], result[3]);

                }
                else if (result[1].Length < 31)
                {
                    Console.WriteLine("\t\t\t{0}.\t{1}\t{2}\t\t\t\t{3}\t\t{4}", counter + 1, result[0], result[1], result[2], result[3]);

                }
                else if (result[1].Length < 39)
                {
                    Console.WriteLine("\t\t\t{0}.\t{1}\t{2}\t\t\t\t{3}\t\t{4}", counter + 1, result[0], result[1], result[2], result[3]);

                }
                else if (result[1].Length < 47)
                {
                    Console.WriteLine("\t\t\t{0}.\t{1}\t{2}\t\t\t{3}\t\t{4}", counter + 1, result[0], result[1], result[2], result[3]);
                }
                else
                {
                    Console.WriteLine("\t\t\t{0}.\t{1}\t{2}\t{3}\t\t{4}", counter + 1, result[0], result[1], result[2], result[3]);
                
                }
               
                    //Console.Read();
                //Console.WriteLine(line);
                counter++;
            }
            sr.Close();

        }
        static void filterKelamin(string Kelamin)
        {
            int counter = 0;
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
                if (result[2] == Kelamin)
                {
                    if (result[1].Length < 8)
                    {
                        Console.WriteLine("\t\t\t{0}.\t{1}\t{2}\t\t\t\t\t\t\t{3}\t\t{4}", counter + 1, result[0], result[1], result[2], result[3]);
                    }
                    else if (result[1].Length < 16)
                    {
                        Console.WriteLine("\t\t\t{0}.\t{1}\t{2}\t\t\t\t\t\t{3}\t\t{4}", counter + 1, result[0], result[1], result[2], result[3]);
                    }
                    else if (result[1].Length < 24)
                    {
                        Console.WriteLine("\t\t\t{0}.\t{1}\t{2}\t\t\t\t\t{3}\t\t{4}", counter + 1, result[0], result[1], result[2], result[3]);

                    }
                    else if (result[1].Length < 31)
                    {
                        Console.WriteLine("\t\t\t{0}.\t{1}\t{2}\t\t\t\t{3}\t\t{4}", counter + 1, result[0], result[1], result[2], result[3]);

                    }
                    else if (result[1].Length < 39)
                    {
                        Console.WriteLine("\t\t\t{0}.\t{1}\t{2}\t\t\t\t{3}\t\t{4}", counter + 1, result[0], result[1], result[2], result[3]);

                    }
                    else if (result[1].Length < 47)
                    {
                        Console.WriteLine("\t\t\t{0}.\t{1}\t{2}\t\t\t{3}\t\t{4}", counter + 1, result[0], result[1], result[2], result[3]);
                    }
                    else
                    {
                        Console.WriteLine("\t\t\t{0}.\t{1}\t{2}\t{3}\t\t{4}", counter + 1, result[0], result[1], result[2], result[3]);

                    }
                    counter++;
                }
                //Console.Read();
                //Console.WriteLine(line);
                
            }
            sr.Close();
        }

        public static bool cekNIM(int nim)
        {
            string id;
            id = nim.ToString();
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
                if (result[0] == id)
                {
                    sr.Close();
                    return true;
                }

            }
            sr.Close();
            return false;
        }
        static void cetakData(int nim, string nama, char jenisK, string email)
        {
            //string line;
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string file = dir + @"\student.txt";
            //StreamReader sr = new StreamReader(file);
            using (FileStream fs = new FileStream(file, FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(nim + "\t" + nama + "\t\t" + jenisK + "\t" + email);
            }
        }

    }
}
