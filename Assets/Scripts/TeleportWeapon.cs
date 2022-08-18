using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportWeapon : MonoBehaviour
{

    public Camera cam;
    public GameObject TeleRing;
    public Transform player;
    private GameObject ITeleRing;
    public LayerMask ground;
    public int maxDistance;

    private bool activeTele = false;
    

    void Update()
    {
        RaycastHit hit;
        if (Input.GetButtonDown("Fire1") && activeTele == false && Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, maxDistance, ground))
        {
            ITeleRing = Instantiate(TeleRing, hit.point + hit.normal * 5, Quaternion.Euler(0, 0, 0));

            activeTele = true;

            Debug.DrawLine(cam.transform.position, hit.point, Color.red);
        }

        if (activeTele && Input.GetKeyDown(KeyCode.T))
        {
            player.transform.position = ITeleRing.transform.position + ITeleRing.transform.up * 50;
            
            Destroy(ITeleRing);

            activeTele = false;

        }


    }
}
