using System;
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
            menuBuku();
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
    }
}
