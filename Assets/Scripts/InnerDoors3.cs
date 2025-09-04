using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InnerDoors3 : MonoBehaviour
{
    public GameObject puzzleUI; // мов╖бжелUI

    private void OnMouseDown()
    {
        if (!GameStatus.isinner3Open)
        {
            puzzleUI.SetActive(true);

        }
        else
        {
            SceneManager.LoadScene("Red4");
        }
    }
}

