using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour
{
    // These comments are temporary until the UI stuff gets pushed 

    [Header("----- Components -----")]
    [SerializeField] Renderer model;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Animator anim;

    [SerializeField] Transform ShootPos;
    [SerializeField] Transform headPos;

    [Header("----- Stats -----")]
    [SerializeField] int HP;
    [SerializeField] int faceTargetSpeed;
    [SerializeField] int FOV;
    [SerializeField] int roamDist;
    [SerializeField] int roamTimer;
    [SerializeField] int animSpeedTrans;

    [SerializeField] GameObject bullet;
    [SerializeField] float shootRate;

    bool playerInRange;
    bool isShooting;
    bool isRoaming;

    Color colorOrig;

    float angleToPlayer;
    float stoppingDistOrig;

    Coroutine Co;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (agent.isActiveAndEnabled)
    //    {
    //        float agentSpeed = agent.velocity.normalized.magnitude;
    //        float animSpeed = anim.GetFloat("Speed");

    //        anim.SetFloat("Speed", Mathf.MoveTowards(animSpeed, agentSpeed, Time.deltaTime * animSpeedTrans));

    //        if (playerInRange && !canSeePlayer())
    //        {
    //            if (!isRoaming && agent.remainingDistance < 0.01f)
    //                Co = StartCoroutine(roamDist());

    //        }else if (!playerInRange)
    //        {
    //            if (!isRoaming && agent.remainingDistance < 0.01f)
    //                Co = StartCoroutine(roamDist());
    //        }
    //    }
    //}

    //IEnumerator roam()
    //{
    //    isRoaming = true;
    //    yield return new WaitForSeconds(roamTimer);

    //    agent.stoppingDistance = 0;


    //    Vector3 randomPos = Random.insideUnitSphere * roamDist;
    //    randomPos += startingPos;

    //    NavMeshHit hit;
    //    NavMesh.SamplePosition(randomPos, out hit, roamDist, 1);
    //    agent.SetDestination(hit.position);

    //    isRoaming = false;
    //}

    //bool canSeePlayer()
    //{
    //    playerDir = gameManager.instance.Player.transform.position - headPOS.position;
    //    angleToPlayer = Vector3.Angle(playerDir, transform.forward);

    //    Debug.DrawRay(headPOS.position, playerDir);

    //    RaycastHit hit;
    //    if (Physics.Raycast(headPOS.position, playerDir, out hit))
    //    {
    //        if (hit.collider.CompareTag("Player") && angleToPlayer <= FOV)
    //        {

    //            agent.SetDestination(gameManager.instance.Player.transform.position);

    //            if (agent.remainingDistance < agent.stoppingDistance)
    //            {
    //                faceTarget();
    //            }

    //            if (!isShooting)
    //            {
    //                StartCoroutine(shoot());
    //            }
    //            agent.stoppingDistance = stoppingDistOrig;
    //            return true;
    //        }
    //    }
    //    agent.stoppingDistance = 0;
    //    return false;
    //}

    //void faceTarget()
    //{
    //    Quaternion rot = Quaternion.LookRotation(playerDir);
    //    transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * faceTargetSpeed);
    //}
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        playerInRange = true;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        playerInRange = false;
    //        agent.stoppingDistance = 0;
    //    }
    //}
    //public void takeDamage(int amount)
    {

        //HP -= amount;

        //if (agent.isActiveAndEnabled)
        //    agent.SetDestination(gameManager.instance.Player.transform.position);

        //if (Co != null)
        //    StopCoroutine(Co);

        //isRoaming = false;
        //StartCoroutine(flashRed());
        //updateUI();

        //if (HP <= 0)
        //{
        //    //I'm dead
        //    gameManager.instance.updateGameGoal(-1);
        //    Destroy(gameObject);
        }
    }

//    IEnumerator shoot()
//    {
//        isShooting = true;
//        anim.SetTrigger("Shoot");

//        Instantiate(bullet, ShootPos.position, transform.rotation);
//        yield return new WaitForSeconds(shootRate);

//        isShooting = false;
//    }

//    IEnumerator flashRed()
//    {
//        model.material.color = Color.red;
//        yield return new WaitForSeconds(0.1f);
//        model.material.color = colorOrig;
//    }

//    public void Damage(float damage)
//    {
//        throw new System.NotImplementedException();
//    }
//}
