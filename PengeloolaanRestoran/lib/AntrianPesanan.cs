using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PengeloolaanRestoran.lib
{
    public class Node
    {
        public string Value;
        public Node? Next;
        public Node(string value)
        {
            Value = value;
            Next = null;
        }
    }


    public class AntrianPesanan
    {
        private Node Head;

        public AntrianPesanan()
        {
            Head = null;
        }



    }
}
