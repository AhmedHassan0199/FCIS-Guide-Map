using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{

    string VertexFilePath = @"E:\Ahmed labtop 21-12-2018\Algo Project\ProjectAlgo\Assets\CreditFloor(Vertex).txt";
    string EdgesFilePath = @"E:\Ahmed labtop 21-12-2018\Algo Project\ProjectAlgo\Assets\CreditFloor(Edges).txt";
    GameObject[] Nodes, TempNodes;
    List<Vertex> tempVertex = new List<Vertex>();
    private void Awake()
    {
        TempNodes = GameObject.FindGameObjectsWithTag("Node");
    }
    void Start()
    {/*
        if (!GraphManager.two)
        {
            GraphManager.two = true;
            GraphManager.FillGraph(VertexFilePath, EdgesFilePath);
            SceneManager.LoadScene(2);
        }
        else
        {


            List<Vertex> vertexList = new List<Vertex>();
            vertexList = GraphManager.g.getAllVertices();
            tempVertex.AddRange(GraphOperations.printShortestPath(GraphManager.g, vertexList[0], vertexList[40]));
            Nodes = new GameObject[tempVertex.Capacity];


            for (int i = 0; i < Nodes.Length; i++)
            {
                Nodes[i] = TempNodes[tempVertex[i].NodeIndex];
            }
            for (int i = 0; i < Nodes.Length - 1; i++)
            {
                if (tempVertex[i].SceneNumber == tempVertex[i].SceneNumber)
                    x.drawConnection(Nodes[i], Nodes[i + 1]);
            }
        }
    */}

    void Update()
    {
        
    }

}
