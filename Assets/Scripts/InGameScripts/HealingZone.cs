using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingZone : MonoBehaviour
{
    private void Start()
    {
        GetComponent<HealthManager>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
     if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine("Heal");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StopCoroutine("Heal");
        }
    }
    IEnumerator Heal()
    {
        for(float currentHealth = HealthManager.healthAmount; currentHealth <= 1; currentHealth += 0.0005f)
        {
            HealthManager.healthAmount = currentHealth;
            yield return new WaitForSeconds (Time.deltaTime);
        }
        HealthManager.healthAmount = 6000f;
    }
}
