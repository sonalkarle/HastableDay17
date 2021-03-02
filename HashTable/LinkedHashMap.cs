using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class LinkedHashMap<K, V> where K : IComparable
    {
        private readonly int NumBuckets;
        readonly List<LinkedList<K, V>> BucketList;

        public LinkedHashMap(int NumBuckets)
        {
            //Linked list added to array locatation
            //NumBuckets is Array size
            this.NumBuckets = NumBuckets;
            BucketList = new List<LinkedList<K, V>>(NumBuckets);
              
            for (int i = 0; i < this.NumBuckets; i++)
                BucketList.Add(null);
        }

        public V Get(K key)
        {
            //Check value of particular key(word)
            int index = GetBucketIndex(key);
            //check  particular linked list at the array position
            LinkedList<K, V> myLinkedList = BucketList[index];
            if (myLinkedList == null)
                return default;
            //Check particular key mymapnode in the linked list at array position
            MyMapNode<K, V> myMapNode = myLinkedList.Search(key);
            return (myMapNode == null) ? default : myMapNode.value;
        }

        private int GetBucketIndex(K key)
        {
            //Return the absolute value because hashCode contain negative value sometime
            int hashCode = Math.Abs(key.GetHashCode());
            //To get the hashcode within range
            int index = hashCode % NumBuckets;
            return index;
        }

        public void Add(K key, V value)
        {
            //Adding the particular value and key at linked list 
            int index = this.GetBucketIndex(key);
            LinkedList<K, V> myLinkedList = BucketList[index];
            ///Check linked list is null or not
            if (myLinkedList == null)
            {
                myLinkedList = new LinkedList<K, V>();
                BucketList[index] = myLinkedList;
            }
            //Check myMapNode is present or not if not then create new else add value in previous mymapnode
            MyMapNode<K, V> myMapNode = myLinkedList.Search(key);
            if (myMapNode == null)
            {
                myMapNode = new MyMapNode<K, V>(key, value);
                myLinkedList.Append(myMapNode);
            }
            else myMapNode.value = value;
        }
       
       
    }
}
