using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private GameObject DeathScreen;
    public void Die(){
        DeathScreen.SetActive(true);
        gameObject.SetActive(false);
        SceneManager.LoadScene(1);
    }
}
