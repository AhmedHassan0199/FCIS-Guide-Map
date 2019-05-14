using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    string Path = @"Assets\Test.txt";
    public InputField Sindex, Dindex;
    // Start is called before the first frame update
    void Start()
    {
        
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    public void FillFileWithNames(string Path,List<Vertex> x)
    {
        using (StreamWriter sw = new StreamWriter(Path))
        {
            for (int i = 0; i < x.Count; i++)
            {
                sw.WriteLine(x[i].getData() + ',' + i);
            }
        }
    }
    
}
