using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private static readonly int Open = Animator.StringToHash("Open");
    private static readonly int Closed = Animator.StringToHash("Closed");
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
        door.SetBool(Open, true);
        door.SetBool(Closed, false);
        doorSound.Play();

    }

    void DoorCloses()
    {
        door.SetBool(Open, false);
        door.SetBool(Closed, true);
    }
}
