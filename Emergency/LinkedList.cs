using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency
{
    internal class LinkedList
    {
        internal class Node
        {
            public long _key;
            public string _value;
            public string Kondisi;
            public Node _next;

            public Node(long key, string value, string kondisi)
            {
                this._key = key;
                this._value = value;
                this.Kondisi = kondisi;
                _next = null;
            }
        }

        private Node _head;

        public LinkedList()
        {
            _head = null;
        }

        public void Insert(long key, string value, string kondisi)
        {
            if (_head == null)
            {
                _head = new Node(key,value, kondisi);
            }
            else
            {
                Node current = _head;
                while (current._next != null)
                {
                    current = current._next;
                }
                current._next = new Node(key, value, kondisi);
            }
        }

        public string Retrieve(long key)
        {
            Node current = _head;
            StringBuilder stringResult = new StringBuilder();

            while (current != null)
            {
                if (current._key == key)
                {
                    stringResult.Append($"Pasien dengan NIK: {key}, atas nama {current._value}, memiliki kondisi {current.Kondisi} \n");
                }
                current = current._next;
            }

            string result = stringResult.ToString();
            return result ?? null;
        }
    }
}
