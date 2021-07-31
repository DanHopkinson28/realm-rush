﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHP = 5;
    [Tooltip("Adds amount to maxHP when enemy dies")]
    [SerializeField] int difficultyRamp = 1;
    int currentHP;

    Enemy enemy;

    void OnEnable()
    {
        currentHP = maxHP;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        currentHP --;

        if (currentHP <= 0)
        {
            enemy.RewardGold();
            maxHP += difficultyRamp;
            gameObject.SetActive(false);
        }
    }
}
