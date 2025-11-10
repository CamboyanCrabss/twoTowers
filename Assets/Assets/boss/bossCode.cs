using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class bossCode : MonoBehaviour
{
    public float activationRadius = 15f;
    public float restTime = 5f;
    public float chargeTime = 1f;
    public float turnSpeed = 8f;

    private Transform Player;
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    private bool canLook = false;
    private bool canStart = true;
    private Animator anim;

    private void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        Player = GameObject.Find("Player").transform;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, Player.position);

        if (distanceToPlayer < activationRadius && canStart)
        {
            StartCoroutine(timedDash());
            canLook = true;
            canStart = false;
        }

        if (canLook)
        {
            Vector3 lookDirection = (Player.position - transform.position).normalized;
            lookDirection.y = 0;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, lookDirection, turnSpeed * Time.deltaTime, 0.0f);
            transform.forward = newDirection;
        }
    }

    private IEnumerator timedDash()
    {
        while (true)
        {
            yield return new WaitForSeconds(restTime);
            anim.SetBool("isAttacking", true);
            navMeshAgent.SetDestination(Player.position);
            canLook = false;
            yield return new WaitForSeconds(chargeTime);
            anim.SetBool("isAttacking", false);
            navMeshAgent.SetDestination(transform.position);
            canLook = true;
        }
    }
}
