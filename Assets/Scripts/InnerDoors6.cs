using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InnerDoors6 : MonoBehaviour
{
    public GameObject show1;
    public GameObject show2;
    public GameObject show3;
    public GameObject show4;
    public GameObject key6;    
    void Start()
    {  
        if (GameStatus.key6)
        {
            key6.SetActive(true);
        }
    
        switch (GameStatus.show1)
        {
            case 1:
                show1.SetActive(true);
                break;
            case 2:
                show2.SetActive(true);
                break;
            case 3:
                show3.SetActive(true);
                break;
            case 4:
                show4.SetActive(true);
                break;
        }
    }

    
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Red5");
    }
}
