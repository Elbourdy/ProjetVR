using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bolt : MonoBehaviour
{
    [SerializeField] GameObject[] points = new GameObject[5];
    int i = 0;

    public void AddEnnemy(GameObject arg)
    {
        if (i < 5)
        {
            arg.GetComponent<AIScript>().enabled = false;
            arg.GetComponent<NavMeshAgent>().enabled = false;
            if (arg.CompareTag("Infantry")) arg.GetComponent<CapsuleCollider>().enabled = false;
            arg.transform.SetParent(points[i].transform);
            arg.transform.position = points[i].transform.position;
            i++;
        }
        else GameObject.Destroy(arg);
    }
}
