using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingAndThrowing : MonoBehaviour
{
    public int pOffSet;
    private void OnMouseDown()
    {
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = GameObject.Find("Desination").transform.position;
        this.transform.parent = GameObject.Find("Desination").transform;
        GetComponent<Rigidbody>().detectCollisions = false;
    }

    private void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().detectCollisions = true;
    }

}
