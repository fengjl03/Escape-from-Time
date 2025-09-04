using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Return : MonoBehaviour
{

    public void Return1()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void Return2()
    {
        SceneManager.LoadScene("Red1");
    }
    public void Return3()
    {
        SceneManager.LoadScene("Blue1");
    }
    public void Return4()
    {
        SceneManager.LoadScene("Red3");
    }
    public void Return5()
    {
        SceneManager.LoadScene("Blue3");
    }
}
