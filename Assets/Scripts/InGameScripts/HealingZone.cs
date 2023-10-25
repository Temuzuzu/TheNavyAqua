using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingZone : MonoBehaviour
{
    Collider2D Collider2D;
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
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StopCoroutine("Heal");
        }
    }
    IEnumerator Heal()
    {
        for(float currentHealth = HealthManager.healthAmount; currentHealth < 15000; currentHealth += 20f)
        {
            HealthManager.healthAmount = currentHealth;
            yield return new WaitForSeconds (Time.deltaTime);
        }
      
    }
}
