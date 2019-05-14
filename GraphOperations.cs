using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;



   public class GraphOperations
   {
    private static void printVertex(Vertex v)
        {
          Debug.Log("Vertex " + v.getData()+ " ");//Ꝋ(1)
    }

    private static void printEdge(Edge e)
        {
        Debug.Log(" edge " + e.getAdj().getData() + " of weight "+ e.getWeight());//Ꝋ(1)
    }

    public static void BFStraversal(Graph g, Vertex src, Vertex Dest)
    {
        
            Dictionary<Vertex, VertexColour> vertices = new Dictionary<Vertex, VertexColour>();
            foreach (Vertex v in g.getAllVertices())
            {
                if (!v.Equals(src))
                    vertices[v] = new VertexColour();
                else
                {
                    vertices[src] = new VertexColour();
                    vertices[src].color = VertexColour.grey;
                    vertices[src].dist = 0;
                    vertices[src].parent = null;
                }
            }

            Queue<Vertex> Q = new Queue<Vertex>();
            Q.Enqueue(src);

            while (Q.Count != 0)
            {
                Vertex u = Q.Dequeue();
                if (u.Equals(Dest)) return;
                foreach (Edge e in g.getNeighbours(u))
                {
                    Vertex v = e.getAdj();

                    if (vertices[v].color.Equals(VertexColour.white))
                    {
                        vertices[v].color = VertexColour.grey;
                        vertices[v].dist = vertices[u].dist + 1;
                        vertices[v].parent = u;
                        Q.Enqueue(v);
                    }
                }

                vertices[u].color = VertexColour.black;

            }
        
    }

    public static void Dijsktra(Graph g, Dictionary<Vertex, VertexColour> vertices, Vertex src, Vertex dest)// O(E LogV)
    {
        PriorityQueue<Vertex, int> Q = new PriorityQueue<Vertex, int>();
        foreach (Vertex v in g.getAllVertices())//O(V LogN)
        {
            vertices[v] = new VertexColour();//Ꝋ(1)
            if (v.Equals(src))//Ꝋ(1)
            {
                vertices[v].color = VertexColour.black;//Ꝋ(1)
                vertices[v].dist = 0;//Ꝋ(1)
            }
            Q.Enqueue(v, vertices[v].dist);//O(LogN)
        }

        while (Q.Count() != 0)//O(E LogV)
        {
            //Touch every vertex only once : O(LogV)
            Vertex u = Q.Dequeue();//Ꝋ(1)
            vertices[u].color = VertexColour.black;//Ꝋ(1)
            if (u.Equals(dest)) return;//Ꝋ(1)
            foreach (Edge e in g.getNeighbours(u)) //Ꝋ(E) " Maximum Iterations "
            {
                Vertex v = e.getAdj();//Ꝋ(1)
                int distToTry = vertices[u].dist + e.getWeight();//Ꝋ(1)
                if (vertices[v].color.Equals(VertexColour.white)//Ꝋ(1)
                    && vertices[v].dist > distToTry)
                {
                    Q.update_value(v, distToTry);//Ꝋ(1)
                    vertices[v].dist = distToTry;//Ꝋ(1)
                    vertices[v].parent = u;//Ꝋ(1)
                }
            }
        }

    }

    public static void printDijsktra(Dictionary<Vertex, VertexColour> vertices, Vertex v,List<Vertex> x)//O(V)
        {
            if (vertices[v].parent != null) printDijsktra(vertices, vertices[v].parent,x);//O(V)
             x.Add(v); //Ꝋ(1)
        }

    public static List<Vertex> printShortestPath(Graph g, Vertex src, Vertex dest) //O(E LogV)
        {
            List<Vertex> temp= new List<Vertex>(); //Ꝋ(1)
            Dictionary<Vertex, VertexColour> vertices = new Dictionary<Vertex, VertexColour>(); //Ꝋ(1)
            Dijsktra(g, vertices, src, dest); // O( E LogV)
            Debug.Log("Shortest Path from " + src.getData() + " to " + dest.getData() + " costs " + vertices[dest].dist); //Ꝋ(1)
            GraphManager.TotalCost = vertices[dest].dist;
            printDijsktra(vertices, dest,temp);//O(V)
            return temp; //Ꝋ(1)
        }

    public static void BellmanFord(Graph graph, Vertex source, Vertex Destination)//O(V*E)
    {
        int verticesCount = graph.numVertices(); //theta(1)
        int edgesCount = graph.numEdges(); //theta(1)
        Dictionary<Vertex, int> distance = new Dictionary<Vertex, int>(); //theta(1)
        List<Vertex> AllVertices = graph.getAllVertices(); //theta(1)
        Dictionary<Vertex, Vertex> Parent = new Dictionary<Vertex, Vertex>(); //theta(1)
        List<Edge> temp = new List<Edge>(); //theta(1)
        foreach (Vertex u in graph.getAllVertices()) // #iteration *body = v * neighbors = O(V * E)
        {
            foreach (Edge e in graph.getNeighbours(u)) //#iteration *body= E "neighbors" * theta(1) = O(neighbors)
            {
                e.Src = u; // theta(1)
                temp.Add(e);// theta(1)
            }
        }
        foreach (Vertex x in graph.getAllVertices()) // O(V)
        {
            distance[x] = int.MaxValue; // theta(1)
        }
        distance[source] = 0; //theta(1)
        Parent[source] = null; //theta(1)

        for (int i = 0; i < verticesCount; ++i) // #iteration * body = V * E = O(V*E)
        {
            foreach (Edge e in temp) //#iteration * body =E * theta(1)=O(E)
            {
                Vertex u = e.Src; //theta(1)
                Vertex v = e.getAdj(); //theta(1)
                int weight = e.getWeight(); //theta(1)
                if (distance[u] != int.MaxValue && distance[u] + weight < distance[v]) //theta(1)
                {
                    distance[v] = distance[u] + weight; //theta(1)
                    Parent[v] = u; //theta(1)
                }

            }
        }

        printPath(Parent, Destination); //O(V) 
        GraphManager.TotalCost = distance[Destination]; //theta(1)
    }

    private static void printPath(Dictionary<Vertex,Vertex> parent, Vertex v)//O(V)
   {
	    if (parent[v] != null)
	    printPath(parent, parent[v]);//O(V)

        GraphManager.ShortestPath.Add(v);//theta(1)
   }

    public static List<Vertex> BfsShotestPath(Graph g,Vertex source, Vertex destination)//O(V+E)
    {
        Queue<Vertex> Q = new Queue<Vertex>();//theta(1)
        Q.Enqueue(source);//theta(1)
        Vertex currentOne;//theta(1)
        while (Q.Count() != 0)//theta(V)
        {
            currentOne =  Q.Dequeue(); //theta(N)
            foreach (Edge e in g.getNeighbours(currentOne))//theta(Neighbours)
            {
                Vertex v = e.getAdj();//theta(1)
                int weight = e.getWeight();//theta(1)
                if (v.state == "unVisited")//theta(1)
                {
                    v.state = "Visited";//theta(1)
                    v.distance = currentOne.distance + weight;//theta(1)
                    v.parent = currentOne;//theta(1)
                    Q.Enqueue(v);//theta(1)
                }
                else if (v.state == "Visited")//theta(1)
                {
                    if (v.distance > currentOne.distance + weight)//theta(1)
                    {
                        v.distance = currentOne.distance + weight;//theta(1)
                        v.parent = currentOne;//theta(1)
                    }
                }

            }
            currentOne.state = "Finished";//theta(1)
        }
        GraphManager.TotalCost = destination.distance;//theta(1)
        return backTrack(destination, source);//O(V)
    }

    private static List<Vertex> backTrack(Vertex destination, Vertex source)//O(V)
    {
        List<Vertex> path = new List<Vertex>();//theta(1)
        Vertex currenOne = destination;//theta(1)
        while (currenOne.parent != null)//O(V)
        {
            GraphManager.ShortestPath.Add(currenOne);//theta(1)
            currenOne = currenOne.parent;//theta(1)
        }
        GraphManager.ShortestPath.Add(currenOne);//theta(1)

        return path;//theta(1)
    }

    public static void FloydWarshall(Graph graph, Vertex Source, Vertex Destination) // O(v^3)
    {
        List<Vertex> temp = graph.getAllVertices();// O(1)
        List<Edge> AllEdges = new List<Edge>();// O(1)
        List<List<int>> initDistances = new List<List<int>>();// O(1)
        foreach (Vertex u in graph.getAllVertices())// O(V*E)
        {
            foreach (Edge e in graph.getNeighbours(u))// O(E)
            {
                e.Src = u;// O(1)
                AllEdges.Add(e);// O(1)
            }
        }

        for (int i = 0; i < graph.getAllVertices().Count; i++)// O(V^2)
        {
            initDistances.Add(new List<int>());// O(1)
            for (int j = 0; j < graph.getAllVertices().Count; j++)// O(V)
            {
                initDistances[i].Add(999);// O(1)
            }
        }
        for (int i = 0; i < graph.getAllVertices().Count; i++)// O(V*E)
        {
            foreach (Edge e in AllEdges)// O(E)
            {
                if (e.getWeight() < initDistances[temp.IndexOf(e.Src)][temp.IndexOf(e.getAdj())])// O(1)
                    initDistances[temp.IndexOf(e.Src)][temp.IndexOf(e.getAdj())] = e.getWeight();// O(1)
            }
        }

        int[,] distance = new int[graph.numVertices(), graph.numVertices()];// O(1)
        int[,] path = new int[graph.numVertices(), graph.numVertices()];// O(1)

        for (int i = 0; i < graph.numVertices(); i++)// O(V^2)
        {
            for (int j = 0; j < graph.numVertices(); j++) // O(V)
            {
                distance[i, j] = initDistances[i][j];// O(1)
                path[i, j] = j;// O(1)
            }
        }

        for (int v = 0; v < graph.numVertices(); v++)// O(V)
        {
            distance[v, v] = 0;// O(1)
            path[v, v] = v;// O(1)
        }
        for (int k = 0; k < graph.numVertices(); k++)// theta(V^3)
        {
            for (int i = 0; i < graph.numVertices(); i++)// O(V^2)
            {
                for (int j = 0; j < graph.numVertices(); j++)// O(V)
                {
                    if (distance[i, k] + distance[k, j] < distance[i, j])// O(1)
                    {
                        distance[i, j] = distance[i, k] + distance[k, j];// O(1)
                        path[i, j] = path[i, k];// O(1)
                    }
                }
            }
        }
        List<int> SP = new List<int>();// O(1)
        SP = GetPath(temp.IndexOf(Source), temp.IndexOf(Destination), path);// O(V)
        for (int i = 0; i < SP.Count; i++)// O(Shortest Path Length)
        {
            GraphManager.ShortestPath.Add(graph.getAllVertices()[SP[i]]);// O(1)
        }
        GraphManager.TotalCost = distance[temp.IndexOf(Source), temp.IndexOf(Destination)];
        //Printfloyd(distance, graph.numVertices(),graph);
    }

    public static List<int> GetPath(int u, int v, int[,] path)// O(V)
    {
        List<int> temp = new List<int>();// O(1)
        temp.Add(u);// O(1)
        while (u != v) // O(V)
        {
            u = path[u, v];// O(1)
            temp.Add(u);// O(1)
        }
        return temp;// O(1)
    }

   }

    