using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{


    private float health = 100f;
    private NavMeshAgent agent;
    private Transform target;
    private Rigidbody rb;
    private bool alive;
    void Start()
    {
        alive = true;
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        target = FindObjectOfType<Movimiento>().transform;
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
    }

    public void Damage(float damage)
    {
        health -= damage;
        if (alive && health <= 0)
        {
            agent.enabled = rb.isKinematic = alive = false;
            rb.AddForce(-transform.forward * 250f);
        }
    }
}
