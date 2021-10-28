using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private float health = 100f;
    private NavMeshAgent agent;
    private Transform target;
    private Vida player;
    private Rigidbody rb;
    private bool alive;
    private Manager manager;
    [SerializeField] private GameObject yo;
    [SerializeField] private Slider Vida;

    private bool CanMakeDamage;

    void Start()
    {
        manager = FindObjectOfType<Manager>();
        player = FindObjectOfType<Vida>();
        alive = true;
        Vida.value = health;
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        target = FindObjectOfType<Movimiento>().transform;
        CanMakeDamage = true;
        
    }

    public void ItsAlive()
    {
        health = 100f;
        agent.enabled = rb.isKinematic = alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (alive && Vector3.Distance(transform.position, target.position) < 100f)
            agent.SetDestination(target.position);
        if (Vector3.Distance(transform.position, target.position) <= 2.1f)
        { 
            if (CanMakeDamage && alive)
            {
                player.Damage(20);
                StartCoroutine(DelayDaño(1.5f));
            }
        }
    }

   



    public void Damage(float damage)
    {
        health -= damage;
        Vida.value = health;
        if (alive && health <= 0)
        {
            manager.EnemyDead();
            agent.enabled = rb.isKinematic = alive = false;
            rb.AddRelativeTorque(Vector3.right* -5,ForceMode.Impulse);
            StartCoroutine(DelayDestruccion(3));
        }
    }

    IEnumerator DelayDestruccion(int delay)
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(delay);
        manager.Enemigos.Remove(yo);
        Destroy(yo);
    }
    public IEnumerator DelayDaño(float delay)
    {
        CanMakeDamage = false;
        yield return new WaitForSeconds(delay);
        CanMakeDamage = true;
    }
}
