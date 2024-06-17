using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PengeloolaanRestoran.lib
{
    public class Karyawan
    {
        public string Nama;
        public int Umur;
        public string Divisi;

        public Karyawan(string nama, int umur, string divisi)
        {
            this.Nama = nama != string.Empty ? nama : "Unknown";
            this.Umur = umur > 0 ? umur : 0;
            this.Divisi = divisi != string.Empty ? divisi : "Unknown";
        }
    }

    public class RestoranManager
    {
        public Karyawan Admin;
        
        public void SetAdmin(Karyawan karyawan)
        {
            Admin = karyawan;
        }

        private Karyawan InputKaryawan()
        {
            Console.Write("## Input your name: ");
            string name = Console.ReadLine();
            Console.Write("## Input your age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("## Wich division are you in? (Ex: IT): ");
            string division = Console.ReadLine();

            return new Karyawan(name, age, division);
        }

        private void StartLoading()
        {
            Console.WriteLine("Loading...");
            Thread.Sleep(3000);
        }

        public void Run()
        {
            Karyawan karyawan = InputKaryawan();
            SetAdmin(karyawan);

            StartLoading();

            string command = "0";
            bool isRunning = true;

            ShowMainMenu();

            while (isRunning) 
            {
                switch(command)
                {
                    case "0":
                        break;
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("[Command not found, Type command from 1-5.]");
                        break;
                }

                Console.Write("Type command (1-5): ");
                command = Console.ReadLine();
                
            }
        }

        public void ShowMainMenu()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"| Welcome, {Admin.Nama} from {Admin.Divisi} division |");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("================ MAIN MENU ================");
            Console.WriteLine("# COMMANDS:");
            Console.WriteLine("1. Antrian Pesanan");
            Console.WriteLine("2. Histori Transaksi");
            Console.WriteLine("3. Manajemen Menu");
            Console.WriteLine("4. Exit");
        }

    }
}
