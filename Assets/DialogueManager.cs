using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public Dialogue main;
    public Dialogue finished;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("GameDone"))
        {
            if (PlayerPrefs.GetInt("GameDone", 0) == 1)
            {
                main.gameObject.SetActive(false);
                finished.gameObject.SetActive(true);
            }
        }
    }
}
