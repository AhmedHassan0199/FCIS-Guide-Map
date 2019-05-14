using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;



public class Graph
{

    int v;
    int e;
    Dictionary<Vertex, HashSet<Edge>> dict;

    public Graph()
    {
        e = 0;//Ꝋ(1)
        v = 0;//Ꝋ(1)
        dict = new Dictionary<Vertex, HashSet<Edge>>();//Ꝋ(1)
    }



    public void insertVertex(Vertex v)
    {
        dict[v] = new HashSet<Edge>();//Ꝋ(1)
        this.v += 1;//Ꝋ(1)
    }

    public void insertEdge(Vertex v1, Vertex v2, int w)
    {
        dict[v1].Add(new Edge(v2, w));//Ꝋ(1)
        dict[v2].Add(new Edge(v1, w));//Ꝋ(1)
        this.e += 1;//Ꝋ(1)
    }


    public bool areAdjacent(Vertex v1, Vertex v2)
    {
        return dict[v1].Contains(new Edge(v2, 0));//O(E)
    }

    public void removeEdge(Vertex v1, Vertex v2)
    {
        dict[v1].Remove(new Edge(v2, 0));//Ꝋ(1)
        dict[v2].Remove(new Edge(v1, 0));//Ꝋ(1)
        this.e = this.e - 1;//Ꝋ(1)
    }

    public void removeVertex(Vertex v)//Total = #Iterations * Ꝋ(1) = Ꝋ(Neighbours)
    {
        foreach (Edge e in dict[v])
        {
            Vertex n = e.getAdj();//Ꝋ(1)
            removeEdge(n, v);//Ꝋ(1)
        }
        dict.Remove(v);//Ꝋ(1)
        this.v = this.v - 1;//Ꝋ(1)
    }

    public HashSet<Edge> getNeighbours(Vertex v1)
    {
        return new HashSet<Edge>(dict[v1]);//Ꝋ(1)
    }

    public List<Vertex> getAllVertices()
    {
        return new List<Vertex>(dict.Keys);//O(Keys)
    }

    public int numVertices()
    {
        return v;//Ꝋ(1)
    }

    public int numEdges()
    {
        return e;//Ꝋ(1)
    }
}
    

