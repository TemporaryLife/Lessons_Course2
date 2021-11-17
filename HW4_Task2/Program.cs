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
            void PrintTree(Node x, string sp); //вывести дерево в консоль

        }
        public class Tree : ITree
        {
            public Node root;
                     


            //Создание дерева обязательно с корнем.
            public Tree(/*int root_value*/Node root)
            {
                this.root=root;
                /*this.root=new Node 
                    {
                    Value=root_value,
                    LeftChild=null,
                    RightChild=null
                    };*/

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


            public void PrintTree(Node x, string space="")
            {
                if (x!=null)
                {
                
                PrintTree(x.RightChild, space+"\t");
                Console.WriteLine($"{space}{x.Value}");
                
                PrintTree(x.LeftChild,space+"\t");
                }
                
            }

            public void RemoveItem(int value)
            {
                
                
                //Если у удаляемого элемента нет потомков
                try
                {
                    Node RemovingItem=GetNodeByValue(value);
                    bool isLeftNull=RemovingItem.LeftChild==null;
                    bool isRightNull=RemovingItem.RightChild==null;
                    if (isLeftNull && isRightNull)
                {
                    if (RemovingItem.Parent.LeftChild == RemovingItem)
                    {
                        RemovingItem.Parent.LeftChild = null;
                    }
                    else if (RemovingItem.Parent.RightChild == RemovingItem)
                    {
                        RemovingItem.Parent.RightChild = null;
                    }
                }
                //Если один потомок
                else if(isLeftNull && !isRightNull )
                {
                    if (RemovingItem.Parent.LeftChild == RemovingItem)
                    {
                        RemovingItem.Parent.LeftChild = RemovingItem.RightChild;
                        RemovingItem.LeftChild.Parent=RemovingItem.Parent;
                    }
                    else if (RemovingItem.Parent.RightChild == RemovingItem)
                    {
                        RemovingItem.RightChild.Parent=RemovingItem.Parent;
                        RemovingItem.Parent.RightChild = RemovingItem.RightChild;
                        
                    }
                    
                }
                else if(!isLeftNull && isRightNull)
                {
                    if (RemovingItem.Parent.LeftChild == RemovingItem)
                    {
                        RemovingItem.Parent.LeftChild = RemovingItem.LeftChild;
  
                    }
                    else if (RemovingItem.Parent.RightChild == RemovingItem)
                    {
                        RemovingItem.Parent.RightChild = RemovingItem.LeftChild;
                        
                    }
                    RemovingItem.LeftChild.Parent=RemovingItem.Parent;
                }
                //Если два потомка
                else if(!isLeftNull && !isRightNull)
                {
                    Node current = RemovingItem.RightChild;
                    while (current!=null)
                    {
                        if (current.LeftChild==null)
                        {
                            break;
                        }
                        else
                        {
                            current=current.LeftChild;
                        }
                    }
                    current.LeftChild=RemovingItem.LeftChild;
                    RemovingItem.LeftChild.Parent=current;
                    current.Parent=RemovingItem.Parent;
                    if (RemovingItem.Parent.LeftChild == RemovingItem)
                    {
                        RemovingItem.Parent.LeftChild = current;
                    }
                    else if (RemovingItem.Parent.RightChild == RemovingItem)
                    {
                        RemovingItem.Parent.RightChild = current;
                    }
                    
                }
                }
                catch (NullReferenceException e)

                {
                    Console.WriteLine("Нет такого элемента");
                }
                



            }
        }

        static void Main(string[] args)
        {
            
             var root=new Node{Value=7};
            var Tree1=new Tree(root);
            Tree1.AddItem(10);
            Tree1.AddItem(8);
            Tree1.AddItem(11);
            Tree1.AddItem(9);
            Tree1.AddItem(5);
            Tree1.AddItem(3);
            Tree1.AddItem(6);
            Tree1.AddItem(2);
            Tree1.AddItem(4);
            Tree1.AddItem(1);
            
            Node Ten=Tree1.GetNodeByValue(10);
            Node Eleven=Tree1.GetNodeByValue(11);
            Node Eight=Tree1.GetNodeByValue(8);
            Node Fourteen=Tree1.GetNodeByValue(14);
            
            
            
            Tree1.PrintTree(root);
           
            Tree1.RemoveItem(2);
            Tree1.RemoveItem(3);
            Tree1.RemoveItem(3);
            
            

            

            Console.WriteLine("---------------------");
            Tree1.PrintTree(root);
            Console.WriteLine("---------------------");
            Console.WriteLine("---------------------");
            




        }

        
    }
}
