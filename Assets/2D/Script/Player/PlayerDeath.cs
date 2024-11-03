using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private readonly int lives = 3;
    
    public void Die(){
        if(GameSystem2D.Instance.deathCount >= lives) {
            FinalDeath();
            return;
        }
        GameSystem2D.Instance.deathCount++;
        Debug.Log("Die");
    }
    public void FinalDeath(){
        Debug.Log("Final Death");
    }
}
