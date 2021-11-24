using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIScript : MonoBehaviour
{
    private NavMeshAgent navM;
    public GameObject Player;

    private void OnEnable()
    {
        navM = GetComponent<NavMeshAgent>();
        navM.SetDestination(Player.transform.position);
    }

}
