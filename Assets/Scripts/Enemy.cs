using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  
  [SerializeField] Transform target;
   Rigidbody2D rb2D;
    Animator enemyAnimation;
  
  public Entity entity;
  public GameObject experienceObject;

   [Header("Drop Reward")]
   public int rewardExperience = 10;
   public int lootGoldMin = 0;
   public int lootGoldMax = 10;

    public void Start()
  {
        rb2D = GetComponent<Rigidbody2D>();
        enemyAnimation = GetComponent<Animator>();
  }

  private void Update()
  {
    Vector2 positionTarget = target.position;
    Vector2 positionActuly = transform.position;
        Vector2 direction = positionTarget - positionActuly;
        direction = direction.normalized;

        rb2D.velocity = (entity.speed * direction);

    if (entity.currentHealth <= 0)
    {
      enemyAnimation.SetTrigger("deathing");

     Instantiate(experienceObject, transform.position, Quaternion.identity);
     Destroy(this.gameObject);
    }
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    entity.currentHealth -= 10;
  }

}
