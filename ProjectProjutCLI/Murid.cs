using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProjectProjutCLI
{
    class Murid
    {
        public static void MainMurid()
        {
            int pilihan = 0;
            do {
                printmenuMurid();
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
                    tampilkanMurids();
                    break;
                case 2:
                    tampilkanMuridL();
                    break;
                case 3:
                    tampilkanMuridP();
                    break;
                case 4:
                    menuTambahmurid();
                    break;
                case 5:
                    Program.Main();
                    break;
            }
        }

        static void printmenuMurid()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\tMenu Murid");
            Console.WriteLine("\t\t\t\t==========\n");
            Console.WriteLine("1. Tampilkan semua murid\n");
            Console.WriteLine("2. Tampilkan murid laki-laki\n");
            Console.WriteLine("3. Tampilkan murid perempuan\n");
            Console.WriteLine("4. Tambah murid\n");
            Console.WriteLine("5. Kembali ke menu utama");
            Console.Write("Masukan pilihan anda : ");
        }

        static void menuTambahmurid()
        {
            int pilihan = 0;
            do{
                printmenuTambahmurid();
                pilihan = int.Parse(Console.ReadLine());
                if(pilihan >0 && pilihan <3)
                {
                    continue;
                }
            } while (pilihan < 1 || pilihan > 2);
            switch(pilihan)
            {
                case 1:
                    menuMasukanmurid();
                    break;
                case 2:
                    MainMurid();
                    break;
                default:
                    break;
            }
        }

        static void printmenuTambahmurid()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\tMenu Murid");
            Console.WriteLine("\t\t\t\t==========\n");
            Console.WriteLine("1. Masukan data murid\n");
            Console.WriteLine("2. Kembali ke menu utama\n");
            Console.Write("Masukan pilihan anda : ");
        }

        static void menuMasukanmurid()
        {
            int nim = 0;
            string nama = "";
            char jenisK = ' ' ;
            string email = "";
            Console.Clear();
            Console.WriteLine("\t\t\t\tMasukan Data Murid");
            Console.WriteLine("\t\t\t\t==================\n");
            do{
                Console.Write("Masukan NIM : ");
                nim = int.Parse(Console.ReadLine());
                //dirubah jadi bentuk int diantara 1 jt hinga 999999
                if(nim>=100000 && nim<1000000)
                {
                    continue;
                }
                Console.WriteLine("NIM harus 6 digit!\n");
            }while(nim<=100000 || nim>=1000000);

            do{
                Console.Write("Masukan Nama : ");
                nama = Console.ReadLine();
                if(IsDigitsOnly(nama)==false)
                {
                    continue;
                }
                Console.WriteLine("Nama tidak valid!");
            }while(IsDigitsOnly(nama)==true);
            ///memasukan jenis kelamin 
            do
            {
                Console.Write("Masukan Jenis Kelamin (L/P) : ");
                jenisK = Console.ReadKey().KeyChar ;
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

            do{
                Console.Write("Masukan Email : ");
                email = Console.ReadLine();
                if(emailIsValid(email)==true)
                {
                    continue;
                }
                Console.WriteLine("Email Tidak Valid!\n");
            }while(emailIsValid(email)==false);

            //codingan nulis ke file

            Console.WriteLine("Data berhasil disimpan! Tekan sembarang tombol untuk kembali....");
            Console.ReadKey();
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
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        static void tampilkanMurids()
        {
            //method untuk tampilkan semua murid
        }

        static void tampilkanMuridL()
        {
            //method untuk tampilkan murid laki
        }

        static void tampilkanMuridP()
        {
            //method untuk tampilakn murid perempuan
        }
    }
}
