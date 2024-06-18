using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PengeloolaanRestoran.lib
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
        private int Size;

        public ListMenu()
        {
            Head = null;
            Size = 0;   
        }

        public void AddFirst(string menu)
        {
            MenuNode menuNode = new MenuNode(menu);
            menuNode.Next = Head;
            Head = menuNode;
            Size++;
        }

        public void AddLast(string menu)
        {

        }

        // delete berdasarkan index jg sabi 
        public void DeleteAfter()
        {

        }

        public bool IsEmpty()
        {
            return Head == null;
        }

        public void DeleteAllMenu()
        {

        }

        public int GetSize()
        {
            return Size;
        }
    }

    public class MenuManager : RestoranManager
    {
        
        public static void Run() 
        {
            
        }

        public static void TampilkanMenu()
        {

        }

        public static void TambahkanMenu()
        {

        }

        public static void EditMenu()
        {

        }

        public static void HapusMenu()
        {

        }

        public static void ShowMenuInterface()
        {

        }

        // fungsi lain klo ada..
        // semuanya pake static aja
    }

}
