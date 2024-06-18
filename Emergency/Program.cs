﻿using Emergency;
using System;

class Program
{
    public static void Main(string[] args)
    {
        Hash newHashTable = new Hash(1000);
        EmergencyQueue emergencyQueue = new EmergencyQueue();
        bool flag = true;
        int operasi;

        while (flag)
        {
            Console.Write("==========" + " Antrian Rumah Sakit " + "========== \n");
            Console.WriteLine("Pilih operasi: \n" +
                "1. Masukan Pasien \n" +
                "2. Lihat Antrian Selanjutnya \n" +
                "3. Ambil Pasien \n" +
                "4. Ambil Riwayat Pasien\n" +
                "5. Antrian berhenti");
            operasi = int.Parse(Console.ReadLine());

            if(operasi == 1)
            {
                Console.Write("NIK: ");
                long nik = int.Parse(Console.ReadLine());
                Console.Write("Nama: ");
                string nama = Console.ReadLine();
                Console.Write("Umur: ");
                int umur = int.Parse(Console.ReadLine());
                Console.Write("Alamat: ");
                string alamat = Console.ReadLine();
                Console.Write("Kondisi: ");
                string kondisi = Console.ReadLine();
                emergencyQueue.Insert(new Node(nik, nama, umur, alamat, kondisi));
            }

            if(operasi == 2)
            {
                Node PasienSelanjutnya = emergencyQueue.LihatAntrian();
                Console.WriteLine("Pasien selanjutnya: ");
                Console.WriteLine($"Nama: {PasienSelanjutnya.Nama}");
                Console.WriteLine($"Umur: {PasienSelanjutnya.Umur}");
                Console.WriteLine($"Alamat: {PasienSelanjutnya.Alamat}");
                Console.WriteLine();
            }

            if (operasi == 3)
            {
                Node PasienSelanjutnya = emergencyQueue.LihatAntrian();
                Console.WriteLine("Pasien selanjutnya: ");
                Console.WriteLine($"Nama: {PasienSelanjutnya.Nama}");
                Console.WriteLine($"Umur: {PasienSelanjutnya.Umur}");
                Console.WriteLine($"Alamat: {PasienSelanjutnya.Alamat}");
                Console.WriteLine("Penanganan pasien telah selesai");
                emergencyQueue.Delete();

                newHashTable.Insert(PasienSelanjutnya.Nik, PasienSelanjutnya.Nama, PasienSelanjutnya.Kondisi);
            }

            if(operasi == 4)
            {
                Console.Write("Masukkan nomor NIK Pasien yang ingin diambil riwayatnya");
                long nik = int.Parse(Console.ReadLine());
                Console.Write(newHashTable.Retrieve(nik));
            }
        }


    }
}