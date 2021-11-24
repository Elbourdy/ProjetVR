using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAction : MonoBehaviour
{
    public int gunDamage = 1;
    public float weaponRange = 200f;
    public float hitForce = 100f;
    private Camera fpsCam;
    public float fireRate = 0.25f;
    public float nextFire;
    public LayerMask layerMask;
    void Start()
    {
        fpsCam = GetComponentInParent<Camera>();

        void Update()
        {
            if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;

                print(nextFire);

                //On va lancer un rayon invisible qui simulera les balles du gun
                //Cr�e un vecteur au centre de la vue de la cam�ra
                Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

                //RaycastHit : permet de savoir ce que le rayon a touch�
                RaycastHit hit;


                // V�rifie si le raycast a touch� quelque chose
                if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange, layerMask))
                {
                    print("Target");
                    if (hit.rigidbody != null)
                    {

                        //AddForce = Ajoute Force = Pousse le RigidBody avec la force de l'impact
                        hit.rigidbody.AddForce(-hit.normal * hitForce);

                        //S'assure que la cible touch�e a un composant ReceiveAction
                        if (hit.collider.gameObject.GetComponent<ReceiveAction>() != null)
                        {
                            //Envoie les dommages � la cible
                            hit.collider.gameObject.GetComponent<ReceiveAction>().GetDamage(gunDamage);
                        }
                    }
                }
            }
        }
    }
}