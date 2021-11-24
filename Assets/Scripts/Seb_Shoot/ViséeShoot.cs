using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViséeShoot : MonoBehaviour
{
    public Camera CamJeu;
    // Start is called before the first frame update

    // Update is called once per frame
    [SerializeField] Transform LieuDeVisée;
    [SerializeField] GameObject boltEx;
    [SerializeField] float speed;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            CamJeu = GetComponentInParent<Camera>();
            GameObject ins = Instantiate(boltEx, LieuDeVisée.position, CamJeu.transform.rotation);
            ins.GetComponent<Rigidbody>().AddForce(ins.transform.forward * Time.deltaTime*speed);
            Debug.DrawLine(transform.position, LieuDeVisée.position, Color.green);
        }
    }
}
