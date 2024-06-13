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

        public Karyawan(string Nama, int Umur, string Divisi)
        {
            this.Nama = Nama;
            this.Umur = Umur;
            this.Divisi = Divisi;
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
            Console.Write("Input name: ");
            string name = Console.ReadLine();
            Console.Write("Input age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Wich division are you in? (Ex: IT): ");
            string division = Console.ReadLine();

            return new Karyawan(name, age, division);
        }

        private void Loading()
        {
            Console.WriteLine("Loading...");
            Thread.Sleep(3000);
        }

        public void Run()
        {
            Karyawan karyawan = InputKaryawan();
            SetAdmin(karyawan);

            Loading();

            string command = "main menu";

            while (command.ToLower() != "close") 
            {
                switch(command.ToLower())
                {
                    case "main menu":
                        ShowMainMenu();
                        break;
                    case "antrian pesanan":
                        break;
                    case "histori transaksi":
                        break;
                    case "manajemen menu":
                        break;
                    default:
                        break;
                }

                Console.Write("Type command: ");
                command = Console.ReadLine();
                
                Environment.Exit(0);
            }
        }

        public void ShowMainMenu()
        {
            Console.WriteLine("================ MAIN MENU ================");
            Console.WriteLine("# COMMANDS:");
            Console.WriteLine("-- Main Menu");
            Console.WriteLine("-- Antrian Pesanan");
            Console.WriteLine("-- Histori Transaksi");
            Console.WriteLine("-- Manajemen Menu");
            Console.WriteLine("-- Close");
        }

    }
}
