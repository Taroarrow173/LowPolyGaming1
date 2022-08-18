using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Transform tr;
    Rigidbody rb;
    //Movement
    public float playerSpeed;

    public float dashTime;

    //Jumping
    public LayerMask layermask;
    private GameObject currentHitObject;
    public float jumpForce = 2f;
    public float sphereRadius;
    public float maxDistance;
    private Vector3 origin;
    private Vector3 direction;
    private float currentHitDistance;
    [SerializeField]
    private bool isGrounded;
    void Start()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        origin = transform.position;
        direction = -transform.up;
        float deltaX = playerSpeed * Input.GetAxis("Horizontal");
        float deltaZ = playerSpeed * Input.GetAxis("Vertical");
        tr.Translate(deltaX * Time.deltaTime, 0f, deltaZ * Time.deltaTime);

        if (Physics.SphereCast(origin, sphereRadius, direction, out RaycastHit hit, maxDistance, layermask, QueryTriggerInteraction.Ignore))
        {
            currentHitObject = hit.transform.gameObject;
            currentHitDistance = hit.distance;
            isGrounded = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(0f, jumpForce, 0, ForceMode.Impulse);
            isGrounded = false;

        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            rb.AddForce(transform.forward * 2 * playerSpeed, ForceMode.Impulse);
        }


    }

    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Debug.DrawLine(origin, origin + direction * currentHitDistance);
        Gizmos.DrawWireSphere(origin + direction * currentHitDistance, sphereRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(origin + direction * maxDistance, sphereRadius);
    }
}
