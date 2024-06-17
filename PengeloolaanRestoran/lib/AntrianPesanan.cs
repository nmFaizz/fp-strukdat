using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PengeloolaanRestoran.lib
{
    public class NodeAntrian
    {
        public string Value;
        public NodeAntrian? Next;
        public NodeAntrian(string value)
        {
            Value = value;
            Next = null;
        }
    }


    public class AntrianPesanan 
    {
        private NodeAntrian? Head;
        private NodeAntrian? Tail;
        private int Size;

        public AntrianPesanan()
        {
            Head = null;
            Tail = null;
            Size = 1;
        }
        
        public void Enqueue(string node)
        {
            NodeAntrian newNode = new NodeAntrian(node);

            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
                return;
            } else
            {
                Tail.Next = newNode;
                Tail = newNode;
            }

            Size++;
        }


        public string Dequeue()
        {
            if (Head != null) 
            {
                string temp = Head.Value;
                Head = Head.Next;
                
                if (Head == null)
                {
                    Tail = null;
                }

                Size--;
                return temp;
            }

            throw new ArgumentNullException("Queue is Empty");
        }

        public bool IsEmpty()
        {
            return Head == null && Tail == null;
        }

        public string Front()
        {
            if (Head != null)
            {
                return Head.Value;
            }

            throw new ArgumentNullException("Queue is empty");
        }

        public string Rear()
        {
            if (Tail != null)
                return Tail.Value;

            throw new ArgumentException("Queue is empty");
        }

        public void PrintAntrian()
        {
            NodeAntrian current = Head;
            int i = 0;

            while (current != null)
            {
                Console.WriteLine($"{i + 1}. {current.Value}");  
                current = current.Next;
                i++;
            }
        }

        public void EditQueue(int target)
        {
            if (target < 1 || target > Size)
            {
                Console.WriteLine("Invalid target..");
                return;
            }

            NodeAntrian current = Head;
            int i = 1;

            while (current != null && i != target)
            {
                current = current.Next;
                i++;
            }

            Console.Write("-- Input perubahan: ");
            current.Value = Console.ReadLine();
            Console.WriteLine("Antrian berhasil diubah...");
        }

        public void Delete(int target)
        {
            if (target < 1 || target > Size)
            {
                Console.WriteLine("Invalid target..");
                return;
            }

            if (target == 1)
            {
                Head = Head.Next;
                if (Head == null)
                {
                    Tail = null;
                }
            }
            else
            {
                NodeAntrian current = Head;
                NodeAntrian previous = null;
                int i = 1;

                while (current != null && i < target)
                {
                    previous = current;
                    current = current.Next;
                    i++;
                }

                if (current != null)
                {
                    previous.Next = current.Next;
                    if (current.Next == null)
                    {
                        Tail = previous;
                    }
                }
            }

            Size--;
        }

        public int GetSize()
        {
            return Size;
        }  
    }

    public class AntrianManager : RestoranManager
    {
        public static void Run()
        {
            bool isRunning = true;
            string command = "0";

            StartLoading();

            while (isRunning)
            {
                ShowAntrianMenu();
                Console.Write("Type Command (1-3): ");
                command = Console.ReadLine();

                switch (command)
                {
                    case "0":
                        break;
                    case "1":             
                        TambahAntrian();
                        break;
                    case "2":
                        SelesaikanAntrianDepan();
                        break;
                    case "3":
                        TampilkanAntrian();
                        break;
                    case "4":
                        EditAntrian();
                        break;
                    case "5":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("[Command not found, Type command from 1-4.]");
                        break;
                }

            }
        }

        public static void TambahAntrian()
        {
            Console.Write("## Ketik detail antrian [ID Pesanan] - [Nama Pembeli]: ");
            string detailAntrian = Console.ReadLine();
            antrianPesanan.Enqueue(detailAntrian);
            Console.WriteLine("-> Antrian berhasil ditambahkan !");
        }

        public static void SelesaikanAntrianDepan()
        {
            if (!IsQueueEmpty())
            {
                string dequeue = antrianPesanan.Dequeue();
                Console.WriteLine($"-> Antrian {dequeue} berhasil dihapus");
            }
        }

        public static bool IsQueueEmpty()
        {
            if (antrianPesanan.IsEmpty())
            {
                Console.WriteLine("Antrian Kosong...");
                return true;
            }

            return false;
        }

        public static void EditAntrian()
        {
            if (!IsQueueEmpty())
            {
                TampilkanAntrian();
                Console.Write("-- Antrian ke-berapa yang ingin anda edit? ");
                int target = int.Parse(Console.ReadLine());

                if (target > 0 && target <= antrianPesanan.GetSize())
                {
                    antrianPesanan.EditQueue(target);  
                } else
                {
                    Console.WriteLine("Target / Index antrian tidak ditemukan...");
                }
            }

        }

        public static void TampilkanAntrian()
        {
            if (!IsQueueEmpty())
            {
                Console.WriteLine("*** DAFTAR ANTRIAN: ");
                antrianPesanan.PrintAntrian();  
            }

        }

        public static void HapusAntrian()
        {
            if (!IsQueueEmpty())
            {
                Console.Write("");
                int target = int.Parse(Console.ReadLine());

                if (target > 0 && target <= antrianPesanan.GetSize())
                {
                    antrianPesanan.Delete(target);
                } else
                {
                    Console.WriteLine("Target / Index antrian tidak ditemukan...");
                }
            }
           
        }

        public static void ShowAntrianMenu()
        {
            Console.WriteLine("================ MENU ANTRIAN PESANAN ================");
            Console.WriteLine($"Total antrian: {antrianPesanan.GetSize()}");
            Console.WriteLine("1. Tambahkan Antrian");
            Console.WriteLine("2. Selesaikan Antrian Depan");
            Console.WriteLine("3. Daftar Antrian");
            Console.WriteLine("4. Edit Antrian");
            Console.WriteLine("5. Back");
        }
    }
}
