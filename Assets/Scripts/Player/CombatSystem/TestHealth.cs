using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHealth : MonoBehaviour
{
    public int health = 1;

    public void TakeDamage()
    {
        health--;

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
