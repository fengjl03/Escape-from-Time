using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InnerDoors5 : MonoBehaviour
{
    public GameObject key6;
    // Start is called before the first frame update
    void Start()
    {
        if (GameStatus.key6)
        {
            key6.SetActive(true);
        }
    }

    public void Change1()
    {
        GameStatus.show1 = 1;
    }
    public void Change2()
    {
        GameStatus.show1 = 2;
    }
    public void Change3()
    {
        GameStatus.show1 = 3;
    }
    public void Change4()
    {
        GameStatus.show1 = 4;
    }
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Blue5");
    }
}
