using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : MonoBehaviour
{

    public float time;
    public Transform player;
    public PlayerControllerP2 PController;
    public int damage;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        PController = GameObject.Find("Player").GetComponent<PlayerControllerP2>();
        Destroy(this.gameObject, time);
        transform.LookAt(player);

    }

    private void OnCollisionEnter(Collision collision)
    {

        Destroy(this.gameObject, 0f);
        if (collision.gameObject.name == ("Player"))
        {
            PController.TakeDamage(damage);
            Debug.Log("Damaged");
        }
    }
}
