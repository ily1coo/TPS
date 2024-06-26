﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public PlayerController player;
    public float viewAngle;
    public float damage = 30;
    public Animator animator;

    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;
    private PlayerHealth _playerHealth;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        NoticePlayerUpdate();
 
              
        ChaseUpdate();
        AttackUpdate();
        PatrolUpdate();
        
               
    }
    private void NoticePlayerUpdate()
    {

        var direction = player.transform.position - transform.position;
        _isPlayerNoticed = false;
        if (Vector3.Angle(transform.forward, direction)<viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject && _playerHealth.value >= 0)
                {
                    _isPlayerNoticed = true;
                }
            }
            
        }

        
    }
    private void ChaseUpdate()
    {
        if(_isPlayerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }
    }
    private void PatrolUpdate()
    {
        if (!_isPlayerNoticed)
        {
           if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                PickNewPatrolPoint();
            } 
        }
        
    }
    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, 3)].position;
    }
    private void AttackUpdate()
    {
        if (_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                _playerHealth.DealDamage(damage * Time.deltaTime);
                animator.SetTrigger("Attack");
            }
            
        }
        
    }
}


