using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    public float health = 100;
    [SerializeField] private Slider sVida;
    [SerializeField] private Manager manager;
    public bool alive;
    private bool CanTakeDamage;

    void Start()
    {
        manager = FindObjectOfType<Manager>();
        alive = true;
        CanTakeDamage = true;
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.CompareTag("Enemy"))
        {
            if (CanTakeDamage)
            {
                Damage(20);
                StartCoroutine(DelayDaño(1.5f));
            } 
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        
    }
    
    

    public void Damage(float damage)
    {
        health -= damage;
        sVida.value = health;
        
        if (alive && health <= 0)
        {
            alive = false;
            manager.Vivo = false;
        }
    }

    IEnumerator DelayDaño(float delay)
    {
        CanTakeDamage = false;
        yield return new WaitForSeconds(delay);
        CanTakeDamage = true;
    }
}
