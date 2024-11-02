using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem2D : MonoBehaviour
{
    public static GameSystem2D Instance;
    public int deathCount = 0;
    private void Awake() {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else {
            Destroy(this);
        }
    }
}
