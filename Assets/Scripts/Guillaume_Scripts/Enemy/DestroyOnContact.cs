using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour
{



    private void OnEnable()
    {
        GameManagerSpawner.enemyCount += 1;
    }

    private void OnDisable()
    {
        GameManagerSpawner.enemyCount -= 1;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Destroy(gameObject);
        }
    }
}
