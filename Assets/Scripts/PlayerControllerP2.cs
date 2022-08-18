using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerP2 : MonoBehaviour
{
    public int maxHp;
    public int hp;
    public float playerSpeed = 10f;
    public float gravity = -9.81f;
    public float maxDistance;
    public float radius;
    public float jumpHeight;
    public bool isGrounded;
    
    private Vector3 velocity;
    public CharacterController Controller;
    public LayerMask ground;

    private void Start()
    {
        hp = maxHp;
    }


    void Update()
    {
       //Checks if grounded, if true then set isgrounded variable to true
        RaycastHit hit;
        isGrounded = Physics.SphereCast(transform.position, radius, -transform.up, out hit, maxDistance, ground);
       //Resets velocity, gives -2 to make it slower
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
       //Input for wasd keys
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //Put the input into a vector3
        Vector3 move = transform.right * x + transform.forward * z;
        Controller.Move(move * playerSpeed * Time.deltaTime);

        //Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Debug.Log("Jumping");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        //Use the calculated velocity variables to move upwards
        velocity.y += gravity * Time.deltaTime;
        //Use wasd input to move
        Controller.Move(velocity * Time.deltaTime);
    }
    

    public void TakeDamage(int damage)
    {
        hp -= damage;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position + -transform.up * maxDistance, radius);
    }

}
