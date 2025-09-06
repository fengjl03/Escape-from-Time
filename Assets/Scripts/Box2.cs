using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Box2 : MonoBehaviour
{
    public GameObject puzzlePanel;
    public AudioSource audioSource;
    public GameObject dialogPanel;
    public Text dialogText;
    public GameObject key1;
    public GameObject key2;

    void Start()
    {
        if (GameStatus.key3)
        {
            key1.SetActive(false);
            if (!GameStatus.isWhite2Open)
            {
                key2.SetActive(true);
            }
        }
    }
    private void OnMouseDown()
    {
        if (!GameStatus.key3)
        {
            puzzlePanel.SetActive(true);
        }

        else
        {
            ShowDialog("Already have the key");
        }
        
    }
    public void ShowDialog(string message)
    {
        dialogPanel.SetActive(true);
        dialogText.text = message;
        StartCoroutine(HideDialogAfterSeconds(2f));
    }

    IEnumerator HideDialogAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        dialogPanel.SetActive(false);
    }
}
