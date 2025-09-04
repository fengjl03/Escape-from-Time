using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Box3 : MonoBehaviour
{
    public GameObject puzzlePanel;
    public GameObject dialogPanel;
    public Text dialogText;
    public GameObject key1;
    public GameObject key2;
    void Start()
    {
        if (GameStatus.key6)
        {
            key1.SetActive(false);
            key2.SetActive(true);
        }
    }
    private void OnMouseDown()
    {
        if (!GameStatus.key6)
        {
            puzzlePanel.SetActive(true);
            ///if (audioSource!= null)
            {
                ///audioSource.Play();
            }
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