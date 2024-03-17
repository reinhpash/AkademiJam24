using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private PuzzleLevelManager _PuzzleLevelManagerScript;
    private void Start()
    {
        _PuzzleLevelManagerScript = GameObject.Find("PuzzleLevelManager").GetComponent<PuzzleLevelManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (_PuzzleLevelManagerScript.isWin == true)
                return;
            _PuzzleLevelManagerScript.CardGameStart();
        }
    }

}
