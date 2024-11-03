using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSession : MonoBehaviour
{
    [SerializeField] float health = 5f;
    [SerializeField] bool isDead = false;
    
    void Awake()
    {
        int numGameSession = FindObjectsOfType<PlayerSession>().Length;
        
        if (numGameSession > 1 )
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
    }
    
    public bool GetIsDead()
    {
        return isDead;
    }

    public void SetIsDead(bool isDead)
    {
        this.isDead = isDead;
    }

    public float GetHealth()
    {
        return health;
    }

    public void ProcessPlayerDeath()
    {
        if ( health >= 1 )
        {
            TakeLife();
        }

        else
        {
            ResetGameSession();
        }
    }

    void TakeLife()
    {
        health--;
        isDead = false;
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
