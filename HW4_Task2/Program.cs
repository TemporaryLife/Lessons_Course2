using System;
using System.Collections.Generic;

namespace HW4_Task2
{
    class Program
    {

        public class Node
        {
            public int Value;
            public Node LeftChild {get;set;}
            public Node RightChild {get;set;}
            public Node Parent {get;set;}
        }
        public interface ITree
        {

            Node GetRoot();
            void AddItem(int value); // добавить узел
            void RemoveItem(int value); // удалить узел по значению
            Node GetNodeByValue(int value); //получить узел дерева по значению
            void PrintTree(Node x); //вывести дерево в консоль

        }
        public class Tree : ITree
        {
            public Node root;
                     


            //Создание дерева обязательно с корнем.
            public Tree(int root_value)
            {
                this.root=new Node 
                    {
                    Value=root_value,
                    LeftChild=null,
                    RightChild=null
                    };

            }

            public void AddItem(int x)
            {
                Node current=this.root;
                Node newNode=new Node {Value=x };
                while (current!=null)
                {
                    if (x<current.Value)
                    {
                        if (current.LeftChild!=null)
                        {
                            current=current.LeftChild;
                        }
                        else
                        {
                            newNode.Parent=current;
                            current.LeftChild=newNode;
                            break;
                        }
                    }
                    else if (x > current.Value)
                    {
                        if (current.RightChild!=null)
                        {
                            current=current.RightChild;
                        }
                        else
                        {
                            newNode.Parent=current;
                            current.RightChild=newNode;
                            break;
                        }
                    }
                    else
                    {
                       Console.WriteLine("Дубликат");
                       break;
                    }
                }

            }

            public Node GetNodeByValue(int value)
            {
                var q=new Queue<Node>();
                q.Enqueue(root);
                Node buf;
                while(q.Count!=0)
                {
                    buf=q.Dequeue();
                    if (buf.Value!=value)
                    {
                        if (buf.LeftChild!=null)
                        {
                            q.Enqueue(buf.LeftChild);
                        }
                        
                        if (buf.RightChild!=null)
                        {
                            q.Enqueue(buf.RightChild);

                        }
                        
                    }
                    else
                    {
                        return buf;
                    }
                }
                return null;
            }

            public Node GetRoot()=> root;


            public void PrintTree(Node x)
            {
                Console.WriteLine(x.Value);
                PrintTree(x.LeftChild);
                PrintTree(x.RightChild);
            }

            public void RemoveItem(int value)
            {
                throw new NotImplementedException();
            }
        }

        static void Main(string[] args)
        {
             var root=new Node{Value=7};
            var Tree1=new Tree(root.Value);
            Tree1.AddItem(5);
            Tree1.AddItem(3);
            Tree1.AddItem(2);
            Tree1.AddItem(1);
            Tree1.AddItem(4);
            Tree1.PrintTree(root);
            
        }

        
    }
}
