using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PuzzleLevelManager : MonoBehaviour
{
    public GameObject CardPuzzleGameManager;
    public GameObject CardPuzzleGameManagerCanvas;
    public GameObject CollactibleHuds;
    private PlayerController playerController;

    [SerializeField]
    private Sprite coffeeClaimed;

    [SerializeField]
    private Sprite milkClaimed;

    public Image slidingImage;

    public bool isMilkClaimed;
    public bool isCoffeBeanClaimed;

    public bool isWin =false;
    public void Start()
    {
      playerController = GetComponent<PlayerController>();
    }

   
    void Update()
    {
        
    }

    public void CardGameStart()
    {
            GameObject player = GameObject.Find("Player");
            CollactibleHuds.SetActive(false);
            CardPuzzleGameManager.SetActive(true);
            CardPuzzleGameManagerCanvas.SetActive(true);
            if (player != null){
                PlayerController playerController = player.GetComponent<PlayerController>();
                if (playerController != null){ 
                    playerController.canMove = false;
                }
            }
    }

    public void CardGameWin()
    {
        isWin = true;
        CardPuzzleGameManager.SetActive(false);
        CardPuzzleGameManagerCanvas.SetActive(false);
        CollactibleHuds.SetActive(true);
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            PlayerController playerController = player.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.canMove = true;
            }
        }
        GameObject coffee = GameObject.Find("CollactibleHuds");
        if (coffee != null)
        {
            Image coffeeImage = coffee.GetComponentInChildren<Image>();
            coffeeImage.sprite = coffeeClaimed;
            isCoffeBeanClaimed = true;
        }
    }

    public void SlidingWin()
    {
        slidingImage.sprite = milkClaimed;
        isMilkClaimed = true;
    }
}
