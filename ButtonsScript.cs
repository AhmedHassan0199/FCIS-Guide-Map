using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsScript : MonoBehaviour
{
    public   GameObject Panel;
    public  Text NodeName;
   
    public void NodesOnClick()
    {
        NodeName.text= EventSystem.current.currentSelectedGameObject.name;
        Panel.SetActive(true);
    }
    public void Credits()
    {
        SceneManager.LoadScene(8);
    }
    public void ExitPanel()
    {
        Panel.SetActive(false);
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
        GraphManager.ShortestPath.Clear();
    }
    public void FirstFloorStairs()
    {
        SceneManager.LoadScene(2);
    }
    public void FirstFloorStairsToCredit()
    {
        SceneManager.LoadScene(5);
    }
    public void FirstFloorDownStairs()
    {
        SceneManager.LoadScene(1);
    }
    public void SecondFloorStairs()
    {
        SceneManager.LoadScene(3);
    }
    public void SecondFloorDownStairs()
    {
        SceneManager.LoadScene(2);
    }
    public void ThirdFloorStairs()
    {
        SceneManager.LoadScene(4);
    }
    public void ThirdFloorDownStairs()
    {
        SceneManager.LoadScene(3);
    }
    public void FromCreditToSecond()
    {
        SceneManager.LoadScene(3);
    }
    public void FromCreditToGround()
    {
        SceneManager.LoadScene(1);
    }
    public void FromSecondToCredit()
    {
        SceneManager.LoadScene(5);
    }
    public void FromSecondToFirst()
    {
        SceneManager.LoadScene(2);
    }
    public void FromSecondToTAs()
    {
        SceneManager.LoadScene(7);
    }
    public void FourthToThird()
    {
        SceneManager.LoadScene(4);
    }
    public void TAsToSecond()
    {
        SceneManager.LoadScene(3);
    }
}
