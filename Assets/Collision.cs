using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public PuzzleLevelManager _PuzzleLevelManagerScript;
    public SlidingPuzzleGameManager _SlidingPuzzleGameManager;

    public GameObject MainCam;
    public GameObject SlidingCam;

    public bool isSliding = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (isSliding)
            {
                if (_SlidingPuzzleGameManager.isDone == true)
                    return;
                _SlidingPuzzleGameManager.gameObject.SetActive(true);
                SlidingCam.SetActive(true);
                MainCam.SetActive(false);
            }
            else
            {
                if (_PuzzleLevelManagerScript.isWin == true)
                    return;
                _PuzzleLevelManagerScript.CardGameStart();

            }

        }
    }

    public void OnSlidingDone()
    {
        SlidingCam.SetActive(false);
        MainCam.SetActive(true);
    }

}
