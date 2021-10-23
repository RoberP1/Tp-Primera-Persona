using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit hit)
            && hit.collider.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Toco enemigo");
            bool headshot = hit.collider.gameObject.name.Contains("Cabeza");
            Enemy enemy = hit.collider.GetComponentInParent<Enemy>();
            Debug.Log("Headshot" + headshot);
            enemy.Damage(headshot ? 50f : 20f);
           
        }
    }
}
