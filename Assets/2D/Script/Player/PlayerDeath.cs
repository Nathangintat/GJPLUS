using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private GameObject DeathScreen;
    public void Die(){
        GameSystem2D.Instance.MonsterSFX();
        GameSystem2D.Instance.ScreamSFX();
        DeathScreen.SetActive(true);
        StartCoroutine(DieTimer());
    }
    IEnumerator DieTimer()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(1);
    }
}
