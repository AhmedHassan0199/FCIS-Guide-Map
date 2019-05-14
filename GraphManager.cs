using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.IO;
public static class GraphManager
{
    public static bool MoveCameraWithTarget = true,Ground = false, First = false, Second = false, Third = false, Credit = false, Fourth = false, TA = false, Menu = false, Menu2 = false;
    public static Graph g= new Graph();
    public static List<Vertex> VertexList = new List<Vertex>();
    public static List<Vertex> ShortestPath = new List<Vertex>();
    public static int TotalCost;
    public static void FillGraph(TextAsset VertexFilePath, TextAsset EdgesFilePath)
    {
            List<Vertex> vertexList = new List<Vertex>();
            string File = VertexFilePath.text;
            string[] AllLines = File.Split('\n');
            int Scenenumber=int.Parse(AllLines[0]);
            for(int i=1;i<AllLines.Length;i++)
            {
                string[] Line = AllLines[i].Split(',');
                Vertex temp = new Vertex(Line[0]);
                temp.SceneNumber = Scenenumber;
                temp.NodeIndex = int.Parse(Line[1]);
                vertexList.Add(temp);
                g.insertVertex(temp);
            }
        
             VertexList.AddRange(vertexList);
             File = EdgesFilePath.text;
             AllLines = File.Split('\n');


            for(int i=0;i<AllLines.Length;i++)
            {
                string[] Line = AllLines[i].Split(',');
                g.insertEdge(vertexList[int.Parse(Line[0])], vertexList[int.Parse(Line[1])], int.Parse(Line[2]));
            }
        
    }
}

