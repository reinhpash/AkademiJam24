using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour
{
    public bool isLoadLevel1;
    public bool isLoadLevel2;
    public bool isLoadLevel3;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isLoadLevel1)
            {
                SceneLoader.instance.LoadScene("PuzzleLevel");
                return;
            }

            if (isLoadLevel2)
            {
                SceneLoader.instance.LoadScene("Level2");
                return;
            }

            if (isLoadLevel3)
            {
                PlayerPrefs.SetInt("GameDone", 1);
                SceneManager.LoadScene("Level 0");
                return;
            }

        }
    }
}
