using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public int damageAmount = 10;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HealthBar healthBar;
            if (other.gameObject.TryGetComponent(out healthBar))
            {
                healthBar.TakeDamage(damageAmount);
            }
            Rigidbody rb;
            if (TryGetComponent<Rigidbody>(out rb))
            {
                rb.useGravity = true;
                rb.velocity = Vector3.zero;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Rigidbody rb;
            if (TryGetComponent<Rigidbody>(out rb))
            {
                rb.isKinematic = true;
            }
            BoxCollider boxCollider;
            if (TryGetComponent<BoxCollider>(out boxCollider))
            {
                boxCollider.isTrigger = true;
            }
            Destroy(this.gameObject);
        }
    }

}
