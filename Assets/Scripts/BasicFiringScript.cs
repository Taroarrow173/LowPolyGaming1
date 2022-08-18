using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFiringScript : MonoBehaviour
{
    public float damage;
    public float range;
    public float XV;
    public Camera cam;
    public GameObject Cake;
    GameObject ICake;
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    

    
    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            ICake = Instantiate(Cake, cam.transform.position, cam.transform.rotation);
            ICake.GetComponent<Rigidbody>().AddForce(XV * transform.forward, ForceMode.Impulse);
            Destroy(ICake, 10f);
        } 
    }
}
