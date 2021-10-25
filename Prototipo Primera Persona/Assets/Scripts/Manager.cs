using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class Manager : MonoBehaviour
{
    [SerializeField] Text Tkills;
    [SerializeField] GameObject VictoriaPanel;
    [SerializeField] GameObject DerrotaPanel;
    [SerializeField] Transform Spawner1;
    [SerializeField] Transform Spawner2;
    [SerializeField] Transform Spawner3;
    [SerializeField] Transform SpawnerBoss;
    [SerializeField] private GameObject EnemyPrefab;

    public List<GameObject> Enemigos = new List<GameObject>();


    public bool Vivo;
    public int kills;

    
    void Start()
    {
        Vivo = true;
        VictoriaPanel.SetActive(false);
        DerrotaPanel.SetActive(false);
        kills = 0;
        StartCoroutine(DelaySpawn(1f,Spawner1,EnemyPrefab,1));
        
    }

    // Update is called once per frame
    void Update()
    {
        if (kills == 10)
        {
            VictoriaPanel.SetActive(true);
        }
        if (!Vivo)
        {
            foreach (GameObject item in Enemigos)
            {
                Destroy(item);
                DerrotaPanel.SetActive(true);
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
                StartCoroutine(DelaySpawn(3f, Spawner3, EnemyPrefab, 3));
                break;


            case 6:
                StartCoroutine(DelaySpawn(3f, SpawnerBoss, EnemyPrefab, 4));
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
}
