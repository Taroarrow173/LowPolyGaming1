using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIEyeball : MonoBehaviour
{
    public int sightRange, attackRange, walkRange, lazerOffSet, bulletX;
    private bool destinationSet, playerInSightRange, playerInAttackRange, bulletFired, animFinished;
    private const string IsFiring = "IsFiring";

    public RaycastHit hit, ghit;
    private Vector3 destination;
    public LayerMask player, ground;
    
    public NavMeshAgent nav;
    public Transform Tplayer;
    public GameObject Lazer;
    public Animator Anim;
    void Update()
    {

        //Anim.Play("Shoot");
        playerInSightRange = (Physics.CheckSphere(transform.position, sightRange, player));

        playerInAttackRange = (Physics.CheckSphere(transform.position, attackRange, player));

        Debug.Log("in attack range? "  + playerInAttackRange + "player in sight range? " + playerInSightRange);

        if (!playerInSightRange && !playerInAttackRange) Patrol();

        if (playerInSightRange && !playerInAttackRange) Chase();

        if (playerInSightRange && playerInAttackRange) Attack();

    }

    private void Patrol()
    {
        StopAllCoroutines();

        Debug.Log(destinationSet);
        
        if (!destinationSet)
        {
            Debug.Log("Desination not set");
        
            SearchWalkPoint();   
        }

        if (destinationSet)
        {
            Debug.Log("Destination set");
           
            nav.SetDestination(destination);

        }

        float dist = nav.remainingDistance;

        Debug.Log(dist != Mathf.Infinity);
      
        Debug.Log(nav.pathStatus);
       
        Debug.Log("Nav remaing distance " + nav.remainingDistance);

        if (dist != Mathf.Infinity && nav.pathStatus == NavMeshPathStatus.PathComplete && nav.remainingDistance <= 3)
        {
            Debug.Log("Reset");
           
            destinationSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        float randomX = Random.Range(-walkRange, walkRange);
      
        float randomZ = Random.Range(-walkRange, walkRange);
      
        Debug.Log("Searching for a desination" + destination);
       
        destination = new Vector3(transform.position.x + randomX, this.transform.position.y, transform.position.z + randomZ);
       
        destinationSet = true;
    }
    private void Chase()
    {
        nav.SetDestination(Tplayer.position);
        StopAllCoroutines();
    }

    private void Attack()
    {
        StartCoroutine(AttackAnim());

        transform.LookAt(Tplayer);
        /*
         if (!bulletFired)
         {
             animFinished = false;

             Anim.Play("Shoot");

             Invoke("SyncAnimation", 2f);
         }
     }
     private void Reload()
     {
         bulletFired = false;
     }
        */
    }
    private IEnumerator AttackAnim()
    {
        Anim.SetBool("IsFiring?", true);

        Anim.Play("Shoot");

        yield return new WaitForSeconds(2f);

        GameObject ILazer;

        ILazer = Instantiate(Lazer, transform.position + transform.forward * lazerOffSet, Quaternion.identity);

        ILazer.GetComponent<Rigidbody>().AddForce(bulletX * transform.forward, ForceMode.Impulse);

        bulletFired = true;

        yield return new WaitForSeconds(2f);
    }


    private void SyncAnimation()
    {
        GameObject ILazer;
      
        ILazer = Instantiate(Lazer, transform.position + transform.forward * lazerOffSet, Quaternion.identity);
       
        ILazer.GetComponent<Rigidbody>().AddForce(bulletX * transform.forward, ForceMode.Impulse);
      
        bulletFired = true;
      
        Invoke("Reload", 0f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        
        Gizmos.DrawWireSphere(transform.position, sightRange);

        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, attackRange);

        Gizmos.DrawLine(destination, ghit.point);

        Gizmos.DrawSphere(ghit.point, 2);

        Gizmos.DrawSphere(destination, 3);
    }

}
