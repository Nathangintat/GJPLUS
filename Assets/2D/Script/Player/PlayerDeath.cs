using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private readonly int lives = 3;
    
    public void Die(){
        if(GameSystem2D.Instance.deathCount >= 3) {
            FinalDeath();
            return;
        }
        GameSystem2D.Instance.deathCount++;

    }
    public void FinalDeath(){
        
    }
}
