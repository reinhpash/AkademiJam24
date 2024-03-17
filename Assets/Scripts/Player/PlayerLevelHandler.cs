using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLevelHandler : MonoBehaviour
{
    public int currentLevel = 1;
    public int maxLevel = 10;
    public float experience = 0;
    public float experienceToNextLevel = 100;
    public UnityEvent OnLevelUp;
    public float expAmountPer = 20f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EXP"))
        {
            Destroy(other.gameObject);
            CollectObject(expAmountPer);
        }
    }

    public void CollectObject(float expAmount)
    {
        experience += expAmount;
        if (experience >= experienceToNextLevel)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        if (currentLevel < maxLevel)
        {
            currentLevel++;
            experience -= experienceToNextLevel;
            experienceToNextLevel = CalculateNextLevelExperience();
            OnLevelUp.Invoke();
        }
    }

    float CalculateNextLevelExperience()
    {
        return experienceToNextLevel * 1.2f;
    }
}
