using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency
{
    internal class Hash
    {
        private LinkedList[] _hashTable;
        private int _size;
        private int _counter;

        public Hash(int size)
        {
            _hashTable = new LinkedList[size]; 
            this._size = size;
            this._counter = 0;
        }

        private int HashFunction(long key)
        {
            return (int)key % _size;
        }

        public void Insert(long key, string value, string kondisi)
        {
            int index = HashFunction(key);
            _hashTable[index].Insert(key,value, kondisi);
        }

        public string Retrieve(long key)
        {
            int index = HashFunction(key);
            return _hashTable[index].Retrieve(key);
        }
    }
}
