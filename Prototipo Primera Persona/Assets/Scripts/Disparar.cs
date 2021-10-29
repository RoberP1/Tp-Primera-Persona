using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    private Movimiento Cabeza;
    [SerializeField] private AudioSource Shot;
    [SerializeField] private AudioSource Reload;

    [SerializeField] private GameObject UIReload;
    [SerializeField] private Material Rojo;
    [SerializeField] private Material Verde;
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
            StartCoroutine(Recarga(0.5f));
            StartCoroutine(Retroceso(0.1f));
        }
    }
    IEnumerator Cadencia(float delay)
    {
        Shot.Play();
        CanShoot = false;
        UIReload.GetComponent<MeshRenderer>().material = Rojo;
        yield return new WaitForSeconds(delay);
        UIReload.GetComponent<MeshRenderer>().material = Verde;
        CanShoot = true;

    }
    IEnumerator Recarga(float delay)
    {
        
        yield return new WaitForSeconds(delay);
        Reload.Play();
        

    }
    IEnumerator Retroceso(float delay)
    {
        
        Cabeza.Disparo(0.7f);
        yield return new WaitForSeconds(delay);
        Cabeza.Disparo(0);
    }
}
