using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerSpawner : MonoBehaviour
{
    private Vector3 spawnPosition;

    public GameObject Player;

    [Header("Spawn Values")]
    public float maxDist = 50f;
    public float minDist = 10f;
    public float maxAngle;
    public float timerSpawn = 1f;
    public int maxEnemy = 10;

    public GameObject[] EnemyList;

    [Tooltip("En pourcentage, mettre dans l'ordre croissant, en symétrie avec l'ennemie en question")]
    public float[] enemySpawnRates;


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


    private int ChooseEnemyToSpawn()
    {
        float randomValue = Random.Range(0, 100);
        int valueToChoose = 0;
        for (int i = 0; i < enemySpawnRates.Length; i++)
        {
            if (randomValue < enemySpawnRates[i])
            {
                valueToChoose = i;
            }
        }

        return valueToChoose;
    }


    private void SpawnEnemy ()
    {
        if (canSpawn && enemyCount <= maxEnemy)
        {
            canSpawn = false;
            int randValue = ChooseEnemyToSpawn();
            Debug.Log(randValue);
            Instantiate(EnemyList[randValue], spawnPosition, Quaternion.identity);
        }
    }
}
