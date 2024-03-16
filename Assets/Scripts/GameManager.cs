
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;

    [SerializeField]
    private Sprite bgimage, bgimageconfirm;

    public Sprite[] cards;


    public List<Sprite> cardList = new List<Sprite>();

    public List<Button> _btns = new List<Button>();

    public GameObject GameWinPopUp, GameLosePopUp; 

    private bool firstGuess, secondGuess;

    private int countGuesses;
    private int countCorrectGuesses;
    private int gameGuesses;
    private int Guesses;

    private int firstGuessIndex, secondGuessIndex;

    private string firstGuessPuzzle, secondGuessPuzzle;


    private void Awake()
    {
        cards = Resources.LoadAll<Sprite>("MatchPuzzleElements/");
    }
    void Start()
    {
        getButtons();
        AddListeners();
        AddCardList();
        Shuffle(cardList);
        gameGuesses = cardList.Count / 2;
        Guesses = 2;
    }

    public void tryAgainBtnClick()
    {
        GameLosePopUp.SetActive(false);
        Shuffle(cardList);
        GameObject[] cards = GameObject.FindGameObjectsWithTag("puzzleCard");

        for (int i = 0; i < cards.Length; i++)
        {
            _btns.Add(cards[i].GetComponent<Button>());
            _btns[i].image.sprite = bgimage;
            _btns[i].interactable = true;
        }
        Guesses = 2;
        countCorrectGuesses = 0;

    }

    private void Update()
    {
        text.text = Guesses.ToString();
    }

    void AddCardList()
    {
        int looper = _btns.Count;
        int index = 0;

        for (int i = 0; i < looper; i++)
        {
            if (index == looper/2)
            {
                index = 0;   
            }
            cardList.Add(cards[index]);
            index++;
        }
    }

    void getButtons()
    {
        GameObject[] cards = GameObject.FindGameObjectsWithTag("puzzleCard");

        for (int i = 0; i < cards.Length; i++)
        {
            _btns.Add(cards[i].GetComponent<Button>());
            _btns[i].image.sprite = bgimage;
        }
    }

    void AddListeners()
    {
        foreach(Button b in _btns)
        {
            b.onClick.AddListener(() => pickCard());
        }
    }
    public void pickCard()
    {

        if(!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            firstGuessPuzzle = cardList[firstGuessIndex].name;

            _btns[firstGuessIndex].image.sprite = cardList[firstGuessIndex];
        }
        else if(!secondGuess)
        {
            secondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            secondGuessPuzzle = cardList[secondGuessIndex].name;

            _btns[secondGuessIndex].image.sprite = cardList[secondGuessIndex];

            if (firstGuessPuzzle == secondGuessPuzzle)
            {
                Debug.Log("dogru tahmin");
            }
            else
            {
                Debug.Log("yanlis tahmin");
                Guesses--;
                if (Guesses == 0)
                {
                    checkTheGameFinished();
                }
            }

            StartCoroutine(checkThePuzzleMatch());
        }

    }

    IEnumerator checkThePuzzleMatch()
    {
        yield return new WaitForSeconds(0.5f);

        if (firstGuessPuzzle == secondGuessPuzzle){
            yield return new WaitForSeconds(0.5f);
            _btns[firstGuessIndex].interactable = false;
            _btns[secondGuessIndex].interactable = false;


            _btns[firstGuessIndex].image.sprite = bgimageconfirm;
            _btns[secondGuessIndex].image.sprite = bgimageconfirm;


            checkTheGameFinished();
        }
        else
        {
            _btns[firstGuessIndex].image.sprite = bgimage;
            _btns[secondGuessIndex].image.sprite = bgimage;
           
        }
        yield return new WaitForSeconds(0.5f);

        firstGuess = secondGuess = false;
    }

    void checkTheGameFinished()
    {
        if (Guesses == 0)
        {
            Debug.Log("Tekrar dene");
            GameLosePopUp.SetActive(true);
        }
        countCorrectGuesses++;
            if (countCorrectGuesses == gameGuesses)
            {
                Debug.Log("oyun bitti");
                GameWinPopUp.SetActive(true);
            }

    }

    void Shuffle(List<Sprite> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

   

    public void closeBtnClick()
    {
        GameWinPopUp.SetActive(false);
       
    }
}
