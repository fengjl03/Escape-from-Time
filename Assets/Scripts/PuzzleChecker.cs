using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PuzzleChecker : MonoBehaviour
{
    public string[] correctOrder = { "Icon1", "Icon2", "Icon3", "Icon4", "Icon5" };
    public GameObject key1;
    public GameObject key2;
    
    
    public void CheckOrder()
    {
        bool isCorrect = true;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).name != correctOrder[i])
            {
                isCorrect = false;
                break;
            }
        }

        if (isCorrect)
        {
            Debug.Log("解密成功！");
            Box2 box2=FindObjectOfType<Box2>();
            box2.ShowDialog("Get a key for the white door on 3:45");
            gameObject.transform.parent.gameObject.SetActive(false); // 关闭界面
            
            key1.transform.DOMove(new Vector3(-8, 4, 0), 2f).OnComplete(() =>
            {
                key1.SetActive(false);
                key2.SetActive(true);
                GameStatus.key3 = true;
            });
        }
    }
     
}
