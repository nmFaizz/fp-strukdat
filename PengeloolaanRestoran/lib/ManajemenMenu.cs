using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using PengeloolaanRestoran.lib;

namespace PengelolaanRestoran.lib
{
    public class MenuNode
    {
        public string Value;
        public MenuNode? Next;

        public MenuNode(string value)
        {
            Value = value;
            Next = null;
        }
    }

    public class ListMenu
    {
        private MenuNode Head;
        private MenuNode Tail;
        private int Size;

        public ListMenu()
        {
            Head = null;
            Tail = null;
            Size = 0;
        }

        public void AddLast(string menu)
        {
            MenuNode menuNode = new MenuNode(menu);
            if (IsEmpty())
            {
                Head = menuNode;
                Tail = menuNode;
            }
            else
            {
                Tail.Next = menuNode;
                Tail = menuNode;
            }
            Size++;
        }

        public bool IsEmpty()
        {
            return Head == null;
        }

        public void DeleteAllMenu()
        {
            Head = null;
            Tail = null;
            Size = 0;
        }

        public int GetSize()
        {
            return Size;
        }

        public void DisplayMenuPage(int pageNumber, int pageSize)
        {
            if (pageNumber < 1 || pageSize <= 0)
            {
                Console.WriteLine("Page number or page size is invalid.");
                return;
            }

            int startIndex = (pageNumber - 1) * pageSize;
            if (startIndex >= Size)
            {
                Console.WriteLine("Page number exceeds total menu items.");
                return;
            }

            MenuNode current = Head;
            for (int i = 0; i < startIndex && current != null; i++) //moves the current node to the starting index (first element in specified page)
            {
                current = current.Next;
            }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
            for (int i = 0; i < pageSize && current != null; i++) //prints the elements in specified page until page size is reached
            {
                Console.WriteLine($"{startIndex + i + 1}: {current.Value}");
                current = current.Next;
            }
        }

        public void EditMenu(int index, string newMenu)
        {
            if (index < 0 || index >= Size)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index out of range"); //nameof(index) gets the index for the parameter of exception
            }

            MenuNode current = Head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            current.Value = newMenu;
        }

        public void DeleteMenu(int index)
        {
            if (index < 0 || index >= Size)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index out of range"); //nameof(index) gets the index for the parameter of exception
            }

            if (index == 0)
            {
                Head = Head.Next;
                if (Head == null)  // if the list becomes empty
                {
                    Tail = null;
                }
            }
            else
            {
                MenuNode current = Head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                current.Next = current.Next.Next; // skips the node so that it has no reference, therefore deleted
                if (current.Next == null)  // if we removed the last element
                {
                    Tail = current;
                }
            }
            Size--;
        }
    }

    public class MenuManager : RestoranManager
    {
        private static ListMenu menuList = new ListMenu();
        private static int currentPage = 1;
        private const int pageSize = 5;

        public static void Run()
        {
            ShowMenuInterface();
        }

        public static void TampilkanMenu()
        {
            if (menuList.IsEmpty())
            {
                Console.WriteLine("Menu kosong.");
            }
            else
            {
                menuList.DisplayMenuPage(currentPage, pageSize);
            }
        }

        public static void TambahkanMenu()
        {
            Console.Write("Masukkan nama menu: ");
            string menu = Console.ReadLine();
            menuList.AddLast(menu);
            Console.WriteLine("Menu berhasil ditambahkan.");
        }

        public static void EditMenu()
        {
            TampilkanMenu();
            Console.Write("Masukkan indeks menu yang ingin diubah: ");
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                Console.Write("Masukkan nama baru: ");
                string newMenu = Console.ReadLine();
                try
                {
                    menuList.EditMenu(index - 1, newMenu);
                    Console.WriteLine("Menu berhasil diubah.");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Indeks tidak valid.");
                }
            }
            else
            {
                Console.WriteLine("Masukkan indeks yang valid.");
            }
        }

        public static void HapusMenu()
        {
            TampilkanMenu();
            Console.Write("Masukkan indeks menu yang ingin dihapus: ");
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                try
                {
                    menuList.DeleteMenu(index - 1); // adjusting index for 1-based user input
                    Console.WriteLine("Menu berhasil dihapus.");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Indeks tidak valid.");
                }
            }
            else
            {
                Console.WriteLine("Masukkan indeks yang valid.");
            }
        }

        public static void ShowMenuInterface()
        {
            while (true)
            {
                Console.WriteLine("\n================ MANAJEMEN MENU ================");
                Console.WriteLine($"-- Halaman menu saat ini: {currentPage}");
                Console.WriteLine("1. Tampilkan Menu (Halaman Sebelumnya)");
                Console.WriteLine("2. Tampilkan Menu (Halaman Selanjutnya)");
                Console.WriteLine("3. Tambahkan Menu");
                Console.WriteLine("4. Edit Menu");
                Console.WriteLine("5. Hapus Menu");
                Console.WriteLine("6. Back");
                Console.Write("Type Command (1-6): ");

                switch (Console.ReadLine())
                {
                    case "1":
                        if (currentPage > 1)
                        {
                            currentPage--;
                        }
                        else
                        {
                            Console.WriteLine("Anda sudah di halaman pertama.");
                        }
                        TampilkanMenu();
                        break;
                    case "2":
                        int totalPageCount = (int)Math.Ceiling((double)menuList.GetSize() / pageSize);
                        if (currentPage < totalPageCount)
                        {
                            currentPage++;
                        }
                        else
                        {
                            Console.WriteLine("Anda sudah di halaman terakhir.");
                        }
                        TampilkanMenu();
                        break;
                    case "3":
                        TambahkanMenu();
                        break;
                    case "4":
                        EditMenu();
                        break;
                    case "5":
                        HapusMenu();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("[Command not found, Type command from 1-6.]");
                        break;
                }
            }
        }
    }
}

