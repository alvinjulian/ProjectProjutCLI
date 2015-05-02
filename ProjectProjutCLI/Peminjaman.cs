using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectProjutCLI
{
    class Peminjaman
    {
        public static void MainPeminjaman()
        {
            printmenuPeminjaman();
        }
        static void printmenuPeminjaman()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\tMenu Peminjaman");
            Console.WriteLine("\t\t\t\t===============\n");
            Console.WriteLine("1. Tampilkan semua murid\n");
            Console.WriteLine("2. Tampilkan murid laki-laki\n");
            Console.WriteLine("3. Tampilkan murid perempuan\n");
            Console.WriteLine("4. Tambah murid\n");
            Console.WriteLine("5. Kembali ke menu utama");
        }
    }
}
