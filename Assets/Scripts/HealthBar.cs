using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Slider easeHealthSlider;
    public float maxHealth = 100f;
    public float health;
    private float lerpSpeed = 0.05f;
    private Camera mainCamera;
    public Transform lookatObj;
    public bool isEnemy = false;
    public GameObject expObject;
    public GameObject takeHitObj;
    public GameObject failCanvas;


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        mainCamera = Camera.main;

        healthSlider.maxValue = maxHealth;
        easeHealthSlider.maxValue = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (mainCamera != null)
        {
            lookatObj.LookAt(mainCamera.transform);
        }

        if (healthSlider.value != health)
        {
            healthSlider.value = health;
        }

        if (healthSlider.value != easeHealthSlider.value)
        {
            easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value,health,lerpSpeed);

        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        var a = Instantiate(takeHitObj, this.transform.position, Quaternion.identity);
        Destroy(a, .2f);

        if (health <= 0)
        {
            if (isEnemy)
            {
                EnemySpawner.Instance.EnemyDestroyed();
                Instantiate(expObject, this.transform.position, Quaternion.identity);
                this.gameObject.SetActive(false);
            }
            else
            {
                failCanvas.SetActive(true);
            }
      }
    }
}
