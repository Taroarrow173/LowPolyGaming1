using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour
{
    public Animator Anim;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Anim.Play("Shoot");
        }
    }

}
