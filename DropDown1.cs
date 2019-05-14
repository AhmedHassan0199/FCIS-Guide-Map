using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class DropDown1 : MonoBehaviour
{
    public Dropdown dropdown;
    public Dropdown dropdown2;
    public static int SelectedIndexSource, SelectedIndexDest;
    void Start()
    {
        if (!GraphManager.Menu)
        {
            GraphManager.Menu = true;
            SceneManager.LoadScene(1);
        }
        else
        {
            if(!GraphManager.Menu2)
            {
                ConnectStairs();
                GraphManager.Menu2 = true;
            }
            GraphManager.ShortestPath.Clear();
            foreach(Vertex v in GraphManager.g.getAllVertices())
            {
                v.state = "unVisited";
                v.parent = null;
                v.distance = 0;
            }
            SelectedIndexDest = 0;
            SelectedIndexSource = 0;
            FillList();
        }
    }
    void FillList()
    {
        
        List<string> slist = new List<string>();
        for (int i = 0; i < GraphManager.VertexList.Count; i++)
        {
            slist.Add(GraphManager.VertexList[i].getData());
        }

        dropdown.AddOptions(slist);
        dropdown2.AddOptions(slist);

    }
    public List<Vertex> FillListFromFile( string Path)
    {
        List<Vertex> vertexList = new List<Vertex>();

        
        using (StreamReader sr = File.OpenText(Path))
        {
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                string[] Line = s.Split(',');
                vertexList.Add(new Vertex(Line[0]));
            }
           
        }
        return vertexList;

    }
    public void Dropdown_IndexChangedSource(int Index)
    {
        SelectedIndexSource = Index;
    }
    public void Dropdown_IndexChangedDest(int Index)
    {
        SelectedIndexDest = Index;
    }
    public void ConnectStairs()
    {
        GraphManager.g.insertEdge(GraphManager.VertexList[2], GraphManager.VertexList[33], 18);
        GraphManager.g.insertEdge(GraphManager.VertexList[11], GraphManager.VertexList[36], 18);
        GraphManager.g.insertEdge(GraphManager.VertexList[34], GraphManager.VertexList[100], 18);
        GraphManager.g.insertEdge(GraphManager.VertexList[37], GraphManager.VertexList[96], 18);
        GraphManager.g.insertEdge(GraphManager.VertexList[99], GraphManager.VertexList[143], 18);
        GraphManager.g.insertEdge(GraphManager.VertexList[95], GraphManager.VertexList[166], 18);
        GraphManager.g.insertEdge(GraphManager.VertexList[93], GraphManager.VertexList[165], 18);
        GraphManager.g.insertEdge(GraphManager.VertexList[94], GraphManager.VertexList[148], 18);
        GraphManager.g.insertEdge(GraphManager.VertexList[29], GraphManager.VertexList[144], 18);
        for (int i = 0; i < GraphManager.VertexList.Count; i++)
        {
            if (GraphManager.VertexList[i].getData().Contains("saied abdel wahab") || GraphManager.VertexList[i].getData().Contains("Elevator") || GraphManager.VertexList[i].getData().Contains("stairs") || GraphManager.VertexList[i].getData().Contains("walk through") || GraphManager.VertexList[i].getData().Contains("STAIRS") || GraphManager.VertexList[i].getData().Contains("Unamed") || GraphManager.VertexList[i].getData().Contains("WalkThrough") || GraphManager.VertexList[i].getData().Contains("walkthrough") || GraphManager.VertexList[i].getData().Contains("Stairs") || GraphManager.VertexList[i].getData().Contains("WalkBy") || GraphManager.VertexList[i].getData().Contains("arrow") || GraphManager.VertexList[i].getData().Contains("stairs"))
            {
                GraphManager.VertexList.Remove(GraphManager.VertexList[i]);
                i--;
            }
        }
    }

    public void StartDijkstra()
    {
        GraphManager.ShortestPath = GraphOperations.printShortestPath(GraphManager.g, GraphManager.VertexList[SelectedIndexSource], GraphManager.VertexList[SelectedIndexDest]);
        SceneManager.LoadScene(GraphManager.ShortestPath[0].SceneNumber);
    }
    public void StartBellManFord()
    {
        GraphOperations.BellmanFord(GraphManager.g, GraphManager.VertexList[SelectedIndexSource], GraphManager.VertexList[SelectedIndexDest]);
        SceneManager.LoadScene(GraphManager.ShortestPath[0].SceneNumber);
    }
    public void StartBFS()
    {
        GraphOperations.BfsShotestPath(GraphManager.g, GraphManager.VertexList[SelectedIndexDest], GraphManager.VertexList[SelectedIndexSource]);
        SceneManager.LoadScene(GraphManager.ShortestPath[0].SceneNumber);
    }
    public void StartFloydWarshall()
    {
        GraphOperations.FloydWarshall(GraphManager.g, GraphManager.VertexList[SelectedIndexSource], GraphManager.VertexList[SelectedIndexDest]);
        SceneManager.LoadScene(GraphManager.ShortestPath[0].SceneNumber);
    }
}
