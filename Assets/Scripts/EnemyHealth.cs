﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float value = 100;
    public Animator animator;

    public PlayerProgress playerProgress;

    private void start()
    {
        playerProgress = FindObjectOfType<PlayerProgress>();
    }

    public void DealDamage(float damage)
    {
        
        value -= damage;
        if (value <= 0)
        {   
            EnemyDeath();
        }
        else
        {
            animator.SetTrigger("hit");
           playerProgress.AddExperience(10);
        }
        

    }
    private void EnemyDeath()
    {
        animator.SetTrigger("Death");
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
    }

}
