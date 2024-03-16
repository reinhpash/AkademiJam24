using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    [Header("Base settings")]
    public float coolDownTime = 2f;
    protected bool isReadyForAttack = false;
    private float currentCoolDownTime = 0f;

    [Header("Weapon Settings")]
    public string weaponName;
    public bool isRotator = true;
    public bool isGun = false;
    public float detectionRadius = 10f;
    public string enemyTag = "Enemy";

    [Header("Rotator Settings")]
    public float rotationSpeed = 10f;

    [Header("Gun Settings")]
    public int bulletAmount = 1;
    private int currentBullets = 0;
    public float bulletDelay = .2f;
    public float maxDistance = 10f;
    bool isAttacking = false;


    protected virtual void Tick()
    {
        if (!isReadyForAttack && !isAttacking)
        {
            DoCoolDown();
        }

        if (isRotator)
        {
            RotatorWeapon();
        }


        if (isGun)
        {

            GunWeapon();
        }
    }

    IEnumerator DoAttack()
    {
        isAttacking = true;

        while (currentBullets < bulletAmount)
        {
            Attack();
            currentBullets++;
            yield return new WaitForSeconds(bulletDelay);
        }

        currentBullets = 0;
        currentCoolDownTime = 0f;
        ResetReadyForAttack();
        isAttacking = false;
        StopCoroutine(DoAttack());
    }

    protected virtual void DoCoolDown()
    {
        if (currentCoolDownTime > coolDownTime && !isReadyForAttack)
        {
            isReadyForAttack = true;
            if (!isAttacking)
                StartCoroutine(DoAttack());

        }
        else
        {
            currentCoolDownTime += Time.deltaTime;

        }
    }

    protected void ResetReadyForAttack() => isReadyForAttack = false;

    public void RotatorWeapon()
    {
        this.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    public void GunWeapon()
    {
        LookAtClosestEnemy();
    }

    protected virtual void Attack()
    {

    }


    public void LookAtClosestEnemy()
    {
        GameObject nearestEnemy = FindNearestEnemy();

        if (nearestEnemy != null)
        {
            float distanceToEnemy = Vector3.Distance(nearestEnemy.transform.position, transform.position);
            if (distanceToEnemy <= maxDistance)
            {
                Vector3 direction = nearestEnemy.transform.position - transform.position;
                //direction.y = 0;
                transform.forward = direction.normalized;
            }
        }
    }

    GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        GameObject nearestEnemy = null;
        float minDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(enemy.transform.position, currentPosition);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestEnemy = enemy;
            }
        }

        return nearestEnemy;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
