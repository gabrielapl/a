using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Entity entity;
    Animator enemyAnimation;

    public void Start()
    {
        enemyAnimation = GetComponent<Animator>();
    }

    private void Update()
    {
        if(entity.currentHealth <= 0)
        {
            enemyAnimation.SetTrigger("deathing");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        entity.currentHealth -= 10f;
    }

}
