using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Movimiento Cabeza;
    private bool CanShoot = true;
    
    // Start is called before the first frame update
    void Start()
    {
        Cabeza = FindObjectOfType<Movimiento>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && CanShoot)
        {
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit hit) && hit.collider.gameObject.CompareTag("Enemy") )
            {
                bool headshot = hit.collider.gameObject.name.Contains("Cabeza");
                Enemy enemy = hit.collider.GetComponentInParent<Enemy>();
                enemy.Damage(headshot ? 50f : 20f);
            }
            
            StartCoroutine(Cadencia(1f));
            StartCoroutine(Retroceso(0.05f));
        }
    }
    IEnumerator Cadencia(float delay)
    {
        CanShoot = false;
        yield return new WaitForSeconds(delay);
        CanShoot = true;

    }
    IEnumerator Retroceso(float delay)
    {
        
        Cabeza.Disparo(0.3f);
        yield return new WaitForSeconds(delay);
        Cabeza.Disparo(0);
    }
}
