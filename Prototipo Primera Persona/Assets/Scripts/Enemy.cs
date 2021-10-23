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
    private Rigidbody rb;
    private bool alive;
    [SerializeField] private GameObject yo;
    [SerializeField] private Slider Vida;

    void Start()
    {
        alive = true;
        Vida.value = health;
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
        Vida.value = health;
        if (alive && health <= 0)
        {
            agent.enabled = rb.isKinematic = alive = false;
            rb.AddRelativeTorque(transform.right * 5,ForceMode.Impulse);
            StartCoroutine(DelayDestruccion(3));
        }
    }

    IEnumerator DelayDestruccion(int delay)
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(delay);
        Destroy(yo);
    }
}
