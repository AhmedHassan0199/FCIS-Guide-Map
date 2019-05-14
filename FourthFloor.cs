using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.UI;

public class FourthFloor : MonoBehaviour
{
    public GameObject LoadingImage;
    public static bool DrawNow = false;
    public Text Cost;
    string path;
    public GameObject NodeContainer;
    public TextAsset EdgesFile;
    public TextAsset VertexFile;
    string EdgesFilePath;
    string VertexFilePath;
    public static GameObject[] TempNodes;
    public static List<GameObject> Nodes;
    List<Vertex> tempVertex = new List<Vertex>();
    // Start is called before the first frame update
    void Awake()
    {
        TempNodes = GameObject.FindGameObjectsWithTag("Node");
        int i = 0;
        foreach (Transform child in NodeContainer.transform.Cast<Transform>().OrderBy(t => t.GetSiblingIndex()))
        {
            if (i < TempNodes.Length)
                TempNodes[i] = child.gameObject;
            i++;
        }
        Debug.Log(TempNodes.Length);
    }
    void Start()
    {
        if (!GraphManager.Fourth)
        {
            GraphManager.Fourth = true;
            GraphManager.FillGraph(VertexFile, EdgesFile);
            SceneManager.LoadScene(7);
        }
        else
        {

            LoadingImage.SetActive(false);

            Nodes = new List<GameObject>();
            Debug.Log(TempNodes.Length);
            for (int i = 0; i < GraphManager.ShortestPath.Count; i++)
            {
                if (GraphManager.ShortestPath[i].SceneNumber == SceneManager.GetActiveScene().buildIndex)
                {
                    Nodes.Add(TempNodes[GraphManager.ShortestPath[i].NodeIndex]);
                }
            }
            DrawNow = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
       // Cost.text = "Total Seconds to arrive : " + GraphManager.TotalCost;
    }
    public List<Vertex> FillGraphFromFile(Graph g,string Path,GameObject[] tempNodes)
    {
        int Sceneindex;
        List<Vertex> vertexList= new List<Vertex>();
        StreamReader sr2 = File.OpenText(Path);
        Sceneindex = int.Parse(sr2.ReadLine());
        for (int i = 0; i < tempNodes.Length; i++)
        {
            Vertex temp = new Vertex(tempNodes[i].name);
            temp.NodeObject = tempNodes[i];
            temp.SceneNumber = Sceneindex;
            g.insertVertex(temp);
        }
        vertexList.AddRange(g.getAllVertices());

        using (StreamReader sr = File.OpenText(Path))
        {
            sr.ReadLine();
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] Line = s.Split(',');
                    g.insertEdge(vertexList[int.Parse(Line[0])], vertexList[int.Parse(Line[1])], int.Parse(Line[2]));
                }
            
        }
        return vertexList;
    }
    public void FillFileWithNames(string Path, GameObject[] tempNodes)
    {
        using (StreamWriter sw = new StreamWriter(Path))
        {
            for(int i=0;i<tempNodes.Length;i++)
            {
                sw.WriteLine(tempNodes[i].name+','+i);
            }
        }
    }
    public static void drawConnection(GameObject first, GameObject sec)
    {
        Vector3 start = first.GetComponent<Transform>().position;
        Vector3 end = sec.GetComponent<Transform>().position;
        GameObject tempLine = new GameObject();
        tempLine.AddComponent<LineRenderer>();
        LineRenderer lr = tempLine.GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("GUI/Text Shader"));
        lr.startColor = Color.red;
        lr.endColor = Color.red;
        lr.startWidth = 4f;
        lr.endWidth = 4f;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        lr.useWorldSpace = true;
    }
}
