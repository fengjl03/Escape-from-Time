using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Keys : MonoBehaviour
{

    // Start is called before the first frame update
    public GameObject key1;
    public GameObject key2;
    public GameObject key3;
    public GameObject key4;
    public GameObject key5;
    public GameObject key6;
    void Start()
    {
        key1.SetActive(false);
        key2.SetActive(false);
        key3.SetActive(false);
        key4.SetActive(false);
        key5.SetActive(false);
        key6.SetActive(false);
        if (GameStatus.key1)
        {
            if (!GameStatus.isRed3Open)
            {
                key1.SetActive(true);
            }
        }
        if (GameStatus.key2)
        {
            if (!GameStatus.isBlue3Open)
            {
                key2.SetActive(true);
            }
        }
        if (GameStatus.key3)
        {
            if (!GameStatus.isWhite2Open)
            {
                key3.SetActive(true);
            }
        }
        if (GameStatus.key4)
        {
            if (!GameStatus.isRed5Open)
            {
                key4.SetActive(true);
            }
        }
        if (GameStatus.key5)
        {
            if (!GameStatus.isBlue5Open)
            {
                key5.SetActive(true);
            }
        }
        if (GameStatus.key6)
        {
            if (!GameStatus.isWhite3Open)
            {
                key6.SetActive(true);
            }
        }

    }
    public void OpenRed3()
    {
        key1.transform.DOMove(new Vector3(-6, -1, 0), 1f).OnComplete(() =>
        {
            key1.SetActive(false);
            GameStatus.isRed3Open = true;
            SceneManager.LoadScene("Red3");
        });
    }
    public void OpenBlue3()
    {
        key2.transform.DOMove(new Vector3(6, -1, 0), 1f).OnComplete(() =>
        {
            key2.SetActive(false);
            GameStatus.isBlue3Open = true;
            SceneManager.LoadScene("Blue3");
        });
    }
    public void OpenWhite2()
    {
        key3.transform.DOMove(new Vector3(0, -1, 0), 1f).OnComplete(() =>
        {
            key3.SetActive(false);
            GameStatus.isWhite2Open = true;
            SceneManager.LoadScene("White2");
        });
    }
    public void OpenRed5()
    {
        key4.transform.DOMove(new Vector3(-6, -1, 0), 1f).OnComplete(() =>
        {
            key4.SetActive(false);
            GameStatus.isRed5Open = true;
            
        });
        key5.transform.DOMove(new Vector3(6, -1, 0), 1f).OnComplete(() =>
        {
            key5.SetActive(false);
            GameStatus.isBlue5Open = true;
            SceneManager.LoadScene("Red5");
        });
    }
    public void OpenBlue5()
    {
        key4.transform.DOMove(new Vector3(-6, -1, 0), 1f).OnComplete(() =>
        {
            key4.SetActive(false);
            GameStatus.isRed5Open = true;

        });
        key5.transform.DOMove(new Vector3(6, -1, 0), 1f).OnComplete(() =>
        {
            key5.SetActive(false);
            GameStatus.isBlue5Open = true;
            SceneManager.LoadScene("Blue5");
        });
    }
    public void OpenWhite3()
    {
        key6.transform.DOMove(new Vector3(0, -1, 0), 1f).OnComplete(() =>
        {
            key6.SetActive(false);
            GameStatus.isWhite3Open = true;
            SceneManager.LoadScene("White3");
        });
        // Update is called once per frame

    }
}
