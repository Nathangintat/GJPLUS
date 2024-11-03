using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class HouseInteract : MonoBehaviour, IInteractable
{
    [SerializeField] int houseSceneId = 0;
    public void Interact(){
        SceneManager.LoadScene(houseSceneId);
    }
}
