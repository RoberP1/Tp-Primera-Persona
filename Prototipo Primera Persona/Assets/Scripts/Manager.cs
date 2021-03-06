using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [SerializeField] Text Tkills;
     
    [SerializeField] GameObject VictoriaPanel;
    [SerializeField] GameObject DerrotaPanel;
    [SerializeField] GameObject ObjetivoPanel;
    [SerializeField] Transform Spawner1;
    [SerializeField] Transform Spawner2;
    [SerializeField] Transform Spawner3;
    [SerializeField] Transform Spawner4;
    [SerializeField] Transform SpawnerBoss;
    [SerializeField] private GameObject EnemyPrefab;

    public List<GameObject> Enemigos = new List<GameObject>();


    public bool Vivo;
    public int kills;

    private bool MouseVisible;

    private Disparar disparo;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Vivo = true;
        VictoriaPanel.SetActive(false);
        DerrotaPanel.SetActive(false);
        kills = 0;
        StartCoroutine(DelaySpawn(1f,Spawner1,EnemyPrefab,1));
        StartCoroutine(DelayObjetivo(10f));
        MouseVisible = false;
        disparo = FindObjectOfType<Disparar>();

    }

    // Update is called once per frame
    void Update()
    {
        if (kills == 10)
        {
            VictoriaPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            disparo.CanShoot = false;
            
        }
        if (!Vivo)
        {
            foreach (GameObject item in Enemigos)
            {
                Destroy(item);
                
            }
            DerrotaPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            disparo.CanShoot = false;
            //SceneManager.LoadScene("Juego", LoadSceneMode.Single);
        }
        if (Input.GetKeyDown("escape") && Vivo)
        {
            if (MouseVisible)
            {
                Cursor.lockState = CursorLockMode.None;
                MouseVisible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                MouseVisible = true;
            }
        }
    }

 
    public void EnemyDead()
    {
        kills++;
        Tkills.text = kills.ToString();

        switch (kills)
        {
            case 1:
                StartCoroutine(DelaySpawn(3f, Spawner2, EnemyPrefab, 2));
                break;


            case 3:
                StartCoroutine(DelaySpawn(3f, Spawner3, EnemyPrefab, 1));
                StartCoroutine(DelaySpawn(3f, Spawner4, EnemyPrefab, 2));
                break;


            case 6:
                StartCoroutine(DelaySpawn(3f, SpawnerBoss, EnemyPrefab, 2));
                StartCoroutine(DelaySpawn(3f, Spawner4, EnemyPrefab, 2));
                break;


            default:
                break;
        }
    }

    private IEnumerator DelaySpawn(float delay, Transform spawner,GameObject enemy, int cantEnemy)
    {
        Random rnd = new Random();
        yield return new WaitForSeconds(delay);
        for (int i = 0; i < cantEnemy; i++)
        {
            float position = rnd.Next(-3, 3);
            Vector3 p = spawner.position + new Vector3(position, 0, position);
            Enemigos.Add(Instantiate(enemy, p, Quaternion.identity));
        }
    }
    private IEnumerator DelayObjetivo(float delay)
    {
        ObjetivoPanel.SetActive(true);
        yield return new WaitForSeconds(delay);
        ObjetivoPanel.SetActive(false);
    }
}
