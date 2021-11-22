using System;
using System.Collections.Generic;

namespace Testing
{
    class Program
    {
        public class Node
        {
            public int Value { get; set; }              //Имя вершины
            public List<Edge> edges { get; set; }       // Исходящие из вершины связи

            public Node()
            {
                this.edges=new List<Edge>();
            }
        }

        public class Edge
        {
            public int Weight { get; set; }
            public Node node { get; set; }          //Целевая вершина


        }

        public class Graph
        {
            public Node head { get; set; }
            private List<Node> All_Nodes=new List<Node>();
            

            public Graph(int value)
            {
                          
                this.head=new Node{Value=4};
                All_Nodes.Add(this.head);
                
            }


            public void AddNode(int value)
            {
                var new_node = new Node { Value = value };
                this.All_Nodes.Add(new_node);
            }

            private void Add_Edge(int node_name_init, int node_name_final, int weight)
            {
                var init_node=All_Nodes.Find(node => node.Value == node_name_init);
                var final_node=All_Nodes.Find(node => node.Value == node_name_final);


                if (All_Nodes.Exists(node => node.Value == node_name_init) &&
                    All_Nodes.Exists(node => node.Value == node_name_final))
                {
                    var edge=new Edge{Weight=weight, node=final_node};
                    init_node.edges.Add(edge);
                    
                }
                else
                {
                    Console.WriteLine("Не найдено одной из НОД");
                }


            }

            public void AddEdge(int node_name_init, int node_name_final, int weight)
                =>Add_Edge(node_name_init, node_name_final, weight);

            public void BFS_Graph(int finding_value)
            {
                var q=new Queue<Node>();
                q.Enqueue(head);
                
                Node buf;

                while(q.Count!=0)
                {
                    buf=q.Dequeue();
                    if (buf.Value!=finding_value)
                    {
                        for (int i=0; i<buf.edges.Count; i++)
                        {
                            q.Enqueue(buf.edges[i].node);
                            
                        }
                    }
                    
                    Console.WriteLine(buf.Value);
                }
            }
        }
        
        static void Main(string[] args)
        {
            Graph Graph1=new Graph(4);
            Graph1.AddNode(5);
            Graph1.AddEdge(4,5,1);
            Graph1.AddNode(7);
            Graph1.AddEdge(4,7,1);
            Graph1.AddNode(11);
            Graph1.AddEdge(7,11,1);
            Graph1.AddNode(9);
            Graph1.AddEdge(4,9,1);
            
            Graph1.BFS_Graph(8);
            
        }



    }
}
