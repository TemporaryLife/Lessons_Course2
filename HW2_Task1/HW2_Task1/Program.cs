using System;

namespace HW2_Task1
{
    public class DLinkedList : ILinkedList
    {
        public Node First;
        public Node Last;
        public int count;
        public void AddNode(int value)
        {

            var AddedNode = new Node { Value = value };
            if (First==null)
            {
                First = AddedNode;
            }
            else
            {
                Last.NextNode = AddedNode;
                AddedNode.PrevNode = Last;
            }
            Last = AddedNode;
            count++;
        }


        public void AddNodeAfter(Node node, int value)
        {
            var Added_Node = new Node { Value = value };
            if (First==null)
            {
                First = Added_Node;
            }

            else
            {
                node.NextNode.PrevNode = Added_Node;
                node.NextNode = Added_Node;
            }
        }

        public Node FindNode(int searchValue)
        {
            var current = new Node();
            current = First;
            while(current!=null)
            {
                if (current.Value==searchValue)
                {
                    return current;
                }
                current = current.NextNode;
            }
            return null;
        }

        public int GetCount()
        {
            return count;
        }

        public void RemoveNode(int index)
        {
            int list_index = 0;
            Node current = First;

            while (list_index!=index)
            {
                if (current.NextNode!=null)
                {
                    current = current.NextNode;
                }
                else
                {
                    break;
                    Console.WriteLine("За пределами массива");
                }
                list_index++;
            }
            if (current==Last)
            {
                Last = current.PrevNode;
            }
            if (current==First)
            {
                First = current.NextNode;
            }
            current.PrevNode.NextNode = current.NextNode;

        }

        public void RemoveNode(Node node)
        {
            Node current = First;

            while (current != null)
            {
                if (current.Value==node.Value)
                {
                    break;
                }
                current = current.NextNode;
            }
            if (current!=null)
            {
                if (current.NextNode!=null)
                {
                    current.NextNode.PrevNode = current.PrevNode;
                }
                else
                {
                    Last = current.PrevNode;
                }
            }
            if (current.PrevNode!=null)
            {
                current.PrevNode.NextNode = current.NextNode;
            }
            else
            {
                First = current.NextNode;
            }
            count--;
        }
    }

    public class Node
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }

    }
    public interface ILinkedList
    {
        int GetCount(); // возвращает количество элементов в списке
        void AddNode(int value);  // добавляет новый элемент списка
        void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
        void RemoveNode(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(Node node); // удаляет указанный элемент
        Node FindNode(int searchValue); // ищет элемент по его значению
    }

    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
