using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damageAmount = 10;
    public bool isDestroyable = false;

    private void Start()
    {
        if (isDestroyable)
            Destroy(gameObject,2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<HealthBar>().TakeDamage(damageAmount);
            if(isDestroyable)
                Destroy(this.gameObject);
        }
    }
}
