using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public List<Transform> currentWeaponPositions = new List<Transform>();

    public Transform GetRandomPos()
    {
        if (currentWeaponPositions.Count == 0)
            return null;

        int randomIndex = Random.Range(0, currentWeaponPositions.Count);
        Transform randomPos = currentWeaponPositions[randomIndex];
        currentWeaponPositions.RemoveAt(randomIndex);
        return randomPos;
    }
}
