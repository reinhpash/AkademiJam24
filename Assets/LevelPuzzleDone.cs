using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPuzzleDone : MonoBehaviour
{
    public PuzzleLevelManager manager;
    public GameObject _portal;
    public Animator _anim;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (manager.isCoffeBeanClaimed && manager.isMilkClaimed)
            {
                _anim.SetTrigger("PuzzleDone");
                _portal.gameObject.SetActive(true);
            }
        }
    }
}
