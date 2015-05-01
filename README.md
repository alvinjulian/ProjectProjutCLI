# Project Projut Console - Sistem Perpustakaan


Tugas 1 Pemrograman Lanjut - Sistem Perpustakaan

Disiapkan yang GUI dan CLI. (Logic sama cuma beda dikit)

Segala perubahan yang dilakukan di dalam github harap dituliskan ke file ini agar dapat dikembangkan dengan jauh lebih mudah. Trims

Bug list :
- 
-
-
-
-
-
-

Done : 
- Menu Utama, Murid dan Buku udah jadi
-
-
-
-
-
-
-


Kerja kelompok (3 orang), tanggal kumpul 19 Mei 2015 pukul 23.55. File yang dikumpulkan ada 6: library.cpp, book.cpp, student.cpp, book.h, dan student.h. File yang terakhir adalah contoh input kalian untuk mengetes apakah semua aspek program berjalan sempurna. Namakan file input.txt.Kalau telat sehari, nilai dipotong menjadi 50%.

Buatlah sebuah sistem perpustakaan yang berisi buku, mahasiswa, dan sistem peminjaman. Sebelum program dimulai, baca 2 file terlebih dahulu book.txt dan student.txt.

 

Data dari buku.txt (Setiap kolom dipisahkan dengan tab dan tab bisa lebih dari satu di file supaya rapi seperti contoh di bawah dan diurutkan dari abjad judul) adalah

Judul Buku    Pengarang       Edisi           Tanggal Kembali                      NIM Peminjam


C++ Concurrency in Action   Anthony Williams       1          -           -

C++ Primer        Stanley Lippman, Josée Lajoie, Barbara Moo         5          26 April 2015  100020

C++ Programming Language Bjarne Stroustrup        4          21 Mei 2015                100025

Dari contoh di atas buku C++ Concurrency in Action tidak dipinjam jadi masih di perpustakaan. Sedangkan buku-buku yang lain lagi dipinjam. Buku C++ Primer dipinjam oleh mahasiswa dengan NIM 100020 dan sudah terlambat dikembalikan dibandingkan dengan tanggal hari ini (tanggal apa saja ketika program kalian dijalankan). Buku C++ Programming Language sedang dipinjam oleh mahasiswa dengan NIM 100025 dan tanggal kembalinya adalah 21 Mei.

Data dari student.txt (Setiap kolom dipisahkan juga dengan tab dan diurutkan berdasarkan NIM) adalah

NIM                            Nama                          Jenis Kelamin            Email

100001                        Leo Gunawan             L                                  l4545@hotmail.com

100002                        Fiona Alberto              P                                  fiona_al@gmail.com

Data di atas jelas bahwa Leo adalah murid laki-laki dan Fiona murid wanita.

Untuk menu mahasiswa:

    Untuk menambah mahasiswa, NIM harus unik. NIM terdiri dari 6 digit angka. Semua data yang lain harus lengkap. Jenis kelamin hanya L atau P.

Untuk menu buku:

    Buku yang sama tidak dapat ditambahkan kecuali edisi yang berbeda
    Data judul, pengarang dan edisi harus ada
    Kalau mencari buku dengan pengarang tertentu misalnya “Moo” maka semua buku oleh pengarang yang ada nama “Moo” harus ditampilkan. User juga bisa memasukkan nama lengkap seperti “Barbara Moo”. Untuk tugas ini, kita hanya menggunakan satu pengarang saja.
    Untuk mencari buku berdasarkan judul, misalnya “C++”, maka semua judul buku yang ada judul “C++” harus ditampilkan. Untuk tugas ini, kita hanya menggunakan satu keyword saja.

Untuk sistem peminjaman:

    Seorang murid maksimum hanya boleh meminjam 5 buku.
    Kalau ada salah satu buku yang dipinjam belum dikembalikan setelah lewat tanggal kembali seperti murid dengan NIM 100020 di atas, maka mahasiswa tersebut juga tidak boleh meminjam buku yang lain lagi sampai dikembalikan.
    Sebuah buku yang belum dikembalikan tidak bisa dipinjam oleh mahasiswa lain.
    Kalau sebuah buku sudah dikembalikan dan kalau didenda sudah dibayar, maka tanggal kembali dan NIM peminjam bisa dihapus dan buku bisa dipinjam untuk orang lain. Kalau buku itu belum dipinjam orang lain dan kita sudah keluar dari sistem maka record yang ditulis untuk contoh C++ Primer adalah:

C++ Primer        Stanley Lippman, Josée Lajoie, Barbara Moo         5  -  -

Kalau buku setelah dikembalikan dipinjam oleh mahasiswa lain, maka saat menutup program, record yang ditulis adalah tanggal kembali dan NIM yang baru. Misalnya kalau buku dipinjam oleh mahasiswa dengan NIM 100028.

C++ Primer        Stanley Lippman, Josée Lajoie, Barbara Moo         5  30 Mei 2015            100028

    Waktu pinjam sebuah buku adalah 21 hari dari tanggal hari ini (contoh di file book.txt dengan tanggal kembali lebih dari 21 hari hanya contoh untuk mengecek apakah buku sudah overdue dari tanggal tugas dikumpulkan)

 Jadi kalau buku dipinjam tanggal 27 April 2015, maka tanggal kembali adalah 18 Mei 2015. Kalau tanggal hari itu 19 Mei maka buku sudah telah 1 hari, 20 Mei telat 2 hari dan selanjutnya. Denda per hari 3000 rupiah.

Setelah program selesai, data-data murid dan mahasiswa yang baru setelah transaksi peminjaman atau pengembalian buku diupdate ke file book.txt dan student.txt dan diurutkan berdasarkan judul buku dan NIM.

Waktu program dirun, akan keluar untuk Menu Utama

    Menu Murid
    Menu Buku
    Menu Peminjaman
    Exit

Kalau user memasukkan pilihan lain harap keluarkan error message dan kembali ke menu yang memanggil sebelumnya.

 

Menu Murid

    Tampilkan semua murid
    Tampikan murid laki-laki
    Tampilkan murid wanita
    Tambah murid
    Kembali ke main menu

Menu tambah murid

    Masukkan data
    Kembali ke menu murid

Menu masukkan data:

Masukkan NIM:

Masukkan Nama:

Masukkan Jenis Kelamin:

Masukkan Email:

Kalau NIM atau Email tidak valid, diharapkan memasukkan yang valid. NIM yang valid terdiri dari angka 6 digit. Email yang valid terdiri dari huruf, angka dan underscore dan ada kata @ plus domain email

Menu Buku

    Tampilkan semua buku
    Tampilkan buku yang bisa dipinjam
    Tampilkan buku dengan judul tertentu
    Tampilkan buku dengan pengarang tertentu
    Kembali ke main menu

 

Untuk menampilkan buku, NIM peminjam dan tanggal kembali tidak perlu ditampilkan.  Unutk mencari buku dengan judul dan pengarang tertentu, semua buku ditampilkan biarpun buku tersedia atau tidak.

Untuk menu tampilkan buku dengan judul tertentu

Masukkan kata-kata judul buku:

Kalau buku tidak ada, harap laporkan ke user “Buku dengan judul [kata-kata yang digunakan] tidak ada”.

Untuk menu tampilkan buku dengan pengarang tertentu

Masukkan nama pengarang:

Kalau buku tidak ada, harap laporkan ke user “Buku dengan pengarang [nama pengarang yang dimasukkan] tidak ada”.

Menu Peminjaman

    Pinjam buku
    Lihat buku yang overdue
    Tagih buku yang overdue
    Tagih mahasiswa tertentu
    Kembali buku
    Kembali ke main menu

Untuk menu pinjam buku:

Masukkan judul buku:

Masukkan edisi:

Kalau buku lagi dipinjam laporkan “Buku tidak bisa dipinjam karena lagi dipinjam orang lain” dan kembali ke menu peminjaman.

Masukkan NIM mahasiswa:

Kalau tidak ada mahasiswa dengan NIM tersebut laporkan “Tidak ada mahasiswa dengan NIM [NIM]” Kalau mahasiswa sudah meminjam 5 buku maka laporkan “Maaf mahasiswa ini sudah meminjam 5 buku”. Kalau ada buku yang terlambat dikembalikan,  laporkan “Maaf, mahasiswa ini ada buku yang sudah overdue belum dikembalikan.” Tanggal kembali otomatis 21 hari dari hari ini (tanggal program di-run). Setelah transaksi selesai, laporkan

 

Judul Buku   Pengarang       Edisi        Tanggal Kembali                  NIM Peminjam

 

Untuk menu buku overdue, tampilkan semua buku yang tanggal kembalinya lebih awal dari hari ini (tanggal program di-run).

Untuk menu tagih buku, tampilkan

Nama Murid  Email  Buku yang dipinjam            Jumlah denda

Buku yang dipinjam bisa lebih dari satu, bisa dipisah dengan koma atau tulis di garis baru kolom yang sama. Jumlah denda adalah akumulasi dari jumlah buku dan jumlah hari.

Untuk menu tagih mahasiswa tertentu:

Masukkan NIM mahasiswa:

Kalau tidak ada mahasiswa dengan NIM tersebut laporkan “Tidak ada mahasiswa dengan NIM [NIM]”. Kalau ada, laporkan

Nama Murid  Email  Buku yang dipinjam            Jumlah denda

Tapi hanya untuk mahasiswa tersebut. Sesudah kita run menu ini, maka kita anggap mahasiswa ini sudah membayar denda dan mengembalikan buku.

Untuk menu kembali buku.

Masukkan judul buku:

Masukkan edisi:

Kalau buku tidak ada di database, laporkan “Tidak ada buku dengan judul [judul] dan edisi [edisi] ini.”  Atau kalau buku sedang tidak dipinjam, laporkan “Buku dengan judul [judul] dan edisi [edisi] ini sedang tidak dipinjam.”

