using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerSpawner : MonoBehaviour
{
    private Vector3 spawnPosition;
    public GameObject EnemyPrefab;

    public GameObject Player;

    [Header("Spawn Values")]
    public float maxDist = 50f;
    public float minDist = 10f;
    public float maxAngle;
    public float timerSpawn = 1f;
    public int maxEnemy = 10;


    //Descend ou augmente dans DestroyOnContact
    public static float enemyCount;

    private bool canSpawn = true;
    private float timer = 0f;



    private void Start()
    {
        enemyCount = 0;
    }

    private void Update()
    {
        DefineZoneSpawner();
        DefineCanSpawn();
        SpawnEnemy();
    }



    private void DefineZoneSpawner()
    {
        var distPos = Player.transform.forward * Random.Range(minDist,maxDist);
        var anglePos = Random.Range(-maxAngle, maxAngle);

        var calculatedPos = Quaternion.AngleAxis(anglePos, Player.transform.up) * distPos;
        spawnPosition = calculatedPos;
    }


    private void DefineCanSpawn ()
    {
        timer += Time.deltaTime;
        if (timer >= timerSpawn)
        {
            canSpawn = true;
            timer = 0f;
        }
    }



    private void SpawnEnemy ()
    {
        if (canSpawn && enemyCount <= maxEnemy)
        {
            Instantiate(EnemyPrefab, spawnPosition, transform.rotation);
            canSpawn = false;
        }
    }
}
