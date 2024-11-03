using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Animator door;
    [SerializeField] GameObject openText;
    [SerializeField] AudioSource doorSound;
    
    private bool inReach;
    
    void Start()
    {
        inReach = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            openText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
        }
    }





    void Update()
    {

        if (inReach && Input.GetKeyDown(KeyCode.E))
        {
            DoorOpens();
        }

        else
        {
            DoorCloses();
        }




    }
    void DoorOpens ()
    {
        door.SetBool("open", true);
        door.SetBool("closed", false);
        doorSound.Play();

    }

    void DoorCloses()
    {
        door.SetBool("open", false);
        door.SetBool("closed", true);
    }
}
