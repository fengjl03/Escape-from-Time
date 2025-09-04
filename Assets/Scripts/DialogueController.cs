using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public Text dialogueText;             // 对话框文字
    public string[] dialogueLines;        // 所有对话内容
    private int currentLineIndex = 0;
    public GameObject key;
    public GameObject key2;


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
            key.SetActive(true);
            MoveKeyToTopLeft();
        }
    }
    void MoveKeyToTopLeft()
    {
        // 使用DoTween的回调函数在动画结束后禁用钥匙对象
        key.transform.DOMove(new Vector3(-8, 4, 0), 2f).OnComplete(() => {
            key.SetActive(false);
            key2.SetActive(true);
            gameObject.SetActive(false);
            SceneManager.LoadScene("MainScene");
        });
    }
}
