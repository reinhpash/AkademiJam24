using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayer : MonoBehaviour
{
    private void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        p.transform.position = this.transform.position;
        p.GetComponent<HealthBar>().health = p.GetComponent<HealthBar>().maxHealth;
    }
}
