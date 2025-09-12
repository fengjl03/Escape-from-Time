using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dialogue4 : MonoBehaviour
{
    public Text dialogueText;             // 对话框文字
    public string[] dialogueLines;        // 所有对话内容
    private int currentLineIndex = 0;


    void Start()
    {

        if (dialogueLines.Length > 0)
        {
            dialogueText.text = dialogueLines[0];
        }
    }

    public void OnDialogueClick()
    {
        currentLineIndex++;

        if (currentLineIndex < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLineIndex];
        }
        else
        {
            SceneManager.LoadScene("EndScene1");
        }
    }
    

}
