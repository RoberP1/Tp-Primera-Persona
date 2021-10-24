using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    public float health = 100;
    [SerializeField] private Slider sVida;
    public bool alive;
    private bool CanTakeDamage;

    void Start()
    {
        alive = true;
        CanTakeDamage = true;
    }

    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy") && CanTakeDamage)
        {
            Debug.Log("Entro en contacto con Enemy");
            Damage(20);
            StartCoroutine(DelayDaño(3));

        }
    }
    
    

    public void Damage(float damage)
    {
        health -= damage;
        sVida.value = health;
        
        if (alive && health <= 0)
        {
            alive = false;
        }
    }

    IEnumerator DelayDaño(int delay)
    {
        CanTakeDamage = false;
        yield return new WaitForSeconds(delay);
        CanTakeDamage = true;
    }
}
