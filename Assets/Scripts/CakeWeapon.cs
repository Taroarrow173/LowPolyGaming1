using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeWeapon : MonoBehaviour
{
    public GameObject Cake;
    public Camera Cam;
    public ParticleSystem PR;

    private Vector3 debugR;

    // Update is called once per frame
    void Update()   
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            if(Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit))
            {

                Instantiate(Cake, hit.point, Quaternion.identity);
                PR.transform.position = hit.point + transform.up * 10;
                PR.Play();
                

                debugR = hit.point;

            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(Cam.transform.position, debugR);
            
    }


}



