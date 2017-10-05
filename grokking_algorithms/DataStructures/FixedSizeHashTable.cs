using System;
using DataStructures_bad;

namespace DataStructures
{
    public struct KeyValue<K, V>
    {
        public K Key { get; set; }
        public V Value { get; set; }
        public override string ToString()
        {
            return "{" + this.Key + "," + this.Value + "}";
        }
    }

    public class FixedSizeGenericHashTable<K, V>
    {
        private readonly int size;
        private readonly LinkedList<KeyValue<K, V>>[] items;

        public FixedSizeGenericHashTable(int size)
        {
            this.size = size;
            items = new LinkedList<KeyValue<K, V>>[size];
        }

        protected int GetArrayPosition(K key)
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }

        public V Find(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }

            return default(V);
        }

        public void Add(K key, V value)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            KeyValue<K, V> item = new KeyValue<K, V>() { Key = key, Value = value };
            linkedList.Add(item);
        }

        public bool Remove(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            bool itemFound = false;
            int foundItemPosition = 0;
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    itemFound = true;
                    break;
                }

                foundItemPosition++;
            }

            if (itemFound)
            {
                linkedList.Remove(foundItemPosition);
            }
            
            return itemFound;
        }

        public bool RemoveAll(K key)
        {
            var found = false;

            while(this.Remove(key))
            {
                found = true;
            }

            return found;
        }

        protected LinkedList<KeyValue<K, V>> GetLinkedList(int position)
        {
            LinkedList<KeyValue<K, V>> linkedList = items[position];
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedList;
            }

            return linkedList;
        }

        public override string ToString()
        {
            var stringBuilder = string.Empty;
            stringBuilder += "[" + "\n";
            for (var i = 0; i < items.Length; i++)
            {
                stringBuilder += i + ": ";
                if (items[i] == null)
                {
                    stringBuilder += "null\n";
                }
                else
                {
                    stringBuilder += items[i].ToString() + "\n";
                }
            }

            stringBuilder += "]";
            return stringBuilder;
        }

        public static void Test()
        {
            var hashTable = new FixedSizeGenericHashTable<string, string>(25);

            hashTable.Add("you", "bob");
            hashTable.Add("you", "claire");
            hashTable.Add("you", "alice");

            hashTable.Add("bob", "anuj");
            hashTable.Add("bob", "peggy");

            hashTable.Add("alice", "peggy");

            hashTable.Add("claire", "thom");
            hashTable.Add("claire", "jonny");

            Console.WriteLine(hashTable.ToString());

            hashTable.RemoveAll("you");

            Console.WriteLine(hashTable.ToString());

            hashTable.Add("you", "bob");
            hashTable.Add("you", "claire");

            Console.WriteLine(hashTable.ToString());

            Console.Read();
        }
    }
}
