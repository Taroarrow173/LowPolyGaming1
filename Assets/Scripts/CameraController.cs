using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensetivity;
    public float rotationX;
    public Transform player;




    void Update()
    {


        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensetivity;
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensetivity;

        //transform.localEulerAngles = new Vector3(mouseX, mouseY, 0f);
        //  transform.Rotate(Vector3.up, mouseY);
        //   transform.Rotate(Vector3.right, mouseX);
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        transform.localEulerAngles = new Vector3(rotationX, 0f, 0f);
        player.Rotate(Vector3.up, mouseX);
    }
}