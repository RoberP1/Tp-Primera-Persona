using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    private bool CanShoot = true;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit hit)
            && hit.collider.gameObject.CompareTag("Enemy") && CanShoot)
        {   
            bool headshot = hit.collider.gameObject.name.Contains("Cabeza");
            Enemy enemy = hit.collider.GetComponentInParent<Enemy>();

            enemy.Damage(headshot ? 50f : 20f);
            StartCoroutine(Cadencia(1f));
        }
    }
    IEnumerator Cadencia(float delay)
    {
        CanShoot = false;
        yield return new WaitForSeconds(delay);
        CanShoot = true;
    }
}
