using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayButton () {
        SceneManager.LoadScene(1);
    }

    public void QuitButton () {
        Application.Quit();
    }
}
