using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        // ����ģʽ��ȷ��ֻ��һ�� GameManager
            Instance = this;
        
            //DontDestroyOnLoad(gameObject); // �г���ʱ������
    }
    
}

