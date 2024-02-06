using System;
using System.Collections.Generic;

namespace GA_LinkedList_ArmanSahota
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> linkedList = new LinkedList<int>();

            linkedList.Add(10);
            linkedList.Add(20);
            linkedList.Add(30);

            Console.WriteLine("Linked List elements:");
            linkedList.Display();

            Console.WriteLine("Count of elements: " + linkedList.Count);

            int indexToAccess = 1;
            Console.WriteLine($"Element at index {indexToAccess}: {linkedList[indexToAccess]}");

            int valueToRemove = 20;
            if (linkedList.Remove(valueToRemove))
            {
                Console.WriteLine($"Removed {valueToRemove} from the list.");
            }
            else
            {
                Console.WriteLine($"{valueToRemove} not found in the list.");
            }

            Console.WriteLine("Updated Linked List elements:");
            linkedList.Display();

            Console.ReadLine();
        }
    }

    class LinkedList<T> 
    { 

        
        class LinkedListNode<T> // nodes in a linked list 
        {
            public T Value { get; set; }        // Node value
            public LinkedListNode<T> Next { get; set; } // Next node

            
            public LinkedListNode(T value)
            {
                Value = value;  // Node data
                Next = null;    //Next node needs to be Null and Intilized 
            }
        }
        // Fields
        private LinkedListNode<T> head;
        private int count;

        // Property
        public int Count
        {
            get { return count; }
        }

        // Constructor
        public LinkedList()
        {
            head = null;
            count = 0;
        }

        // Add to the end of a list or last node
        public void Add(T value)
        {
            //  Create a new node with the given value
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);

            
             // If head is null list is empy and we need to create a new node
            if (head == null)
            {
                // create new node and make it the head node
                head = newNode;
            } 
            else
            {
                // start at head of the node
                LinkedListNode<T> current = head;

                // while the next node is not empty 
                while (current.Next != null)
                {
                    // go to the next node
                    current = current.Next;
                }

                // once the next node is empty make that the new node
                current.Next = newNode;
            }

            // increase count of nodes
            count++;
        }
        // method displays nodes
        public void Display()
        {
            // start at the head node
            LinkedListNode<T> current = head;

            // while the current node is not empty
            while (current != null)
            {
                // print the current node and an arrow
                Console.Write($"{current.Value} -> ");

                //go to the next node
                current = current.Next;
            }

            //  Print "null" to indicate the end of the linked list
            Console.WriteLine("null");
        }
        // Method to remove an element by its value
        public bool Remove(T value)
        {
            // check if list is empty
            if (head == null)
            {
                // if empty not possible return false
                return false;
            }

            // Check if the value being removed is at the head of the list
            if (head.Value.Equals(value))
            {
                //if it is the head value make the next node the new head value and remove one from the count
                head = head.Next;
                count--;
                return true; // return true since elemnt got deleted
            }

            //  If the value is not at the head, start at the head
            LinkedListNode<T> current = head;

            // go down the list until  the next node is null
            while (current.Next != null)
            {
                // check if the current value is equal to the current valuse
                if (current.Next.Value.Equals(value))
                {
                    // if they match the next value is now the value after the next
                    current.Next = current.Next.Next;
                    count--; // remove one from the count
                    return true; // return true
                }
                current = current.Next;
            }

            // if null return false
            return false;
        }
       
        public T this[int index] // get value at a specific index.
        {
            get
            {
                //checking if the index if in range
                if (index < 0 || index >= count)
                {
                    // if out of range throw error
                    throw new IndexOutOfRangeException();
                }

                //  start at the head of the list
                LinkedListNode<T> current = head;

                // 5. go down the list
                for (int i = 0; i < index; i++)
                {
                    // move to the next node
                    current = current.Next;
                }

                // return the value found at the specific index
                return current.Value;
            }
        }
    }

}