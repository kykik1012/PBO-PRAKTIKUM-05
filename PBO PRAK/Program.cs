using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBO_PRAK
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Masukkan Jenis Karyawan: tetap/magang/kontrak ");
            string jenis_karyawan= Console.ReadLine().ToLower();

            Console.WriteLine("Masukkan Nama: ");
            string nama_in = Console.ReadLine();

            Console.WriteLine("Masukkan ID: ");
            string id_in = Console.ReadLine();

            Console.WriteLine("Masukkan Gaji Pokok");
            double gajipokok_in = Convert.ToDouble(Console.ReadLine());

            karyawan karyawan1 = null;
            if (jenis_karyawan == "tetap")
            {
                karyawan1 = new karyawan_tetap(nama_in, id_in, gajipokok_in);
                Console.WriteLine("\n");
                Console.WriteLine("====DATA KARYAWAN=====");
                Console.WriteLine($"Jenis Karyawan : Tetap");

                karyawan1.tampil_gaji();
            }
            else if (jenis_karyawan == "kontrak")
            {
                karyawan1 = new karyawan_kontrak(nama_in, id_in, gajipokok_in);
                if (gajipokok_in < 200000)
                {
                    Console.WriteLine("Harap Masukkan gaji di atas 200000");
                }
                else if (gajipokok_in > 200000)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("====DATA KARYAWAN=====");
                    Console.WriteLine($"Jenis Karyawan : Kontrak");
                    karyawan1.tampil_gaji();
                }
            }
            else if (jenis_karyawan == "magang")
            {
                karyawan1 = new karyawan_magang(nama_in, id_in, gajipokok_in);
                Console.WriteLine("\n");
                Console.WriteLine("====DATA KARYAWAN=====");
                Console.WriteLine($"Jenis Karyawan : Magang");
                karyawan1.tampil_gaji();
            }
            else
            {
                Console.WriteLine("Harap masukkan jenis karyawan yang benar !!!");
                return;
            }
        }
    }

    public class karyawan
    {
        private string Nama;
        private string ID;
        private double Gaji_Pokok;

        public karyawan(string _Nama, string _ID, double _Gaji_Pokok)
        {
            Nama = _Nama;
            ID = _ID;
            Gaji_Pokok = _Gaji_Pokok;
        }

        public string _Nama
        {
            get { return Nama; }
            set { Nama = value; }
        }

        public string _ID
        {
            get { return ID; }
            set { ID = value; }
        }

        public double _Gaji_Pokok
        {
            get { return Gaji_Pokok; }
            set { Gaji_Pokok = value; }
        }

        public virtual double HitungGaji()
        {
            return _Gaji_Pokok;
        }

        public void tampil_gaji()
        {
            Console.WriteLine($"Nama Karyawan  : {_Nama}");
            Console.WriteLine($"ID Karyawan    : {_ID}");
            Console.WriteLine($"Gaji Karyawan  : {HitungGaji()}");
        }
    }

    class karyawan_tetap : karyawan
    {
        private double Bonus_tetap = 500000;

        public karyawan_tetap(string Nama, string ID, double Gaji_Pokok) : base(Nama, ID, Gaji_Pokok)
        {
            
        }

        public override double HitungGaji()
        {
            return _Gaji_Pokok + Bonus_tetap;
        }
    }

    class karyawan_kontrak : karyawan
    {
        private double Potongan_kontrak = 200000;

        public karyawan_kontrak(string _Nama, string _ID, double _Gaji_Pokok) : base(_Nama, _ID, _Gaji_Pokok)
        {
        }
        public override double HitungGaji()
        {
            return _Gaji_Pokok - Potongan_kontrak;
        }
    }

    class karyawan_magang : karyawan
    {
        public karyawan_magang(string _Nama, string _ID, double _Gaji_Pokok) : base(_Nama, _ID, _Gaji_Pokok)
        {
        }

        public override double HitungGaji()
        {
            return _Gaji_Pokok;
        }
    }
}
