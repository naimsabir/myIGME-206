using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabir_UnitTest3_2
{
    //Class: Program
    //Author: Naim Sabir
    //Purpose: Unit Test 3 Questions 2 - 5
    //Restrictions: None currently

    //Question #4
    //Using the in-class example from Week #12, implement Dijkstra's shortest path algorithm to output the shortest path of colors from red to green.

    //Classes: Node & Edge
    //Purpose:
    public class Node : IComparable<Node>
    {
        public int nState;

        public List<Edge> edges = new List<Edge>();

        public int minCostToStart;
        public Node nearestToStart;
        public bool visited;

        public Node(int nState)
        {
            this.nState = nState;
            this.minCostToStart = int.MaxValue;
        }
        public void AddEdge(int cost, Node connection)
        {
            Edge e = new Edge(cost, connection);
            edges.Add(e);
        }

        public int CompareTo(Node n)
        {
            return this.minCostToStart.CompareTo(n.minCostToStart);
        }

    }

    public class Edge : IComparable<Edge>
    {
        public int cost;
        public Node connectedNode;

        public Edge(int cost, Node connectedNode)
        {
            this.cost = cost;
            this.connectedNode = connectedNode;
        }
        public int CompareTo(Edge e)
        {
            return this.cost.CompareTo(e.cost);
        }
    }
    class Program
    {
        //adjacency matrix : DONE
        static int[,] mGraph = new int[,]
        {
                          /*RED*/ /*NAVY BLUE*/ /*GRAY*/ /*BLUE*/ /*YELLOW*/ /*ORANGE*/ /*PURPLE*/ /*GREEN*/
            /*RED*/      { -1,          1,         5,       -1,       -1,        -1,        -1,        -1  },
            /*NAVY BLUE*/{ -1,         -1,        -1,        1,        8,        -1,        -1,        -1  },
            /*GRAY*/     { -1,         -1,        -1,        0,       -1,         1,        -1,        -1  },
            /*BLUE*/     { -1,          1,         0,       -1,       -1,        -1,        -1,        -1  },
            /*YELLOW*/   { -1,         -1,        -1,       -1,       -1,        -1,        -1,         6  },
            /*ORANGE*/   { -1,         -1,        -1,       -1,       -1,        -1,         1,        -1  },
            /*PURPLE*/   { -1,         -1,        -1,       -1,        1,        -1,        -1,        -1  },
            /*GREEN*/    { -1,         -1,        -1,       -1,       -1,        -1,        -1,        -1  },

        };

        //adjacency list : DONE
        static int[][] lGraph = new int[][]
        {
            /*RED*/        new int[] {1, 2},   /*NAVY BLUE, GRAY*/  
            /*NAVY BLUE*/  new int[] {3, 4},   /*BLUE, YELLOW*/
            /*GRAY*/       new int[] {3, 5},   /*BLUE, ORANGE*/
            /*BLUE*/       new int[] {1, 2},   /*NAVY BLUE, GRAY*/
            /*YELLOW*/     new int[] {7},      /*GREEN*/
            /*ORANGE*/     new int[] {6},      /*PURPLE*/
            /*PURPLE*/     new int[] {4},      /*YELLOW*/
            /*GREEN*/      new int[] {},   

        };

        //weight list (don't know if I actually need it or not)
        static int[][] wGraph = new int[][]
        {
            /*RED*/        new int[] {1, 5},   /*NAVY BLUE, GRAY*/  
            /*NAVY BLUE*/  new int[] {1, 8},   /*BLUE, YELLOW*/
            /*GRAY*/       new int[] {0, 1},   /*BLUE, ORANGE*/
            /*BLUE*/       new int[] {1, 0},   /*NAVY BLUE, GRAY*/
            /*YELLOW*/     new int[] {6},      /*GREEN*/
            /*ORANGE*/     new int[] {1},      /*PURPLE*/
            /*PURPLE*/     new int[] {1},      /*YELLOW*/
            /*GREEN*/      new int[] {},
        };


        //Method: NumToString()
        //Purpose: A string method to translate a number state into it's proper string translation
        //Restrictions: Currently none
        static string NumToString(int numState)
        {
            string stringState;
            switch (numState)
            {
                case 0:
                    stringState = "RED";
                    break;
                case 1:
                    stringState = "NAVY BLUE";
                    break;
                case 2:
                    stringState = "GRAY";
                    break;
                case 3:
                    stringState = "BLUE";
                    break;
                case 4:
                    stringState = "YELLOW";
                    break;
                case 5:
                    stringState = "ORANGE";
                    break;
                case 6:
                    stringState = "PURPLE";
                    break;
                case 7:
                    stringState = "GREEN";
                    break;
                default:
                    stringState = "How did you manage to fuck this up";
                    break;
            }
            return stringState;
        }

        //Question #3 - DONE
        //Using the in-class example from Week #11, implement a Depth First Search of this digraph starting from red and output the colors.

        //Methods: DFS & DFSUtil
        //Purpose: To do a depth first search which is recursively going down a branch and then going up and trying new paths
        //Restrictions: Currently none
        static void DFS()
        {
            bool[] visited = new bool[lGraph.Length];

            DFSUtil(0, ref visited);
        }

        static void DFSUtil(int currentState, ref bool[] visited)
        {
            //set the state parameter to true because it was just visited
            visited[currentState] = true;

            //get the string representation of the state parameter to output it to the console
            string currentStringState = NumToString(currentState);
            Console.Write($"{currentStringState} ");

            //Obtain the list of adjacent states using the adjacency list
            int[] currentStateList = lGraph[currentState];

            //if there are adjacent states
            if(currentStateList != null)
            {
                //set each unvisited state visited and then call the function recursively
                foreach(int state in currentStateList)
                {
                    if(!visited[state])
                    {
                        DFSUtil(state, ref visited);
                    }
                }
            }
        }

        static List<Node> game = new List<Node>();

        //Method: Main
        //Purpose: 
        //Restrictions: Currently none
        static void Main(string[] args)
        {
            //**************************************************************Question #3***************************************************************** 
            Console.WriteLine("The Depth First Search results are: ");
            DFS();

            //**************************************************************Question #4*****************************************************************

            Node node;
            int i = 0;
            for (i = 0; i < lGraph.Length; ++i)
            {
                node = new Node(i);
                game.Add(node);
            }
            for (i = 0; i < lGraph.Length; ++i)
            {
                int[] thisState = lGraph[i];
                int[] thisWeight = wGraph[i];

               
                for (int cCntr = 0; cCntr < thisState.Length; ++cCntr)
                {
                    game[i].AddEdge(thisWeight[cCntr], game[thisState[cCntr]]);

                }
            }
            List<Node> shortestPath = GetShortestPathDijkstra();

            Node printNode;

            Console.WriteLine("\nThe shortest path is: ");
            for(int n = 0; n <= 7; n++)
            {
                string stringNode;

                printNode = shortestPath.ElementAt(n);

                stringNode = NumToString(printNode.nState);

                Console.WriteLine($"{stringNode}\n");
                
            }
            
        }
        static public List<Node> GetShortestPathDijkstra()
        {
            DijkstraSearch();

            List<Node> shortestPath = new List<Node>();
            shortestPath.Add(game[7]);
            BuildShortestPath(shortestPath, game[7]);
            shortestPath.Reverse();
            return (shortestPath);

        }
        static public void BuildShortestPath(List<Node> list, Node targetNode)
        {
            if (targetNode.nearestToStart == null)
            {
                return;
            }

            list.Add(targetNode.nearestToStart);
            BuildShortestPath(list, targetNode.nearestToStart);
        }
        static public void DijkstraSearch()
        {
            Node start = game[0];
            start.minCostToStart = 0;

            List<Node> priorityQueue = new List<Node>();

            priorityQueue.Add(start);

            do
            {
                priorityQueue.Sort();

                Node node = priorityQueue.First();
                priorityQueue.Remove(node);

                foreach (Edge connectedNeighborNodes in node.edges)
                {
                    Node childNode = connectedNeighborNodes.connectedNode;
                    if (childNode.visited)
                    {
                        continue;
                    }

                    if (childNode.minCostToStart == int.MaxValue ||
                        node.minCostToStart + connectedNeighborNodes.cost < childNode.minCostToStart)
                    {
                        childNode.minCostToStart = node.minCostToStart + connectedNeighborNodes.cost;
                        childNode.nearestToStart = node;
                        if (!priorityQueue.Contains(childNode))
                        {
                            priorityQueue.Add(childNode);
                        }
                    }
                }

                node.visited = true;

                if (node == game[7])
                {
                    return;
                }
            } while (priorityQueue.Any());
        }
        //**************************************************************Question #5*****************************************************************

        //Method: Question5
        //Purpose: Question #5: Using the in-class examples from Week #9, implement the digraph as a linked list.
        //Restrictions: None
        private static void Question5()
        {
            LinkedList<(string, int)> list = new LinkedList<(string, int)>();
            for (int i = 0; i <= 7; i++)
            {
                list.AddLast((NumToString(i), i));
            }
        }
    }
}
