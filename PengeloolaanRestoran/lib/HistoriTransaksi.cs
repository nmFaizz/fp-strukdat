using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PengeloolaanRestoran.lib
{
    public class HistoriNode
    {
        public string Value;
        public HistoriNode? Next;

        public HistoriNode(string value) 
        {
            Value = value;
            Next = null;
        }  
    }

    public class HistoriTransaksi
    {
        public HistoriNode? Top;

        public HistoriTransaksi()
        {
            this.Top = null;
        }

        public void Push(string histori)
        {
            HistoriNode newNode = new HistoriNode(histori);
            newNode.Next = Top;
            Top = newNode;  
        }

        public string Pop()
        {
            if (IsEmpty())
            {
                return "Histori kosong...";
            }

            string temp = Top.Value;
            Top = Top.Next;

            return temp;
        }

        public string GetTop()
        {
            if (IsEmpty())
            {
                return "";
            }

            return this.Top.Value;

        }

        public bool IsEmpty()
        {
            return this.Top == null;    
        }

        public void ClearHistori()
        {
            if (!IsEmpty())
            {
                Top = null;
                Console.WriteLine("Histori berhasil dibersihkan...");
            }
            else
            {
                Console.WriteLine("Histori sudah kosong...");
            }
        }

        public void PrintHistori()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Tidak ada hisori terbaru...");
                return;
            }

            Console.WriteLine("--- Histori transaksi: ");

            HistoriNode current = this.Top;
            int i = 0;

            while (current != null)
            {
                i++;
                Console.WriteLine($"{i}. {current.Value}");
                current = current.Next;
            }
        }
    }

    public class HistoriManager : RestoranManager
    {
        public static void Run()
        {
            bool isRunning = true;
            string command;

            while (isRunning)
            {
                ShowHistoriMenu();
                Console.Write("Type Command (1-4): ");
                command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        ShowHistori();
                        break;
                    case "2":
                        UndoHistori();
                        break;
                    case "3":
                        HapusSemuaHistori();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }

        public static void ShowHistori()
        {
            historiTransaksi.PrintHistori();
        }

        public static void UndoHistori()
        {
            if (!historiTransaksi.IsEmpty())
            {
                Console.WriteLine($"{historiTransaksi.Pop()} berhasil di-undo");
            } else
            {
                Console.WriteLine("Histori Kosong...");
            }
        }

        public static void HapusSemuaHistori()
        {
            historiTransaksi.ClearHistori();
        }

        public static void ShowHistoriMenu()
        {
            Console.WriteLine("================ MENU HISTORI ================");
            Console.WriteLine("1. Lihat histori");
            Console.WriteLine("2. Undo histori");
            Console.WriteLine("3. Hapus semua histori");
            Console.WriteLine("4. Back");
        }
    }
}
