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
    

    void Start()
    {
        manager = FindObjectOfType<Manager>();
        alive = true;
        
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


}
