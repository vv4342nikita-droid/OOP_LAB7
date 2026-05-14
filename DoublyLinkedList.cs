using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedListTask
{
   
    public class Node
    {
        
        public double Data { get; set; }
        
        public Node Next { get; set; }
        
        public Node Prev { get; set; }

        
        public Node(double data)
        {
            Data = data;
        }
    }

   
    public class DoublyLinkedList : IEnumerable<double>
    {
    
        public Node Head { get; private set; }
    
        public Node Tail { get; private set; }

        
        public double this[int index]
        {
            get
            {
                Node current = GetNodeAt(index);
                return current.Data;
            }
        }

        
        public void AddFirst(double data)
        {
            Node newNode = new Node(data);
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                newNode.Next = Head;
                Head.Prev = newNode;
                Head = newNode;
            }
        }

        
        public void RemoveAt(int index)
        {
            Node target = GetNodeAt(index);

            if (target.Prev != null) target.Prev.Next = target.Next;
            else Head = target.Next;

            if (target.Next != null) target.Next.Prev = target.Prev;
            else Tail = target.Prev;
        }

       
        private Node GetNodeAt(int index)
        {
            if (index < 0) throw new IndexOutOfRangeException();
            Node current = Head;
            int count = 0;
            while (current != null)
            {
                if (count == index) return current;
                count++;
                current = current.Next;
            }
            throw new IndexOutOfRangeException();
        }

       
        public double? FindFirstLessThanAverage()
        {
            if (Head == null) return null;
            double sum = 0;
            int count = 0;
            foreach (var val in this) { sum += val; count++; }
            double avg = sum / count;

            foreach (var val in this)
            {
                if (val < avg) return val;
            }
            return null;
        }

        
        public double SumAfterMax()
        {
            Node maxNode = GetMaxNode();
            double sum = 0;
            Node current = maxNode.Next;
            while (current != null)
            {
                sum += current.Data;
                current = current.Next;
            }
            return sum;
        }

       
        public DoublyLinkedList GetElementsGreaterThan(double threshold)
        {
            DoublyLinkedList newList = new DoublyLinkedList();
            foreach (var val in this)
            {
                if (val > threshold) newList.AddFirst(val);
            }
            return newList;
        }

       
        public void RemoveBeforeMax()
        {
            Node maxNode = GetMaxNode();
            Head = maxNode;
            if (Head != null) Head.Prev = null;
        }

        private Node GetMaxNode()
        {
            if (Head == null) throw new InvalidOperationException();
            Node maxNode = Head;
            Node current = Head.Next;
            while (current != null)
            {
                if (current.Data > maxNode.Data) maxNode = current;
                current = current.Next;
            }
            return maxNode;
        }

        
        public IEnumerator<double> GetEnumerator()
        {
            Node current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}