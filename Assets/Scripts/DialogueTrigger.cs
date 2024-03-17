using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Dialogue f_dialogue;

    private bool triggered = false;

    public Transform playerPos;
    public PlayerController Player;

    public CinemachineVirtualCamera BaristaCam;
    public CinemachineVirtualCamera MainCam;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            Player.canMove = false;
            triggered = true;
            Player.gameObject.transform.position = playerPos.position;
            Player.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            MainCam.gameObject.SetActive(false);
            BaristaCam.gameObject.SetActive(true);

            if (PlayerPrefs.GetInt("GameDone", 0) == 1)
            {
                f_dialogue.gameObject.SetActive(true);
                f_dialogue.StartDialogue();
            }
            else
                dialogue.StartDialogue();
        }
    }
   
}


