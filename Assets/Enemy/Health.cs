using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(EnemyTag))]
public class Health : MonoBehaviour
{
    [SerializeField] int maxHP = 5;
    [SerializeField] int difficultyUp = 1; //aumenta la vita di Enemy
    int currentHP = 0;

    EnemyTag enemy;
    void OnEnable()
    {
        currentHP = maxHP;
    }

    void Start()
    {
        enemy = GetComponent<EnemyTag>();
    }


    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        currentHP--;

        if (currentHP <= 0)
        {
            gameObject.SetActive(false);
            maxHP += difficultyUp;
            enemy.Reward();
        }
    }
}