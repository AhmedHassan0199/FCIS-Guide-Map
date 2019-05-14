using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace AdjacencyList
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph();
            Vertex a = new Vertex("A");
            g.insertVertex(new Vertex("A"));
            Vertex b = new Vertex("B");
            g.insertVertex(b);
            Vertex c = new Vertex("c");
            g.insertVertex(c);
            Vertex d = new Vertex("D");
            g.insertVertex(d);
            Vertex e = new Vertex("E");
            g.insertVertex(e);

            g.insertEdge(a, b, 10);
            g.insertEdge(a, c, 3);
            g.insertEdge(b, c, 4);
            g.insertEdge(b, d, 2);
            g.insertEdge(c, e, 2);
            g.insertEdge(c, d, 8);
            g.insertEdge(d, e, 9);

            //GraphOperations.BFStraversal(g, a);

            Console.WriteLine("\t****************************************************\n");

            GraphOperations.printShortestPath(g, a, d);

            Console.WriteLine("\n\t****************************************************\n");
            /*
            string m = "success";
            if (g.areAdjacent(b, e)) m = "fail";
            Console.WriteLine(m);
            */
        }
    }
}
