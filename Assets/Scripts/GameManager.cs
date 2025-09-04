using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        // 单例模式，确保只有一个 GameManager
            Instance = this;
        
            //DontDestroyOnLoad(gameObject); // 切场景时不销毁
    }
    
}

